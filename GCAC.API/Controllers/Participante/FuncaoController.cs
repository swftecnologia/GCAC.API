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
    /// Controlador para tratar as funções do participante
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/localidade/[controller]")]
    public class FuncaoController : ControllerBase
    {
        private readonly IFuncaoServico _funcaoServico;

        /// <summary>
        /// Construtor do controlador
        /// </summary>
        /// <param name="funcaoServico">Serviços da entidade Funcao</param>
        public FuncaoController(IFuncaoServico funcaoServico)
        {
            _funcaoServico = funcaoServico;
        }

        /// <summary>
        /// Seleciona todas as funções do participante
        /// </summary>
        /// <returns>Lista de funções do participante</returns>
        [HttpGet]
        [Route("selecionar-todos")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<Funcao>> SelecionarTodos()
        {
            return await _funcaoServico.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona uma função do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da função do participante</param>
        /// <returns>Registro da função do participante solicitada</returns>
        [HttpGet]
        [Route("selecionar-por-id")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<Funcao>> SelecionarPorId(long id)
        {
            var item = await _funcaoServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return item;
        }

        /// <summary>
        /// Cria uma nova função do participante
        /// </summary>
        /// <param name="itemDTO">Nova função do participante a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        [HttpPost]
        [Route("inserir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<Funcao>> Inserir(FuncaoDTO itemDTO)
        {
            if (await _funcaoServico.ExistePorDescricao(itemDTO.Descricao))
            {
                return NotFound("Não foi possível realizar a solicitação: Grau da entidade do participante já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _funcaoServico.Inserir(item);
            itemDTO = item.AsDTO();

            return CreatedAtAction("SelecionarPorId", new { id = itemDTO.Id }, itemDTO);
        }

        /// <summary>
        /// Atualiza uma função do participante
        /// </summary>
        /// <param name="itemDTO">Função do participante a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        [HttpPut]
        [Route("atualizar")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> Atualizar(FuncaoDTO itemDTO)
        {
            if (await _funcaoServico.ExistePorDescricao(itemDTO.Descricao, (long)itemDTO.Id))
            {
                return BadRequest("Não foi possível realizar a solicitação: Grau da entidade do participante já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _funcaoServico.Atualizar(item);
            return Ok("Solicitação realizada com sucesso.");
        }

        /// <summary>
        /// Exclui uma função do participante
        /// </summary>
        /// <param name="id">Identificador único da função do participante</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        [HttpDelete]
        [Route("excluir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult<Funcao>> Excluir(long id)
        {
            var item = await _funcaoServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            await _funcaoServico.Excluir(item);
            return Ok("Solicitação realizada com sucesso.");
        }
    }
}