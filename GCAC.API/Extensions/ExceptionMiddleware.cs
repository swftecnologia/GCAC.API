using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using GCAC.API.Repositories;
using GCAC.Core.Entidades.Log;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;

namespace GCAC.API.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="baseRepository"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext, IBaseRepository<Erro> baseRepository)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex, baseRepository);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <param name="baseRepository"></param>
        /// <returns></returns>
        private async Task<Task> HandleExceptionAsync(HttpContext context, Exception exception, IBaseRepository<Erro> baseRepository)
        {
            string message = "";
            string innerException = "";
            string notificacao;
            int? number;

            if (exception != null)
            {
                message = exception.Message != null ? exception.Message : "";
                innerException = exception.InnerException != null ? exception.InnerException.Message : "";
            }

            try
            {
                number = ((SqlException)exception.InnerException).Number;
            }
            catch (Exception ex)
            {
                number = null;
                message = ex.Message != null ? String.IsNullOrEmpty(message) ? ex.Message : message + " " + ex.Message : "";
                innerException = ex.InnerException != null ? String.IsNullOrEmpty(innerException) ? ex.InnerException.Message : innerException + " " + ex.InnerException.Message : "";
            }

            if (number != null)
            {
                switch (number)
                {
                    case 547: //Exclusão de chave estrangeira
                        notificacao = "Não foi possível realizar a solicitação: Existem registros relacionados ao registro a ser excluído.";
                        break;
                    case 2627: //Chave duplicada
                        notificacao = "Não foi possível realizar a solicitação: Já existe um cadastro existente.";
                        break;
                    default:
                        notificacao = "Não foi possível realizar a solicitação" + (String.IsNullOrEmpty(message) ? String.IsNullOrEmpty(innerException) ? "." : ": " + innerException : String.IsNullOrEmpty(innerException) ? ": " + message : ": " + message + " - " + innerException);
                        break;
                }
            }
            else
            {
                notificacao = "Não foi possível realizar a solicitação" + (String.IsNullOrEmpty(message) ? String.IsNullOrEmpty(innerException) ? "." : ": " + innerException : String.IsNullOrEmpty(innerException) ? ": " + message : ": " + message + " - " + innerException);
            }

            string dadosErro = JsonSerializer.Serialize(new
            {
                ok = false,
                status = (int)HttpStatusCode.InternalServerError,
                statusText = notificacao,
                type = "cors",
                url = context.Request.Scheme + "://" + context.Request.Host.Value + context.Request.Path.Value
            });

            try
            {
                await baseRepository.Inserir(new Erro()
                {
                    Dados = dadosErro,
                    Usuario = Environment.UserName,
                    DataOperacao = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                message = ex.Message != null ? String.IsNullOrEmpty(message) ? ex.Message : message + " " + ex.Message : "";
                innerException = ex.InnerException != null ? String.IsNullOrEmpty(innerException) ? ex.InnerException.Message : innerException + " " + ex.InnerException.Message : "";

                dadosErro = JsonSerializer.Serialize(new
                {
                    ok = false,
                    status = (int)HttpStatusCode.InternalServerError,
                    statusText = notificacao + " Não foi possível gravar o log de erro" + ex.Message != null ? ": " + ex.Message : "" + ex.InnerException != null ? ex.Message != null ? " " + ex.InnerException : ": " + ex.InnerException : "",
                    type = "cors",
                    url = context.Request.Scheme + "://" + context.Request.Host.Value + context.Request.Path.Value
                });
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(dadosErro);
        }
    }
}