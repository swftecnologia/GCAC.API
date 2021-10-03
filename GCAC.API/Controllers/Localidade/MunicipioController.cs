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
    /// Controlador para tratar os município
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/localidade/municipio")]
    public class MunicipioController : ControllerBase
    {
        private readonly IMunicipioServico _municipioServico;

        /// <summary>
        /// Construtor do controlador
        /// </summary>
        /// <param name="municipioServico">Serviços da entidade Municipio</param>
        public MunicipioController(IMunicipioServico municipioServico)
        {
            _municipioServico = municipioServico;
        }

        /// <summary>
        /// Seleciona todos os município
        /// </summary>
        /// <returns>Lista de município</returns>
        [HttpGet]
        [Route("selecionar-todos")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<Municipio>> SelecionarTodos()
        {
            return await _municipioServico.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um município pelo seu identificador único
        /// </summary>
        /// <param name="id">Identificador único do município</param>
        /// <returns>Município</returns>
        [HttpGet]
        [Route("selecionar-por-id")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<Municipio>> SelecionarPorId(long id)
        {
            var item = await _municipioServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return item;
        }

        /// <summary>
        /// Lista todos os municípios para um determinado estado
        /// </summary>
        /// <param name="id">Identificador único do estado</param>
        /// <returns>Lista de municípios para um determinado estado</returns>
        [HttpGet]
        [Route("selecionar-por-estado")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<Municipio>> SelecionarPorEstado(long id)
        {
            return await _municipioServico.SelecionarPorEstado(id);
        }

        /// <summary>
        /// Cria um novo município
        /// </summary>
        /// <param name="itemDTO">Novo município a ser criado</param>
        /// <returns>Município criado</returns>
        [HttpPost]
        [Route("inserir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<Municipio>> Inserir(MunicipioDTO itemDTO)
        {
            if (await _municipioServico.ExistePorNome(itemDTO.Nome))
            {
                return NotFound("Não foi possível realizar a solicitação: Município já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _municipioServico.Inserir(item);
            itemDTO = item.AsDTO();

            return CreatedAtAction("SelecionarPorId", new { id = itemDTO.Id }, itemDTO);
        }

        /// <summary>
        /// Atualiza um município
        /// </summary>
        /// <param name="itemDTO">Município a ser atualizado</param>
        /// <returns>Mensagem de resposta OK</returns>
        [HttpPut]
        [Route("atualizar")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> Atualizar(MunicipioDTO itemDTO)
        {
            if (await _municipioServico.ExistePorNome(itemDTO.Nome, (long)itemDTO.Id))
            {
                return BadRequest("Não foi possível realizar a solicitação: Município já cadastrado.");
            }

            var item = itemDTO.AsEntitie();
            await _municipioServico.Atualizar(item);
            return Ok("Solicitação realizada com sucesso.");
        }

        /// <summary>
        /// Exclui um município
        /// </summary>
        /// <param name="id">Identificador único do município a ser excluído</param>
        /// <returns>Mensagem de resposta OK</returns>
        [HttpDelete]
        [Route("excluir")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult<Municipio>> Excluir(long id)
        {
            var item = await _municipioServico.SelecionarPorId(id);

            if (item == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            await _municipioServico.Excluir(item);
            return Ok("Solicitação realizada com sucesso.");
        }
    }
}