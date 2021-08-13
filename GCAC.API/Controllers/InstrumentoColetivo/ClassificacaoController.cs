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
    /// Controlador para tratar as classificações
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/instrumento-coletivo/[controller]")]
    public class ClassificacaoController : ControllerBase
    {
        private readonly IClassificacaoServico _classificacaoServico;

        /// <summary>
        /// Construtor do controlador
        /// </summary>
        /// <param name="regiaoServico">Serviços da entidade Classificacao</param>
        public ClassificacaoController(IClassificacaoServico regiaoServico)
        {
            _classificacaoServico = regiaoServico;
        }

        /// <summary>
        /// Seleciona todos os classificações
        /// </summary>
        /// <returns>Lista de classificações</returns>
        [HttpGet]
        [Route("selecionar-todos")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<Classificacao>> SelecionarTodos()
        {
            return await _classificacaoServico.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um classificação pelo seu identificador único
        /// </summary>
        /// <param name="id">Identificador único do classificação</param>
        /// <returns>Classificação</returns>
        [HttpGet]
        [Route("selecionar-por-id")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<Classificacao>> SelecionarPorId(long id)
        {
            var item = await _classificacaoServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return item;
        }

        /// <summary>
        /// Cria um novo classificação
        /// </summary>
        /// <param name="itemDTO">Novo classificação a ser criado</param>
        /// <returns>Classificação criado</returns>
        [HttpPost]
        [Route("inserir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<Classificacao>> Inserir(ClassificacaoDTO itemDTO)
        {
            if (await _classificacaoServico.ExistePorDescricao(itemDTO.Descricao))
            {
                return NotFound("Não foi possível realizar a solicitação: Classificação já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _classificacaoServico.Inserir(item);
            itemDTO = item.AsDTO();

            return CreatedAtAction("SelecionarPorId", new { id = itemDTO.Id }, itemDTO);
        }

        /// <summary>
        /// Atualiza um classificação
        /// </summary>
        /// <param name="itemDTO">Classificação a ser atualizado</param>
        /// <returns>Mensagem de resposta OK</returns>
        [HttpPut]
        [Route("atualizar")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> Atualizar(ClassificacaoDTO itemDTO)
        {
            if (await _classificacaoServico.ExistePorDescricao(itemDTO.Descricao, (long)itemDTO.Id))
            {
                return BadRequest("Não foi possível realizar a solicitação: Classificação já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _classificacaoServico.Atualizar(item);
            return Ok("Solicitação realizada com sucesso.");
        }

        /// <summary>
        /// Exclui um classificação
        /// </summary>
        /// <param name="id">Identificador único do classificação a ser excluído</param>
        /// <returns>Mensagem de resposta OK</returns>
        [HttpDelete]
        [Route("excluir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult<Classificacao>> Excluir(long id)
        {
            var item = await _classificacaoServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            await _classificacaoServico.Excluir(item);
            return Ok("Solicitação realizada com sucesso.");
        }
    }
}