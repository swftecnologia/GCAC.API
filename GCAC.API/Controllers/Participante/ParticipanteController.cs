using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GCAC.Core.Contratos.Servicos.Participante;
using GCAC.Core.Extensions.Participante;
using GCAC.Core.DTOs.Participante;
using System;

namespace GCAC.API.Controllers.Participante
{
    /// <summary>
    /// Controlador para tratar os participantes
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/participante/participante")]
    public class ParticipanteController : ControllerBase
    {
        private readonly IParticipanteServico _participanteServico;

        /// <summary>
        /// Construtor do controlador
        /// </summary>
        /// <param name="participanteServico">Serviços da entidade Participante</param>
        public ParticipanteController(IParticipanteServico participanteServico)
        {
            _participanteServico = participanteServico;
        }

        /// <summary>
        /// Seleciona todos os participantes
        /// </summary>
        /// <returns>Lista de participantes</returns>
        [HttpGet]
        [Route("selecionar-todos")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<Core.Entidades.Participante.Participante>> SelecionarTodos()
        {
            return await _participanteServico.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do participante</param>
        /// <returns>Registro do participante solicitado</returns>
        [HttpGet]
        [Route("selecionar-por-id")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<Core.Entidades.Participante.Participante>> SelecionarPorId(long id)
        {
            var item = await _participanteServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return item;
        }

        /// <summary>
        /// Lista todos os particpantes de um determinado tipo de pessoa
        /// </summary>
        /// <param name="id">Identificador único do tipo de pessoa</param>
        /// <returns>Lista de particpantes de um determinado tipo de pessoa</returns>
        [HttpGet]
        [Route("selecionar-por-tipo-pessoa")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<Core.Entidades.Participante.Participante>> SelecionarPorTipoPessoa(long id)
        {
            return await _participanteServico.SelecionarPorTipoPessoa(id);
        }

        /// <summary>
        /// Lista todos os particpantes que são ou que não são entidades sindicais
        /// </summary>
        /// <param name="entidadeSindical">Indica se deve considerar apenas entidades sindicais</param>
        /// <returns>Lista de participantes que são ou que não são entidades sindicais</returns>
        [HttpGet]
        [Route("selecionar-por-entidade-sindical")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<Core.Entidades.Participante.Participante>> SelecionarPorEntidadeSindical(bool entidadeSindical)
        {
            return await _participanteServico.SelecionarPorEntidadeSindical(entidadeSindical);
        }

        /// <summary>
        /// Lista todos os particpantes para o(s) grupo(s) informado(s)
        /// </summary>
        /// <param name="ids">Identificador(es) único(s) do(s) grupo(s)</param>
        /// <returns>Lista de particpantes para o(s) grupo(s) informado(s)</returns>
        [HttpGet]
        [Route("selecionar-por-grupo")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<Core.Entidades.Participante.Participante>> SelecionarPorGrupo([FromQuery] long?[] ids)
        {
            return await _participanteServico.SelecionarPorGrupo(ids);
        }

        /// <summary>
        /// Cria um novo participante
        /// </summary>
        /// <param name="itemDTO">Novo participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        [HttpPost]
        [Route("inserir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<Core.Entidades.Participante.Participante>> Inserir(ParticipanteDTO itemDTO)
        {
            if ((!String.IsNullOrEmpty(itemDTO.CNPJ) && await _participanteServico.ExistePorCNPJ(itemDTO.CNPJ)) || (!String.IsNullOrEmpty(itemDTO.CPF) && await _participanteServico.ExistePorCPF(itemDTO.CPF)))
            {
                return NotFound("Não foi possível realizar a solicitação: Participante já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _participanteServico.Inserir(item);
            itemDTO = item.AsDTO();

            return CreatedAtAction("SelecionarPorId", new { id = itemDTO.Id }, itemDTO);
        }

        /// <summary>
        /// Atualiza um participante
        /// </summary>
        /// <param name="itemDTO">Participante a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        [HttpPut]
        [Route("atualizar")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> Atualizar(ParticipanteDTO itemDTO)
        {
            if ((!String.IsNullOrEmpty(itemDTO.CNPJ) && await _participanteServico.ExistePorCNPJ(itemDTO.CNPJ, (long)itemDTO.Id)) || (!String.IsNullOrEmpty(itemDTO.CPF) && await _participanteServico.ExistePorCPF(itemDTO.CPF, (long)itemDTO.Id)))
            {
                return BadRequest("Não foi possível realizar a solicitação: Participante já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _participanteServico.Atualizar(item);
            return Ok("Solicitação realizada com sucesso.");
        }

        /// <summary>
        /// Exclui um participante
        /// </summary>
        /// <param name="id">Identificador único do participante</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        [HttpDelete]
        [Route("excluir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult<Core.Entidades.Participante.Participante>> Excluir(long id)
        {
            var item = await _participanteServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            await _participanteServico.Excluir(item);
            return Ok("Solicitação realizada com sucesso.");
        }
    }
}