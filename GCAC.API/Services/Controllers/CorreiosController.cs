using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CorreiosService;
using GCAC.Infrastructure.Contextos;
using GCAC.Core.Interfaces.Servicos.Localidade;

namespace GCAC.API.Services.Controllers
{
    /// <summary>
    /// Controlador para acessar a api dos correios
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/services/[controller]")]
    public class CorreiosController : ControllerBase
    {
        private readonly IEstadoServico _estadoServico;
        private readonly IMunicipioServico _municipioServico;

        /// <summary>
        /// Construtor do controlador
        /// </summary>
        /// <param name="estadoServico">Serviços da entidade Estado</param>
        /// <param name="municipioServico">Serviços da entidade Municipio</param>
        public CorreiosController(IEstadoServico estadoServico, IMunicipioServico municipioServico)
        {
            _estadoServico = estadoServico;
            _municipioServico = municipioServico;
        }

        /// <summary>
        /// Seleciona um endereço pelo CEP
        /// </summary>
        /// <param name="cep">CEP do endereço solicitado</param>
        /// <returns>Endereço solicitado</returns>
        [HttpGet]
        [Route("selecionar-por-cep")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<consultaCEPResponse>> SelecionarPorCEP(string cep)
        {
            var correiosServico = new AtendeClienteClient();
            var endereco = await correiosServico.consultaCEPAsync(cep);
            //var estado = await _estadoServico.SelecionarPorSigla(endereco.@return.uf);
            //var municipio = estado != null ? await _municipioServico.SelecionarPorEstadoEMunicipio(estado.Id, endereco.@return.cidade) : null;
            var municipio = await _municipioServico.SelecionarPorEstadoEMunicipio(0, endereco.@return.cidade);

            //endereco.@return.uf = estado != null ? estado.Id.ToString() : endereco.@return.uf;
            endereco.@return.cidade = municipio != null ? municipio.Id.ToString() : endereco.@return.cidade;

            return endereco;
        }
    }
}