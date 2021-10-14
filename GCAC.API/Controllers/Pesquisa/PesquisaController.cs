using GCAC.Core.Contratos.Servicos.Pesquisa;
using GCAC.Core.DTOs.Pesquisa;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCAC.API.Controllers.Pesquisa
{
    /// <summary>
    /// Controlador para tratar a pesquisa
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/pesquisa/pesquisa")]
    public class PesquisaController : ControllerBase
    {
        private readonly IPesquisaServico _pesquisaServico;

        /// <summary>
        /// Construtor do controlador
        /// </summary>
        /// <param name="pesquisaServico">Serviços da entidade Pesquisa</param>
        public PesquisaController(IPesquisaServico pesquisaServico)
        {
            _pesquisaServico = pesquisaServico;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vigenciaInicial"></param>
        /// <param name="vigenciaFinal"></param>
        /// <param name="dataBase"></param>
        /// <param name="numeroMTE"></param>
        /// <param name="classificacaoIds"></param>
        /// <param name="municipioIds"></param>
        /// <param name="participanteIds"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("pesquisar")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<PesquisaDTO>> Pesquisar(DateTime? vigenciaInicial, DateTime? vigenciaFinal, DateTime? dataBase, string numeroMTE, [FromQuery] long[] classificacaoIds, [FromQuery] long[] municipioIds, [FromQuery] long[] participanteIds)
        {
            PesquisaDTO itemDTO = new PesquisaDTO();

            itemDTO.ClassificacaoIds = classificacaoIds;
            itemDTO.VigenciaInicial = vigenciaInicial;
            itemDTO.VigenciaFinal = vigenciaFinal;
            itemDTO.DataBase = dataBase;
            itemDTO.NumeroMTE = numeroMTE;
            itemDTO.MunicipioId = municipioIds;
            itemDTO.ParticipanteId = participanteIds;

            return await _pesquisaServico.Pesquisar(itemDTO);
        }
    }
}
