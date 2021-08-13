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
    public class CadastroContatoController : ControllerBase
    {
        private readonly GCACContext _context;

        public CadastroContatoController(GCACContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CadastroContato>>> GetCadastroContato()
        {
            return await _context.CadastroContato.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CadastroContato>> GetCadastroContato(long id)
        {
            var cadastroContato = await _context.CadastroContato.FindAsync(id);

            if (cadastroContato == null)
            {
                return NotFound();
            }

            return cadastroContato;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCadastroContato(long id, CadastroContato cadastroContato)
        {
            if (id != cadastroContato.CadastroId)
            {
                return BadRequest();
            }

            _context.Entry(cadastroContato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadastroContatoExists(id))
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
        public async Task<ActionResult<CadastroContato>> PostCadastroContato(CadastroContato cadastroContato)
        {
            _context.CadastroContato.Add(cadastroContato);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CadastroContatoExists(cadastroContato.CadastroId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCadastroContato", new { id = cadastroContato.CadastroId }, cadastroContato);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CadastroContato>> DeleteCadastroContato(long id)
        {
            var cadastroContato = await _context.CadastroContato.FindAsync(id);
            if (cadastroContato == null)
            {
                return NotFound();
            }

            _context.CadastroContato.Remove(cadastroContato);
            await _context.SaveChangesAsync();

            return cadastroContato;
        }

        private bool CadastroContatoExists(long id)
        {
            return _context.CadastroContato.Any(e => e.CadastroId == id);
        }
    }
}