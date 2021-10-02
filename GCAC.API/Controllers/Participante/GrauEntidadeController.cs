using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GCAC.Core.Contratos.Servicos.Participante;
using GCAC.Core.Extensions.Participante;
using GCAC.Core.Entidades.Participante;
using GCAC.Core.DTOs.Participante;

namespace GCAC.API.Controllers.Participante
{
    /// <summary>
    /// Controlador para tratar os graus de entidade do participante
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/participante/grau-entidade")]
    public class GrauEntidadeController : ControllerBase
    {
        private readonly IGrauEntidadeServico _grauEntidadeServico;

        /// <summary>
        /// Construtor do controlador
        /// </summary>
        /// <param name="grauEntidadeServico">Serviços da entidade GrauEntidade</param>
        public GrauEntidadeController(IGrauEntidadeServico grauEntidadeServico)
        {
            _grauEntidadeServico = grauEntidadeServico;
        }

        /// <summary>
        /// Seleciona todos os graus da entidade do participante
        /// </summary>
        /// <returns>Lista de graus da entidade do participante</returns>
        [HttpGet]
        [Route("selecionar-todos")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<GrauEntidade>> SelecionarTodos()
        {
            return await _grauEntidadeServico.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um grau da entidade do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do grau da entidade do participante</param>
        /// <returns>Registro da grau da entidade do participante solicitado</returns>
        [HttpGet]
        [Route("selecionar-por-id")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<GrauEntidade>> SelecionarPorId(long id)
        {
            var item = await _grauEntidadeServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return item;
        }

        /// <summary>
        /// Cria um novo grau da entidade do participante
        /// </summary>
        /// <param name="itemDTO">Novo grau da entidade do participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        [HttpPost]
        [Route("inserir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<GrauEntidade>> Inserir(GrauEntidadeDTO itemDTO)
        {
            if (await _grauEntidadeServico.ExistePorDescricao(itemDTO.Descricao))
            {
                return NotFound("Não foi possível realizar a solicitação: Grau da entidade do participante já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _grauEntidadeServico.Inserir(item);
            itemDTO = item.AsDTO();

            return CreatedAtAction("SelecionarPorId", new { id = itemDTO.Id }, itemDTO);
        }

        /// <summary>
        /// Atualiza um grau da entidade do participante
        /// </summary>
        /// <param name="itemDTO">Grau da entidade do participante a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        [HttpPut]
        [Route("atualizar")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> Atualizar(GrauEntidadeDTO itemDTO)
        {
            if (await _grauEntidadeServico.ExistePorDescricao(itemDTO.Descricao, (long)itemDTO.Id))
            {
                return BadRequest("Não foi possível realizar a solicitação: Grau da entidade do participante já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _grauEntidadeServico.Atualizar(item);
            return Ok("Solicitação realizada com sucesso.");
        }

        /// <summary>
        /// Exclui um grau da entidade do participante
        /// </summary>
        /// <param name="id">Identificador único do grau da entidade do participante a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        [HttpDelete]
        [Route("excluir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult<GrauEntidade>> Excluir(long id)
        {
            var item = await _grauEntidadeServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            await _grauEntidadeServico.Excluir(item);
            return Ok("Solicitação realizada com sucesso.");
        }
    }
}