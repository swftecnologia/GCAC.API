using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GCAC.Core.Interfaces.Servicos.Localidade;
using GCAC.Core.Extensions.Localidade;
using GCAC.Core.Entidades.Localidade;
using GCAC.Core.DTOs.Localidade;

namespace GCAC.API.Controllers.Localidade
{
    /// <summary>
    /// Controlador para tratar os países
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/localidade/pais")]
    public class PaisController : ControllerBase
    {
        private readonly IPaisServico _paisServico;

        /// <summary>
        /// Construtor do controlador
        /// </summary>
        /// <param name="paisServico">Serviços da entidade Pais</param>
        public PaisController(IPaisServico paisServico)
        {
            _paisServico = paisServico;
        }

        /// <summary>
        /// Seleciona todos os países
        /// </summary>
        /// <returns>Lista de países</returns>
        [HttpGet]
        [Route("selecionar-todos")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<Pais>> SelecionarTodos()
        {
            return await _paisServico.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um país pelo seu identificador único
        /// </summary>
        /// <param name="id">Identificador único do país</param>
        /// <returns>País</returns>
        [HttpGet]
        [Route("selecionar-por-id")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<Pais>> SelecionarPorId(long id)
        {
            var item = await _paisServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return item;
        }

        /// <summary>
        /// Cria um novo país
        /// </summary>
        /// <param name="itemDTO">Novo país a ser criado</param>
        /// <returns>País criado</returns>
        [HttpPost]
        [Route("inserir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<Pais>> Inserir(PaisDTO itemDTO)
        {
            if (await _paisServico.ExistePorNome(itemDTO.Nome))
            {
                return NotFound("Não foi possível realizar a solicitação: País já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _paisServico.Inserir(item);
            itemDTO = item.AsDTO();

            return CreatedAtAction("SelecionarPorId", new { id = itemDTO.Id }, itemDTO);
        }

        /// <summary>
        /// Atualiza um país
        /// </summary>
        /// <param name="itemDTO">País a ser atualizado</param>
        /// <returns>Mensagem de resposta OK</returns>
        [HttpPut]
        [Route("atualizar")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> Atualizar(PaisDTO itemDTO)
        {
            if (await _paisServico.ExistePorNome(itemDTO.Nome, (long)itemDTO.Id))
            {
                return BadRequest("Não foi possível realizar a solicitação: País já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _paisServico.Atualizar(item);
            return Ok("Solicitação realizada com sucesso.");
        }

        /// <summary>
        /// Exclui um país
        /// </summary>
        /// <param name="id">Identificador único do país a ser excluído</param>
        /// <returns>Mensagem de resposta OK</returns>
        [HttpDelete]
        [Route("excluir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult<Pais>> Excluir(long id)
        {
            var item = await _paisServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            await _paisServico.Excluir(item);
            return Ok("Solicitação realizada com sucesso.");
        }
    }
}