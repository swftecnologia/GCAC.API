using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using GCAC.Core.Interfaces.Servicos.Integracao;

namespace GCAC.API.Controllers.Integracao
{
    /// <summary>
    /// Controlador para tratar as entidades sindicais do CNES
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/instrumento-coletivo/documento")]
    public class EntidadeSindicalCNESController : ControllerBase
    {
        private readonly IEntidadeSindicalCNESServico _entidadeSindicalCNESServico;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Construtor do controlador
        /// </summary>
        public EntidadeSindicalCNESController(IEntidadeSindicalCNESServico entidadeSindicalCNESServico, IConfiguration configuration)
        {
            _entidadeSindicalCNESServico = entidadeSindicalCNESServico;
            _configuration = configuration;
        }

        /// <summary>
        /// Obtém as entidades sindicais do CNES (Cadastro Nacional de Entidades Sindicais)
        /// </summary>
        [HttpGet]
        [Route("carregar-entidade-sindical-lista-base-territorial-cnes")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public string CarregarEntidadeSindicalListaBaseTerritorialCNES()
        {
            Tuple<DateTime, DateTime, int, string> carregarEntidadesSindicaisCNES = _entidadeSindicalCNESServico.CarregarEntidadeSindicalListaBaseTerritorialCNES(_configuration.GetValue(typeof(string), "CNES:ChromeDriver").ToString(), _configuration.GetValue(typeof(string), "CNES:URL").ToString(), (int)_configuration.GetValue(typeof(int), "CNES:QuantidadeLinhasParaPercorrer"));

            return String.Format("O processo foi iniciado às {0} e encerrado às {1}, percorrendo {2} linha(s). {3}", carregarEntidadesSindicaisCNES.Item1.ToShortDateString() + " " + carregarEntidadesSindicaisCNES.Item1.ToLongTimeString(), carregarEntidadesSindicaisCNES.Item2.ToShortDateString() + " " + carregarEntidadesSindicaisCNES.Item2.ToLongTimeString(), carregarEntidadesSindicaisCNES.Item3.ToString(), String.IsNullOrEmpty(carregarEntidadesSindicaisCNES.Item4) ? "Nenhum erro encontrado." : "Erro(s) encontrado(s): " + carregarEntidadesSindicaisCNES.Item4);
        }

        /// <summary>
        /// Obtém as entidades sindicais do CNES (Cadastro Nacional de Entidades Sindicais)
        /// </summary>
        [HttpGet]
        [Route("carregar-entidade-sindical-lista-categoria-cnes")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public string CarregarEntidadeSindicalListaCategoriaCNES()
        {
            Tuple<DateTime, DateTime, int, string> carregarEntidadesSindicaisCNES = _entidadeSindicalCNESServico.CarregarEntidadeSindicalListaCategoriaCNES(_configuration.GetValue(typeof(string), "CNES:ChromeDriver").ToString(), _configuration.GetValue(typeof(string), "CNES:URL").ToString(), (int)_configuration.GetValue(typeof(int), "CNES:QuantidadeLinhasParaPercorrer"));

            return String.Format("O processo foi iniciado às {0} e encerrado às {1}, percorrendo {2} linha(s). {3}", carregarEntidadesSindicaisCNES.Item1.ToShortDateString() + " " + carregarEntidadesSindicaisCNES.Item1.ToLongTimeString(), carregarEntidadesSindicaisCNES.Item2.ToShortDateString() + " " + carregarEntidadesSindicaisCNES.Item2.ToLongTimeString(), carregarEntidadesSindicaisCNES.Item3.ToString(), String.IsNullOrEmpty(carregarEntidadesSindicaisCNES.Item4) ? "Nenhum erro encontrado." : "Erro(s) encontrado(s): " + carregarEntidadesSindicaisCNES.Item4);
        }

        /// <summary>
        /// Obtém as entidades sindicais do CNES (Cadastro Nacional de Entidades Sindicais)
        /// </summary>
        [HttpGet]
        [Route("carregar-entidade-sindical-lista-geral-cnes")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public string CarregarEntidadeSindicalListaGeralCNES()
        {
            Tuple<DateTime, DateTime, int, string> carregarEntidadesSindicaisCNES = _entidadeSindicalCNESServico.CarregarEntidadeSindicalListaGeralCNES(_configuration.GetValue(typeof(string), "CNES:ChromeDriver").ToString(), _configuration.GetValue(typeof(string), "CNES:URL").ToString(), (int)_configuration.GetValue(typeof(int), "CNES:QuantidadeLinhasParaPercorrer"));

            return String.Format("O processo foi iniciado às {0} e encerrado às {1}, percorrendo {2} linha(s). {3}", carregarEntidadesSindicaisCNES.Item1.ToShortDateString() + " " + carregarEntidadesSindicaisCNES.Item1.ToLongTimeString(), carregarEntidadesSindicaisCNES.Item2.ToShortDateString() + " " + carregarEntidadesSindicaisCNES.Item2.ToLongTimeString(), carregarEntidadesSindicaisCNES.Item3.ToString(), String.IsNullOrEmpty(carregarEntidadesSindicaisCNES.Item4) ? "Nenhum erro encontrado." : "Erro(s) encontrado(s): " + carregarEntidadesSindicaisCNES.Item4);
        }
    }
}