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
    /// Controlador para tratar as categorias
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/instrumento-coletivo/categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaServico _categoriaServico;

        /// <summary>
        /// Construtor do controlador
        /// </summary>
        /// <param name="categoriaServico">Serviços da entidade Categoria</param>
        public CategoriaController(ICategoriaServico categoriaServico)
        {
            _categoriaServico = categoriaServico;
        }

        /// <summary>
        /// Seleciona todos os categorias
        /// </summary>
        /// <returns>Lista de categorias</returns>
        [HttpGet]
        [Route("selecionar-todos")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<Categoria>> SelecionarTodos()
        {
            return await _categoriaServico.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um categoria pelo seu identificador único
        /// </summary>
        /// <param name="id">Identificador único do categoria</param>
        /// <returns>Categoria</returns>
        [HttpGet]
        [Route("selecionar-por-id")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<Categoria>> SelecionarPorId(long id)
        {
            var item = await _categoriaServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return item;
        }

        /// <summary>
        /// Cria um novo categoria
        /// </summary>
        /// <param name="itemDTO">Novo categoria a ser criado</param>
        /// <returns>Categoria criado</returns>
        [HttpPost]
        [Route("inserir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<Categoria>> Inserir(CategoriaDTO itemDTO)
        {
            if (await _categoriaServico.ExistePorDescricao(itemDTO.Descricao))
            {
                return NotFound("Não foi possível realizar a solicitação: Categoria já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _categoriaServico.Inserir(item);
            itemDTO = item.AsDTO();

            return CreatedAtAction("SelecionarPorId", new { id = itemDTO.Id }, itemDTO);
        }

        /// <summary>
        /// Atualiza um categoria
        /// </summary>
        /// <param name="itemDTO">Categoria a ser atualizado</param>
        /// <returns>Mensagem de resposta OK</returns>
        [HttpPut]
        [Route("atualizar")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> Atualizar(CategoriaDTO itemDTO)
        {
            if (await _categoriaServico.ExistePorDescricao(itemDTO.Descricao, (long)itemDTO.Id))
            {
                return BadRequest("Não foi possível realizar a solicitação: Categoria já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _categoriaServico.Atualizar(item);
            return Ok("Solicitação realizada com sucesso.");
        }

        /// <summary>
        /// Exclui um categoria
        /// </summary>
        /// <param name="id">Identificador único do categoria a ser excluído</param>
        /// <returns>Mensagem de resposta OK</returns>
        [HttpDelete]
        [Route("excluir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult<Categoria>> Excluir(long id)
        {
            var item = await _categoriaServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            await _categoriaServico.Excluir(item);
            return Ok("Solicitação realizada com sucesso.");
        }
    }
}