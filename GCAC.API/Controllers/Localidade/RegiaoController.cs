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
    /// Controlador para tratar as regiões
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/localidade/regiao")]
    public class RegiaoController : ControllerBase
    {
        private readonly IRegiaoServico _regiaoServico;

        /// <summary>
        /// Construtor do controlador
        /// </summary>
        /// <param name="regiaoServico">Serviços da entidade Regiao</param>
        public RegiaoController(IRegiaoServico regiaoServico)
        {
            _regiaoServico = regiaoServico;
        }

        /// <summary>
        /// Seleciona todos os regiões
        /// </summary>
        /// <returns>Lista de regiões</returns>
        [HttpGet]
        [Route("selecionar-todos")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<Regiao>> SelecionarTodos()
        {
            return await _regiaoServico.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um região pelo seu identificador único
        /// </summary>
        /// <param name="id">Identificador único do região</param>
        /// <returns>Região</returns>
        [HttpGet]
        [Route("selecionar-por-id")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<Regiao>> SelecionarPorId(long id)
        {
            var item = await _regiaoServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return item;
        }

        /// <summary>
        /// Cria um novo região
        /// </summary>
        /// <param name="itemDTO">Novo região a ser criado</param>
        /// <returns>Região criado</returns>
        [HttpPost]
        [Route("inserir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<Regiao>> Inserir(RegiaoDTO itemDTO)
        {
            if (await _regiaoServico.ExistePorDescricao(itemDTO.Descricao))
            {
                return NotFound("Não foi possível realizar a solicitação: Região já cadastrada.");
            }

            var item = itemDTO.AsEntitie();
            await _regiaoServico.Inserir(item);
            itemDTO = item.AsDTO();

            return CreatedAtAction("SelecionarPorId", new { id = itemDTO.Id }, itemDTO);
        }

        /// <summary>
        /// Atualiza um região
        /// </summary>
        /// <param name="itemDTO">Região a ser atualizado</param>
        /// <returns>Mensagem de resposta OK</returns>
        [HttpPut]
        [Route("atualizar")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> Atualizar(RegiaoDTO itemDTO)
        {
            if (await _regiaoServico.ExistePorDescricao(itemDTO.Descricao, (long)itemDTO.Id))
            {
                return BadRequest("Não foi possível realizar a solicitação: Região já cadastrada.");
            }

            var item = itemDTO.AsEntitie();
            await _regiaoServico.Atualizar(item);
            return Ok("Solicitação realizada com sucesso.");
        }

        /// <summary>
        /// Exclui um região
        /// </summary>
        /// <param name="id">Identificador único do região a ser excluído</param>
        /// <returns>Mensagem de resposta OK</returns>
        [HttpDelete]
        [Route("excluir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult<Regiao>> Excluir(long id)
        {
            var item = await _regiaoServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            await _regiaoServico.Excluir(item);
            return Ok("Solicitação realizada com sucesso.");
        }
    }
}