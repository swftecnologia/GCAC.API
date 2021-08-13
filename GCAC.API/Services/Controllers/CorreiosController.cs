using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CorreiosService;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GCAC.Infrastructure.Contextos;

namespace GCAC.API.Services.Controllers
{
    [Route("api/services/[controller]")]
    [ApiController]
    public class CorreiosController : ControllerBase
    {
        private readonly Context _context;

        public CorreiosController(Context context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<consultaCEPResponse>> GetEndereco(string id)
        {
            var correiosServico = new AtendeClienteClient();
            var endereco = await correiosServico.consultaCEPAsync(id);
            var estado = await _context.Estado.Where(e => e.Sigla == endereco.@return.uf).FirstOrDefaultAsync();
            var municipio = estado != null ? await _context.Municipio.Where(m => m.EstadoId == estado.Id && m.Nome == endereco.@return.cidade).SingleOrDefaultAsync() : null;
            
            endereco.@return.uf = estado != null ? estado.Id.ToString() : endereco.@return.uf;
            endereco.@return.cidade = municipio != null ? municipio.Id.ToString() : endereco.@return.cidade;

            return endereco;
        }
    }
}