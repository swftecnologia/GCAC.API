using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GCAC.API.Areas.Pessoa.Entities;
using GCAC.API.Data;

namespace GCAC.API.Areas.Pessoa.Controllers
{
    [Route("api/pessoa/[controller]")]
    [ApiController]
    public class CadastroMunicipioController : ControllerBase
    {
        private readonly GCACContext _context;

        public CadastroMunicipioController(GCACContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CadastroMunicipio>>> GetCadastroMunicipio()
        {
            return await _context.CadastroMunicipio.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CadastroMunicipio>> GetCadastroMunicipio(long id)
        {
            var cadastroMunicipio = await _context.CadastroMunicipio.FindAsync(id);

            if (cadastroMunicipio == null)
            {
                return NotFound();
            }

            return cadastroMunicipio;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCadastroMunicipio(long id, CadastroMunicipio cadastroMunicipio)
        {
            if (id != cadastroMunicipio.CadastroId)
            {
                return BadRequest();
            }

            _context.Entry(cadastroMunicipio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadastroMunicipioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CadastroMunicipio>> PostCadastroMunicipio(CadastroMunicipio cadastroMunicipio)
        {
            _context.CadastroMunicipio.Add(cadastroMunicipio);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CadastroMunicipioExists(cadastroMunicipio.CadastroId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCadastroMunicipio", new { id = cadastroMunicipio.CadastroId }, cadastroMunicipio);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CadastroMunicipio>> DeleteCadastroMunicipio(long id)
        {
            var cadastroMunicipio = await _context.CadastroMunicipio.FindAsync(id);
            if (cadastroMunicipio == null)
            {
                return NotFound();
            }

            _context.CadastroMunicipio.Remove(cadastroMunicipio);
            await _context.SaveChangesAsync();

            return cadastroMunicipio;
        }

        private bool CadastroMunicipioExists(long id)
        {
            return _context.CadastroMunicipio.Any(e => e.CadastroId == id);
        }
    }
}