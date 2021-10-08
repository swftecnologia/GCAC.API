using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GCAC.API.Utils;
using Microsoft.AspNetCore.Http;
using GCAC.Core.Contratos.Servicos.Usuario;
using GCAC.Core.Entidades.Usuario;
using GCAC.Core.DTOs.Usuario;
using GCAC.Core.Extensions.Usuario;

namespace GCAC.API.Controllers.Usuario.Controllers
{
    /// <summary>
    /// Controlador para tratar as contas de usuários
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/usuario/conta")]
    public class ContaController : ControllerBase
    {
        private readonly IContaServico _contaServico;

        /// <summary>
        /// Construtor do controlador
        /// </summary>
        /// <param name="contaServico">Serviços da entidade Conta</param>
        public ContaController(IContaServico contaServico)
        {
            _contaServico = contaServico;
        }

        /// <summary>
        /// Seleciona todas as contas
        /// </summary>
        /// <returns>Lista de contas</returns>
        [HttpGet]
        [Route("selecionar-todos")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<Conta>> SelecionarTodos()
        {
            return await _contaServico.SelecionarTodos();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("selecionar-por-id")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<Conta>> SelecionarPorId(long id)
        {
            var item = await _contaServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("selecionar-por-email")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<Conta> SelecionarPorEmail(string email)
        {
            return await _contaServico.SelecionarPorEmail(email);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="tokenAtivacao"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("obter-por-email-token-ativacao")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<ContaDTO>> SelecionarPorEmailETokenAtivacao(string email, string tokenAtivacao)
        {
            if (!String.IsNullOrWhiteSpace(email) || !String.IsNullOrWhiteSpace(tokenAtivacao))
            {
                var item = await _contaServico.SelecionarPorEmailETokenAtivacao(email, tokenAtivacao);

                if (item == null)
                {
                    return NotFound();
                }

                return item.AsDTO();
            }

            return BadRequest(new { errors = new { Email = new object[1] { "O Email é obrigatório." } }, title = "One or more validation errors occurred.", status = (int)HttpStatusCode.BadRequest });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("obter-por-email-senha")]
        public async Task<IActionResult> SelecionarParaLogin(string email, string senha)
        {
            var item = await _contaServico.SelecionarParaLogin(email, Seguranca.CriptografarSenha(senha));

            if (item == null)
            {
                return BadRequest("Não foi possível realizar o login. Verifique o e-mail ou senha informados ou crie uma nova conta para acessar o GCAC.");
            }
            else if (!item.Ativo)
            {
                return BadRequest("A conta não foi ativada. Acesse o e-mail informado no cadastro para ativar a conta ou solicite o reenvio do e-mail de ativação da conta para acessar o GCAC.");
            }
            else
            {
                return Ok(new string[] { item.Id.ToString(), item.Nome.ToString(), item.Email.ToString() });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("inserir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<Conta>> Inserir(ContaDTO itemDTO)
        {
            if ((!String.IsNullOrEmpty(itemDTO.Email) && await _contaServico.SelecionarPorEmail(itemDTO.Email) != null))
            {
                return NotFound("Não foi possível realizar a solicitação: E-mail já cadastrado.");
            }

            itemDTO.Senha = Seguranca.CriptografarSenha(itemDTO.Senha);
            itemDTO.TokenAtivacao = Guid.NewGuid();
            itemDTO.DataExpiracaoTokenAtivacao = DateTime.Now.AddDays(1);

            var item = itemDTO.AsEntitie();
            await _contaServico.Inserir(item);
            itemDTO = item.AsDTO();

            return CreatedAtAction("SelecionarPorId", new { id = itemDTO.Id }, itemDTO);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="tokenAtivacao"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ativar-conta")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> Atualizar(string email, string tokenAtivacao)
        {
            var item = await _contaServico.SelecionarPorEmailETokenAtivacao(email, tokenAtivacao);

            if (item == null)
            {
                return BadRequest("Não foi possível ativar a conta: e-mail não encontrado. Solicite o reenvio do e-mail de ativação da conta para tentar novamente.");
            }
            else if (item.Ativo)
            {
                return Ok("Sua conta já está ativa. Você será redirecionado para a página de entrada em <span id='tempoRedirecionamento'>5</span> segundos...");
            }
            else if (item.DataExpiracaoTokenAtivacao < DateTime.Now)
            {
                return BadRequest("Não foi possível ativar a conta: link com o prazo expirado. Solicite o reenvio do e-mail de ativação da conta para tentar novamente.");
            }
            else
            {
                item.Ativo = true;
                await _contaServico.Atualizar(item);

                return Ok("Sua conta foi ativada. Você será redirecionado para a página de entrada em <span id='tempoRedirecionamento'>5</span> segundos...");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemDTO"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("atualizar")]
        public async Task<IActionResult> Atualizar(ContaDTO itemDTO)
        {
            var item = await _contaServico.SelecionarPorEmailETokenAtivacao(itemDTO.Email, itemDTO.TokenAtivacao.ToString());

            if (item == null)
            {
                return NotFound();
            }

            item.Ativo = true;
            await _contaServico.Atualizar(item);

            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("excluir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult<Conta>> Excluir(long id)
        {
            var item = await _contaServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            await _contaServico.Excluir(item);
            return Ok("Solicitação realizada com sucesso.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="tokenAtivacao"></param>
        /// <param name="reenvio"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("enviar-email-link-ativacao")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> EnviarLinkAtivacaoUsuario(string email, string tokenAtivacao, bool reenvio)
        {
            if (reenvio)
            {
                Conta conta = await _contaServico.SelecionarPorEmail(email);

                conta.TokenAtivacao = Guid.NewGuid();
                conta.DataExpiracaoTokenAtivacao = DateTime.Now.AddDays(1);

                await _contaServico.Atualizar(conta);

                tokenAtivacao = conta.TokenAtivacao.ToString();
            }

            Email.EnviarLinkAtivacaoUsuario(email, tokenAtivacao);
            return NoContent();
        }
    }
}