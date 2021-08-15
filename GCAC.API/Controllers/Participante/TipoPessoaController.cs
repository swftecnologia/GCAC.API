using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GCAC.Core.Interfaces.Servicos.Participante;
using GCAC.Core.Extensions.Participante;
using GCAC.Core.Entidades.Participante;
using GCAC.Core.DTOs.Participante;

namespace GCAC.API.Controllers.Participante
{
    /// <summary>
    /// Controlador para tratar os tipos de pessoa do participante
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/localidade/[controller]")]
    public class TipoPessoaController : ControllerBase
    {
        private readonly ITipoPessoaServico _tipoPessoaServico;

        /// <summary>
        /// Construtor do controlador
        /// </summary>
        /// <param name="tipoPessoaServico">Serviços da entidade TipoPessoa</param>
        public TipoPessoaController(ITipoPessoaServico tipoPessoaServico)
        {
            _tipoPessoaServico = tipoPessoaServico;
        }

        /// <summary>
        /// Seleciona todos os tipos de pessoa do participante
        /// </summary>
        /// <returns>Lista de tipos de pessoa do participante</returns>
        [HttpGet]
        [Route("selecionar-todos")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<TipoPessoa>> SelecionarTodos()
        {
            return await _tipoPessoaServico.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um tipo de pessoa do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do tipo de pessoa do participante</param>
        /// <returns>Registro do tipo de pessoa do participante solicitado</returns>
        [HttpGet]
        [Route("selecionar-por-id")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<TipoPessoa>> SelecionarPorId(long id)
        {
            var item = await _tipoPessoaServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return item;
        }

        /// <summary>
        /// Cria um novo tipo de pessoa do participante
        /// </summary>
        /// <param name="itemDTO">Novo tipo de pessoa do participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        [HttpPost]
        [Route("inserir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<TipoPessoa>> Inserir(TipoPessoaDTO itemDTO)
        {
            if (await _tipoPessoaServico.ExistePorDescricao(itemDTO.Descricao))
            {
                return NotFound("Não foi possível realizar a solicitação: Grau da entidade do participante já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _tipoPessoaServico.Inserir(item);
            itemDTO = item.AsDTO();

            return CreatedAtAction("SelecionarPorId", new { id = itemDTO.Id }, itemDTO);
        }

        /// <summary>
        /// Atualiza um tipo de pessoa do participante
        /// </summary>
        /// <param name="itemDTO">Tipo de pessoa do participante a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        [HttpPut]
        [Route("atualizar")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> Atualizar(TipoPessoaDTO itemDTO)
        {
            if (await _tipoPessoaServico.ExistePorDescricao(itemDTO.Descricao, (long)itemDTO.Id))
            {
                return BadRequest("Não foi possível realizar a solicitação: Grau da entidade do participante já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _tipoPessoaServico.Atualizar(item);
            return Ok("Solicitação realizada com sucesso.");
        }

        /// <summary>
        /// Exclui um tipo de pessoa do participante
        /// </summary>
        /// <param name="id">Identificador único do tipo de pessoa do participante</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        [HttpDelete]
        [Route("excluir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult<TipoPessoa>> Excluir(long id)
        {
            var item = await _tipoPessoaServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            await _tipoPessoaServico.Excluir(item);
            return Ok("Solicitação realizada com sucesso.");
        }
    }
}