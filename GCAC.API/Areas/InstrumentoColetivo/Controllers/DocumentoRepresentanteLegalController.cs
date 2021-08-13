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
    public class DocumentoRepresentanteLegalController : ControllerBase
    {
        private readonly GCACContext _context;

        public DocumentoRepresentanteLegalController(GCACContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentoRepresentanteLegal>>> GetDocumentoRepresentanteLegal()
        {
            return await _context.DocumentoRepresentanteLegal.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentoRepresentanteLegal>> GetDocumentoRepresentanteLegal(long id)
        {
            var documentoRepresentanteLegal = await _context.DocumentoRepresentanteLegal.FindAsync(id);

            if (documentoRepresentanteLegal == null)
            {
                return NotFound();
            }

            return documentoRepresentanteLegal;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentoRepresentanteLegal(long id, DocumentoRepresentanteLegal documentoRepresentanteLegal)
        {
            if (id != documentoRepresentanteLegal.DocumentoId)
            {
                return BadRequest();
            }

            _context.Entry(documentoRepresentanteLegal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentoRepresentanteLegalExists(id))
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
        public async Task<ActionResult<DocumentoRepresentanteLegal>> PostDocumentoRepresentanteLegal(DocumentoRepresentanteLegal documentoRepresentanteLegal)
        {
            _context.DocumentoRepresentanteLegal.Add(documentoRepresentanteLegal);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DocumentoRepresentanteLegalExists(documentoRepresentanteLegal.DocumentoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDocumentoRepresentanteLegal", new { id = documentoRepresentanteLegal.DocumentoId }, documentoRepresentanteLegal);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DocumentoRepresentanteLegal>> DeleteDocumentoRepresentanteLegal(long id)
        {
            var documentoRepresentanteLegal = await _context.DocumentoRepresentanteLegal.FindAsync(id);
            if (documentoRepresentanteLegal == null)
            {
                return NotFound();
            }

            _context.DocumentoRepresentanteLegal.Remove(documentoRepresentanteLegal);
            await _context.SaveChangesAsync();

            return documentoRepresentanteLegal;
        }

        private bool DocumentoRepresentanteLegalExists(long id)
        {
            return _context.DocumentoRepresentanteLegal.Any(e => e.DocumentoId == id);
        }
    }
}