using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GCAC.Core.Interfaces.Servicos.InstrumentoColetivo;
using GCAC.Core.Extensions.InstrumentoColetivo;
using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.DTOs.InstrumentoColetivo;

namespace GCAC.API.Controllers.InstrumentoColetivo
{
    /// <summary>
    /// Controlador para tratar as grupos da cláusula
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/instrumento-coletivo/[controller]")]
    public class ClausulaGrupoController : ControllerBase
    {
        private readonly IClausulaGrupoServico _clausulaGrupoServico;

        /// <summary>
        /// Construtor do controlador
        /// </summary>
        /// <param name="clausulaGrupoServico">Serviços da entidade ClausulaGrupo</param>
        public ClausulaGrupoController(IClausulaGrupoServico clausulaGrupoServico)
        {
            _clausulaGrupoServico = clausulaGrupoServico;
        }

        /// <summary>
        /// Seleciona todos os grupos da cláusula
        /// </summary>
        /// <returns>Lista de grupos da cláusula</returns>
        [HttpGet]
        [Route("selecionar-todos")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<ClausulaGrupo>> SelecionarTodos()
        {
            return await _clausulaGrupoServico.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um grupo da cláusula pelo seu identificador único
        /// </summary>
        /// <param name="id">Identificador único do grupo da cláusula</param>
        /// <returns>Grupo da cláusula</returns>
        [HttpGet]
        [Route("selecionar-por-id")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<ClausulaGrupo>> SelecionarPorId(long id)
        {
            var item = await _clausulaGrupoServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return item;
        }

        /// <summary>
        /// Cria um novo grupo da cláusula
        /// </summary>
        /// <param name="itemDTO">Novo grupo da cláusula a ser criado</param>
        /// <returns>Grupo da cláusula criado</returns>
        [HttpPost]
        [Route("inserir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<ClausulaGrupo>> Inserir(ClausulaGrupoDTO itemDTO)
        {
            if (await _clausulaGrupoServico.ExistePorDescricao(itemDTO.Descricao))
            {
                return NotFound("Não foi possível realizar a solicitação: Grupo da cláusula já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _clausulaGrupoServico.Inserir(item);
            itemDTO = item.AsDTO();

            return CreatedAtAction("SelecionarPorId", new { id = itemDTO.Id }, itemDTO);
        }

        /// <summary>
        /// Atualiza um grupo da cláusula
        /// </summary>
        /// <param name="itemDTO">Grupo da cláusula a ser atualizado</param>
        /// <returns>Mensagem de resposta OK</returns>
        [HttpPut]
        [Route("atualizar")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> Atualizar(ClausulaGrupoDTO itemDTO)
        {
            if (await _clausulaGrupoServico.ExistePorDescricao(itemDTO.Descricao, (long)itemDTO.Id))
            {
                return BadRequest("Não foi possível realizar a solicitação: Grupo da cláusula já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _clausulaGrupoServico.Atualizar(item);
            return Ok("Solicitação realizada com sucesso.");
        }

        /// <summary>
        /// Exclui um grupo da cláusula
        /// </summary>
        /// <param name="id">Identificador único do grupo da cláusula a ser excluído</param>
        /// <returns>Mensagem de resposta OK</returns>
        [HttpDelete]
        [Route("excluir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult<ClausulaGrupo>> Excluir(long id)
        {
            var item = await _clausulaGrupoServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            await _clausulaGrupoServico.Excluir(item);
            return Ok("Solicitação realizada com sucesso.");
        }
    }
}