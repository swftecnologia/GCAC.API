using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GCAC.Core.Interfaces.Servicos.Localidade;
using GCAC.Core.Entidades.Localidade;
using GCAC.Core.DTOs.Localidade;
using GCAC.Core.Extensions.Localidade;

namespace GCAC.API.Areas.Localidades.Estados.Controllers
{
    /// <summary>
    /// Controlador para tratar estados
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/localidade/estado")]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoServico _estadoServico;

        /// <summary>
        /// Construtor do controlador
        /// </summary>
        /// <param name="estadoServico">Serviços da entidade Estado</param>
        public EstadoController(IEstadoServico estadoServico)
        {
            _estadoServico = estadoServico;
        }

        /// <summary>
        /// Seleciona todos os estados
        /// </summary>
        /// <returns>Lista de estados</returns>
        [HttpGet]
        [Route("selecionar-todos")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<Estado>> SelecionarTodos()
        {
            return await _estadoServico.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um estado pelo seu identificador único
        /// </summary>
        /// <param name="id">Identificador único do estado</param>
        /// <returns>Estado</returns>
        [HttpGet]
        [Route("selecionar-por-id")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<Estado>> SelecionarPorId(long id)
        {
            var item = await _estadoServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return item;
        }

        /// <summary>
        /// Lista todos os estados para um determinado país
        /// </summary>
        /// <param name="id">Identificador único do país</param>
        /// <returns>Lista de estados para um determinado país</returns>
        [HttpGet]
        [Route("selecionar-por-pais")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<Estado>> SelecionarPorPais(long id)
        {
            return await _estadoServico.SelecionarPorPais(id);
        }

        /// <summary>
        /// Cria um novo estado
        /// </summary>
        /// <param name="itemDTO">Novo estado a ser criado</param>
        /// <returns>Estado criado</returns>
        [HttpPost]
        [Route("inserir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<Estado>> Inserir(EstadoDTO itemDTO)
        {
            if (await _estadoServico.ExistePorNome(itemDTO.Nome))
            {
                return NotFound("Não foi possível realizar a solicitação: Estado já cadastrado para o país.");
            }

            var item = itemDTO.AsEntitie();
            await _estadoServico.Inserir(item);
            itemDTO = item.AsDTO();

            return CreatedAtAction("SelecionarPorId", new { id = itemDTO.Id }, itemDTO);
        }

        /// <summary>
        /// Atualiza um estado
        /// </summary>
        /// <param name="itemDTO">Estado a ser atualizado</param>
        /// <returns>Mensagem de resposta OK</returns>
        [HttpPut]
        [Route("atualizar")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> Atualizar(EstadoDTO itemDTO)
        {
            if (await _estadoServico.ExistePorNome(itemDTO.Nome, (long)itemDTO.Id))
            {
                return BadRequest("Não foi possível realizar a solicitação: Estado já cadastrado para o país.");
            }

            var item = itemDTO.AsEntitie();
            await _estadoServico.Atualizar(item);
            return Ok("Solicitação realizada com sucesso.");
        }

        /// <summary>
        /// Exclui um estado
        /// </summary>
        /// <param name="id">Identificador único do estado a ser excluído</param>
        /// <returns>Mensagem de resposta OK</returns>
        [HttpDelete]
        [Route("excluir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult<Estado>> Excluir(long id)
        {
            var item = await _estadoServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            await _estadoServico.Excluir(item);
            return Ok("Solicitação realizada com sucesso.");
        }
    }
}