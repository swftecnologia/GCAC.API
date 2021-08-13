using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GCAC.API.Areas.Usuarios.Contas.DataTransferObjects;
using GCAC.API.Areas.Usuarios.Contas.Repositories;
using GCAC.API.Areas.Usuarios.Extensions;
using GCAC.API.Areas.Usuarios.Contas.Entities;
using GCAC.API.Utils;
using Microsoft.AspNetCore.Http;

namespace GCAC.API.Areas.Usuarios.Contas.Controllers
{
    [ApiController]
    [Route("api/usuario/[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IContaRepository conta;

        public ContaController(IContaRepository conta)
        {
            this.conta = conta;
        }

        [HttpGet]
        [Route("obter-todos")]
        public async Task<IEnumerable<ContaDTORead>> List()
        {
            var itens = await conta.List();
            return itens.Select(item => item.AsDTO());
        }

        [HttpGet]
        [Route("obter-por-id")]
        public async Task<ActionResult<ContaDTORead>> Get(long id)
        {
            if (id > 0)
            {
                var item = await conta.Get(id);

                if (item == null)
                {
                    return NotFound();
                }

                return item.AsDTO();
            }

            return BadRequest(new { errors = new { Id = new object[1] { "O Id é obrigatório." } }, title = "One or more validation errors occurred.", status = (int)HttpStatusCode.BadRequest });
        }

        [HttpGet]
        [Route("obter-por-email")]
        public async Task<ActionResult<ContaDTORead>> Get(string email)
        {
            if (!String.IsNullOrWhiteSpace(email))
            {
                var item = await conta.Get(email);

                if (item == null)
                {
                    return NotFound();
                }

                return item.AsDTO();
            }

            return BadRequest(new { errors = new { Email = new object[1] { "O Email é obrigatório." } }, title = "One or more validation errors occurred.", status = (int)HttpStatusCode.BadRequest });
        }

        [HttpGet]
        [Route("obter-por-email-token-ativacao")]
        public async Task<ActionResult<ContaDTORead>> Get(string email, string tokenAtivacao)
        {
            if (!String.IsNullOrWhiteSpace(email) || !String.IsNullOrWhiteSpace(tokenAtivacao))
            {
                var item = await conta.Get(email, tokenAtivacao);

                if (item == null)
                {
                    return NotFound();
                }

                return item.AsDTO();
            }

            return BadRequest(new { errors = new { Email = new object[1] { "O Email é obrigatório." } }, title = "One or more validation errors occurred.", status = (int)HttpStatusCode.BadRequest });
        }

        [HttpGet]
        [Route("obter-por-email-senha")]
        public async Task<IActionResult> GetForLogin(string email, string senha)
        {
            if (!String.IsNullOrWhiteSpace(email) || !String.IsNullOrWhiteSpace(senha))
            {
                var item = await conta.GetForLogin(email, Seguranca.CriptografarSenha(senha));

                if (item == null)
                {
                    return NotFound();
                }

                HttpContext.Session.SetString("IDUsuario", item.Id.ToString());
                HttpContext.Session.SetString("Nome", item.Nome.ToString());
                HttpContext.Session.SetString("Login", item.Email.ToString());

                return Ok();
            }

            return BadRequest(new { errors = new { Email = new object[1] { "O Email é obrigatório." } }, title = "One or more validation errors occurred.", status = (int)HttpStatusCode.BadRequest });
        }

        [HttpGet]
        [Route("enviar-email-link-ativacao")]
        public void SendEmail(string email, string tokenAtivacao)
        {
            Email.EnviarLinkAtivacaoUsuario(email, tokenAtivacao);
        }

        [HttpPost]
        [Route("inserir")]
        public async Task<ActionResult<ContaDTOCreate>> Create(ContaDTOCreate itemDTO)
        {
            Conta item = itemDTO.AsEntitie();

            await conta.Create(item);

            return CreatedAtAction(nameof(Get), new { id = item.Id }, item.AsDTO());
        }

        [HttpPut]
        [Route("atualizar")]
        public async Task<IActionResult> Update(ContaDTOUpdate itemDTO)
        {
            var item = await conta.Get(itemDTO.Email, itemDTO.TokenAtivacao.ToString());

            if (item == null)
            {
                return NotFound();
            }

            item.Ativo = true;
            await conta.Update(item);

            return NoContent();
        }

        [HttpPut]
        [Route("ativar-conta")]
        public async Task<IActionResult> Update(string email, string tokenAtivacao)
        {
            var item = await conta.Get(email, tokenAtivacao);

            if (item == null)
            {
                return NotFound();
            }

            item.Ativo = true;
            await conta.Update(item);

            return NoContent();
        }

        [HttpDelete]
        [Route("excluir")]
        public async Task<ActionResult<Conta>> Delete(long id)
        {
            var item = await conta.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            await conta.Delete(item);
            return NoContent();
        }
    }
}