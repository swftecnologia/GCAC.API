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
    /// Controlador para tratar as cláusulas
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/instrumento-coletivo/clausula")]
    public class ClausulaController : ControllerBase
    {
        private readonly IClausulaServico _clausulaServico;

        /// <summary>
        /// Construtor do controlador
        /// </summary>
        /// <param name="clausulaServico">Serviços da entidade Clausula</param>
        public ClausulaController(IClausulaServico clausulaServico)
        {
            _clausulaServico = clausulaServico;
        }

        /// <summary>
        /// Seleciona todos os cláusulas
        /// </summary>
        /// <returns>Lista de cláusulas</returns>
        [HttpGet]
        [Route("selecionar-todos")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<Clausula>> SelecionarTodos()
        {
            return await _clausulaServico.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um cláusula pelo seu identificador único
        /// </summary>
        /// <param name="id">Identificador único do cláusula</param>
        /// <returns>Cláusula</returns>
        [HttpGet]
        [Route("selecionar-por-id")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<Clausula>> SelecionarPorId(long id)
        {
            var item = await _clausulaServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return item;
        }

        /// <summary>
        /// Lista todos as cláusulas para um determinado sub-grupo da cláusula
        /// </summary>
        /// <param name="id">Identificador único do sub-grupo da cláusula</param>
        /// <returns>Lista de cláusulas para um determinado sub-grupo da cláusula</returns>
        [HttpGet]
        [Route("selecionar-por-clausula-sub-grupo")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<Clausula>> SelecionarPorClausulaSubGrupo(long id)
        {
            return await _clausulaServico.SelecionarPorClausulaSubGrupo(id);
        }

        /// <summary>
        /// Cria um novo cláusula
        /// </summary>
        /// <param name="itemDTO">Novo cláusula a ser criado</param>
        /// <returns>Cláusula criado</returns>
        [HttpPost]
        [Route("inserir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<Clausula>> Inserir(ClausulaDTO itemDTO)
        {
            if (await _clausulaServico.ExistePorTitulo(itemDTO.Titulo))
            {
                return NotFound("Não foi possível realizar a solicitação: Cláusula já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _clausulaServico.Inserir(item);
            itemDTO = item.AsDTO();

            return CreatedAtAction("SelecionarPorId", new { id = itemDTO.Id }, itemDTO);
        }

        /// <summary>
        /// Atualiza um cláusula
        /// </summary>
        /// <param name="itemDTO">Cláusula a ser atualizado</param>
        /// <returns>Mensagem de resposta OK</returns>
        [HttpPut]
        [Route("atualizar")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> Atualizar(ClausulaDTO itemDTO)
        {
            if (await _clausulaServico.ExistePorTitulo(itemDTO.Titulo, (long)itemDTO.Id))
            {
                return BadRequest("Não foi possível realizar a solicitação: Cláusula já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _clausulaServico.Atualizar(item);
            return Ok("Solicitação realizada com sucesso.");
        }

        /// <summary>
        /// Exclui um cláusula
        /// </summary>
        /// <param name="id">Identificador único do cláusula a ser excluído</param>
        /// <returns>Mensagem de resposta OK</returns>
        [HttpDelete]
        [Route("excluir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult<Clausula>> Excluir(long id)
        {
            var item = await _clausulaServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            await _clausulaServico.Excluir(item);
            return Ok("Solicitação realizada com sucesso.");
        }
    }
}