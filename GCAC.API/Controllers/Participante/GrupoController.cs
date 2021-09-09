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
    /// Controlador para tratar os grupos do participante
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/participante/grupo")]
    public class GrupoController : ControllerBase
    {
        private readonly IGrupoServico _grupoServico;

        /// <summary>
        /// Construtor do controlador
        /// </summary>
        /// <param name="grupoServico">Serviços da entidade Grupo</param>
        public GrupoController(IGrupoServico grupoServico)
        {
            _grupoServico = grupoServico;
        }

        /// <summary>
        /// Seleciona todos os grupos do participante
        /// </summary>
        /// <returns>Lista de grupos do participante</returns>
        [HttpGet]
        [Route("selecionar-todos")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<Grupo>> SelecionarTodos()
        {
            return await _grupoServico.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um grupo do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do grupo do participante</param>
        /// <returns>Registro do grupo do participante solicitado</returns>
        [HttpGet]
        [Route("selecionar-por-id")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<Grupo>> SelecionarPorId(long id)
        {
            var item = await _grupoServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return item;
        }

        /// <summary>
        /// Cria um novo grupo do participante
        /// </summary>
        /// <param name="itemDTO">Novo grupo do participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        [HttpPost]
        [Route("inserir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<Grupo>> Inserir(GrupoDTO itemDTO)
        {
            if (await _grupoServico.ExistePorDescricao(itemDTO.Descricao))
            {
                return NotFound("Não foi possível realizar a solicitação: Grau da entidade do participante já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _grupoServico.Inserir(item);
            itemDTO = item.AsDTO();

            return CreatedAtAction("SelecionarPorId", new { id = itemDTO.Id }, itemDTO);
        }

        /// <summary>
        /// Atualiza um grupo do participante
        /// </summary>
        /// <param name="itemDTO">Grupo do participante a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        [HttpPut]
        [Route("atualizar")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> Atualizar(GrupoDTO itemDTO)
        {
            if (await _grupoServico.ExistePorDescricao(itemDTO.Descricao, (long)itemDTO.Id))
            {
                return BadRequest("Não foi possível realizar a solicitação: Grau da entidade do participante já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _grupoServico.Atualizar(item);
            return Ok("Solicitação realizada com sucesso.");
        }

        /// <summary>
        /// Exclui um grupo do participante
        /// </summary>
        /// <param name="id">Identificador único do grupo do participante</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        [HttpDelete]
        [Route("excluir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult<Grupo>> Excluir(long id)
        {
            var item = await _grupoServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            await _grupoServico.Excluir(item);
            return Ok("Solicitação realizada com sucesso.");
        }
    }
}