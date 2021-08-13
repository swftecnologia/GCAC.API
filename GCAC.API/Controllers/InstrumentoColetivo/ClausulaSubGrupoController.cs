﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GCAC.Core.Interfaces.Servicos.InstrumentoColetivo;
using GCAC.Core.Extensions.InstrumentoColetivo;
using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.DTOs.InstrumentoColetivo;

namespace GCAC.API.Controllers.InstrumentoColetivo
{
    /// <summary>
    /// Controlador para tratar as sub-grupos do grupo da claúsula
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/instrumento-coletivo/[controller]")]
    public class ClausulaSubGrupoController : ControllerBase
    {
        private readonly IClausulaSubGrupoServico _clausulaSubGrupoServico;

        /// <summary>
        /// Construtor do controlador
        /// </summary>
        /// <param name="clausulaSubGrupoServico">Serviços da entidade ClausulaSubGrupo</param>
        public ClausulaSubGrupoController(IClausulaSubGrupoServico clausulaSubGrupoServico)
        {
            _clausulaSubGrupoServico = clausulaSubGrupoServico;
        }

        /// <summary>
        /// Seleciona todos os sub-grupos do grupo da claúsula
        /// </summary>
        /// <returns>Lista de sub-grupos do grupo da claúsula</returns>
        [HttpGet]
        [Route("selecionar-todos")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<ClausulaSubGrupo>> SelecionarTodos()
        {
            return await _clausulaSubGrupoServico.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um sub-grupo do grupo da claúsula pelo seu identificador único
        /// </summary>
        /// <param name="id">Identificador único do sub-grupo do grupo da claúsula</param>
        /// <returns>Sub-grupo do grupo da claúsula</returns>
        [HttpGet]
        [Route("selecionar-por-id")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<ClausulaSubGrupo>> SelecionarPorId(long id)
        {
            var item = await _clausulaSubGrupoServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return item;
        }

        /// <summary>
        /// Cria um novo sub-grupo do grupo da claúsula
        /// </summary>
        /// <param name="itemDTO">Novo sub-grupo do grupo da claúsula a ser criado</param>
        /// <returns>Sub-grupo do grupo da claúsula criado</returns>
        [HttpPost]
        [Route("inserir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<ClausulaSubGrupo>> Inserir(ClausulaSubGrupoDTO itemDTO)
        {
            if (await _clausulaSubGrupoServico.ExistePorDescricao(itemDTO.Descricao))
            {
                return NotFound("Não foi possível realizar a solicitação: Sub-grupo do grupo da claúsula já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _clausulaSubGrupoServico.Inserir(item);
            itemDTO = item.AsDTO();

            return CreatedAtAction("SelecionarPorId", new { id = itemDTO.Id }, itemDTO);
        }

        /// <summary>
        /// Atualiza um sub-grupo do grupo da claúsula
        /// </summary>
        /// <param name="itemDTO">Sub-grupo do grupo da claúsula a ser atualizado</param>
        /// <returns>Mensagem de resposta OK</returns>
        [HttpPut]
        [Route("atualizar")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> Atualizar(ClausulaSubGrupoDTO itemDTO)
        {
            if (await _clausulaSubGrupoServico.ExistePorDescricao(itemDTO.Descricao, (long)itemDTO.Id))
            {
                return BadRequest("Não foi possível realizar a solicitação: Sub-grupo do grupo da claúsula já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _clausulaSubGrupoServico.Atualizar(item);
            return Ok("Solicitação realizada com sucesso.");
        }

        /// <summary>
        /// Exclui um sub-grupo do grupo da claúsula
        /// </summary>
        /// <param name="id">Identificador único do sub-grupo do grupo da claúsula a ser excluído</param>
        /// <returns>Mensagem de resposta OK</returns>
        [HttpDelete]
        [Route("excluir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult<ClausulaSubGrupo>> Excluir(long id)
        {
            var item = await _clausulaSubGrupoServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            await _clausulaSubGrupoServico.Excluir(item);
            return Ok("Solicitação realizada com sucesso.");
        }
    }
}