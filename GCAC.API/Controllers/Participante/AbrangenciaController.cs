using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GCAC.Core.Extensions.InstrumentoColetivo;
using GCAC.Core.Contratos.Servicos.Participante;
using GCAC.Core.Entidades.Participante;
using GCAC.Core.DTOs.Participante;
using GCAC.Core.Extensions.Participante;

namespace GCAC.API.Controllers.Participante
{
    /// <summary>
    /// Controlador para tratar as abrangências
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/instrumento-coletivo/abrangencia")]
    public class AbrangenciaController : ControllerBase
    {
        private readonly IAbrangenciaServico _abrangenciaServico;

        /// <summary>
        /// Construtor do controlador
        /// </summary>
        /// <param name="abrangenciaServico">Serviços da entidade Abrangencia</param>
        public AbrangenciaController(IAbrangenciaServico abrangenciaServico)
        {
            _abrangenciaServico = abrangenciaServico;
        }

        /// <summary>
        /// Seleciona todos os abrangências
        /// </summary>
        /// <returns>Lista de abrangências</returns>
        [HttpGet]
        [Route("selecionar-todos")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<Abrangencia>> SelecionarTodos()
        {
            return await _abrangenciaServico.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um abrangência pelo seu identificador único
        /// </summary>
        /// <param name="id">Identificador único do abrangência</param>
        /// <returns>Abrangência</returns>
        [HttpGet]
        [Route("selecionar-por-id")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<Abrangencia>> SelecionarPorId(long id)
        {
            var item = await _abrangenciaServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return item;
        }

        /// <summary>
        /// Cria um novo abrangência
        /// </summary>
        /// <param name="itemDTO">Novo abrangência a ser criado</param>
        /// <returns>Abrangência criado</returns>
        [HttpPost]
        [Route("inserir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<Abrangencia>> Inserir(AbrangenciaDTO itemDTO)
        {
            if (await _abrangenciaServico.ExistePorDescricao(itemDTO.Descricao))
            {
                return NotFound("Não foi possível realizar a solicitação: Abrangência já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _abrangenciaServico.Inserir(item);
            itemDTO = item.AsDTO();

            return CreatedAtAction("SelecionarPorId", new { id = itemDTO.Id }, itemDTO);
        }

        /// <summary>
        /// Atualiza um abrangência
        /// </summary>
        /// <param name="itemDTO">Abrangência a ser atualizado</param>
        /// <returns>Mensagem de resposta OK</returns>
        [HttpPut]
        [Route("atualizar")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> Atualizar(AbrangenciaDTO itemDTO)
        {
            if (await _abrangenciaServico.ExistePorDescricao(itemDTO.Descricao, (long)itemDTO.Id))
            {
                return BadRequest("Não foi possível realizar a solicitação: Abrangência já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _abrangenciaServico.Atualizar(item);
            return Ok("Solicitação realizada com sucesso.");
        }

        /// <summary>
        /// Exclui um abrangência
        /// </summary>
        /// <param name="id">Identificador único do abrangência a ser excluído</param>
        /// <returns>Mensagem de resposta OK</returns>
        [HttpDelete]
        [Route("excluir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult<Abrangencia>> Excluir(long id)
        {
            var item = await _abrangenciaServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            await _abrangenciaServico.Excluir(item);
            return Ok("Solicitação realizada com sucesso.");
        }
    }
}