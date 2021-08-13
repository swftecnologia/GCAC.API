using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GCAC.API.Areas.InstrumentoColetivo.Entities;
using GCAC.API.Data;

namespace GCAC.API.Areas.InstrumentoColetivo.Controllers
{
    [Route("api/instrumento-coletivo/[controller]")]
    [ApiController]
    public class DocumentoRepresentanteController : ControllerBase
    {
        private readonly GCACContext _context;

        public DocumentoRepresentanteController(GCACContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentoRepresentante>>> GetDocumentoRepresentante()
        {
            return await _context.DocumentoRepresentante.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentoRepresentante>> GetDocumentoRepresentante(long id)
        {
            var documentoRepresentante = await _context.DocumentoRepresentante.FindAsync(id);

            if (documentoRepresentante == null)
            {
                return NotFound();
            }

            return documentoRepresentante;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentoRepresentante(long id, DocumentoRepresentante documentoRepresentante)
        {
            if (id != documentoRepresentante.DocumentoId)
            {
                return BadRequest();
            }

            _context.Entry(documentoRepresentante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentoRepresentanteExists(id))
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
        public async Task<ActionResult<DocumentoRepresentante>> PostDocumentoRepresentante(DocumentoRepresentante documentoRepresentante)
        {
            _context.DocumentoRepresentante.Add(documentoRepresentante);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DocumentoRepresentanteExists(documentoRepresentante.DocumentoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDocumentoRepresentante", new { id = documentoRepresentante.DocumentoId }, documentoRepresentante);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DocumentoRepresentante>> DeleteDocumentoRepresentante(long id)
        {
            var documentoRepresentante = await _context.DocumentoRepresentante.FindAsync(id);
            if (documentoRepresentante == null)
            {
                return NotFound();
            }

            _context.DocumentoRepresentante.Remove(documentoRepresentante);
            await _context.SaveChangesAsync();

            return documentoRepresentante;
        }

        private bool DocumentoRepresentanteExists(long id)
        {
            return _context.DocumentoRepresentante.Any(e => e.DocumentoId == id);
        }
    }
}