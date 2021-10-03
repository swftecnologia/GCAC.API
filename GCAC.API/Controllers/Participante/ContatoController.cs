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
    /// Controlador para tratar os contatos do participante
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/participante/contato")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoServico _contatoServico;

        /// <summary>
        /// Construtor do controlador
        /// </summary>
        /// <param name="contatoServico">Serviços da entidade Contato</param>
        public ContatoController(IContatoServico contatoServico)
        {
            _contatoServico = contatoServico;
        }

        /// <summary>
        /// Seleciona todas os contatos do participante
        /// </summary>
        /// <returns>Lista de contatos do participante</returns>
        [HttpGet]
        [Route("selecionar-todos")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<Contato>> SelecionarTodos()
        {
            return await _contatoServico.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um contato do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do contato do participante</param>
        /// <returns>Registro do contato do participante solicitado</returns>
        [HttpGet]
        [Route("selecionar-por-id")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<Contato>> SelecionarPorId(long id)
        {
            var item = await _contatoServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return item;
        }

        /// <summary>
        /// Lista todos os contatos para um determinado participante
        /// </summary>
        /// <param name="id">Identificador único do participante</param>
        /// <returns>Lista de contatos para um determinado participante</returns>
        [HttpGet]
        [Route("selecionar-por-participante")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<Contato>> SelecionarPorParticipante(long id)
        {
            return await _contatoServico.SelecionarPorParticipante(id);
        }

        /// <summary>
        /// Cria um novo contato do participante
        /// </summary>
        /// <param name="itemDTO">Novo contato do participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        [HttpPost]
        [Route("inserir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<Contato>> Inserir(ContatoDTO itemDTO)
        {
            if (await _contatoServico.ExistePorContatoParticipante(itemDTO.ParticipanteId, itemDTO.TipoContatoId, itemDTO.ContatoParticipante))
            {
                return NotFound("Não foi possível realizar a solicitação: Contato do participante já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _contatoServico.Inserir(item);
            itemDTO = item.AsDTO();

            return CreatedAtAction("SelecionarPorId", new { id = itemDTO.TipoContatoId }, itemDTO);
        }

        /// <summary>
        /// Atualiza um contato do participante
        /// </summary>
        /// <param name="itemDTO">Contato do participante a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        [HttpPut]
        [Route("atualizar")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> Atualizar(ContatoDTO itemDTO)
        {
            if (await _contatoServico.ExistePorContatoParticipante(itemDTO.ParticipanteId, itemDTO.TipoContatoId, itemDTO.ContatoParticipante, (long)itemDTO.Id))
            {
                return BadRequest("Não foi possível realizar a solicitação: Contato do participante já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _contatoServico.Atualizar(item);
            return Ok("Solicitação realizada com sucesso.");
        }

        /// <summary>
        /// Exclui um contato do participante
        /// </summary>
        /// <param name="id">Identificador único do contato do participante</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        [HttpDelete]
        [Route("excluir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult<Contato>> Excluir(long id)
        {
            var item = await _contatoServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            await _contatoServico.Excluir(item);
            return Ok("Solicitação realizada com sucesso.");
        }
    }
}