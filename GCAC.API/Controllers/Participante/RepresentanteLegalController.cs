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
    /// Controlador para tratar os representantes legais do participante
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/participante/representante-legal")]
    public class RepresentanteLegalController : ControllerBase
    {
        private readonly IRepresentanteLegalServico _representanteLegalServico;

        /// <summary>
        /// Construtor do controlador
        /// </summary>
        /// <param name="representanteLegalServico">Serviços da entidade RepresentanteLegal</param>
        public RepresentanteLegalController(IRepresentanteLegalServico representanteLegalServico)
        {
            _representanteLegalServico = representanteLegalServico;
        }

        /// <summary>
        /// Seleciona todos os representantes legais do participante
        /// </summary>
        /// <returns>Lista de representantes legais do participante</returns>
        [HttpGet]
        [Route("selecionar-todos")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<RepresentanteLegal>> SelecionarTodos()
        {
            return await _representanteLegalServico.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um representante legal do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do representante legal do participante</param>
        /// <returns>Registro do representante legal do participante solicitado</returns>
        [HttpGet]
        [Route("selecionar-por-id")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<RepresentanteLegal>> SelecionarPorId(long id)
        {
            var item = await _representanteLegalServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return item;
        }

        /// <summary>
        /// Cria um novo representante legal do participante
        /// </summary>
        /// <param name="itemDTO">Novo representante legal do participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        [HttpPost]
        [Route("inserir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<RepresentanteLegal>> Inserir(RepresentanteLegalDTO itemDTO)
        {
            if (await _representanteLegalServico.ExistePorDescricao(itemDTO.Descricao))
            {
                return NotFound("Não foi possível realizar a solicitação: Grau da entidade do participante já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _representanteLegalServico.Inserir(item);
            itemDTO = item.AsDTO();

            return CreatedAtAction("SelecionarPorId", new { id = itemDTO.Id }, itemDTO);
        }

        /// <summary>
        /// Atualiza um representante legal do participante
        /// </summary>
        /// <param name="itemDTO">Representante legal do participante a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        [HttpPut]
        [Route("atualizar")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> Atualizar(RepresentanteLegalDTO itemDTO)
        {
            if (await _representanteLegalServico.ExistePorDescricao(itemDTO.Descricao, (long)itemDTO.Id))
            {
                return BadRequest("Não foi possível realizar a solicitação: Grau da entidade do participante já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _representanteLegalServico.Atualizar(item);
            return Ok("Solicitação realizada com sucesso.");
        }

        /// <summary>
        /// Exclui um representante legal do participante
        /// </summary>
        /// <param name="id">Identificador único do representante legal do participante</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        [HttpDelete]
        [Route("excluir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult<RepresentanteLegal>> Excluir(long id)
        {
            var item = await _representanteLegalServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            await _representanteLegalServico.Excluir(item);
            return Ok("Solicitação realizada com sucesso.");
        }
    }
}