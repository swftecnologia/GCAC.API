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
    public class DocumentoCategoriaController : ControllerBase
    {
        private readonly GCACContext _context;

        public DocumentoCategoriaController(GCACContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentoCategoria>>> GetDocumentoCategoria()
        {
            return await _context.DocumentoCategoria.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentoCategoria>> GetDocumentoCategoria(long id)
        {
            var documentoCategoria = await _context.DocumentoCategoria.FindAsync(id);

            if (documentoCategoria == null)
            {
                return NotFound();
            }

            return documentoCategoria;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentoCategoria(long id, DocumentoCategoria documentoCategoria)
        {
            if (id != documentoCategoria.DocumentoId)
            {
                return BadRequest();
            }

            _context.Entry(documentoCategoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentoCategoriaExists(id))
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
        public async Task<ActionResult<DocumentoCategoria>> PostDocumentoCategoria(DocumentoCategoria documentoCategoria)
        {
            _context.DocumentoCategoria.Add(documentoCategoria);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DocumentoCategoriaExists(documentoCategoria.DocumentoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDocumentoCategoria", new { id = documentoCategoria.DocumentoId }, documentoCategoria);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DocumentoCategoria>> DeleteDocumentoCategoria(long id)
        {
            var documentoCategoria = await _context.DocumentoCategoria.FindAsync(id);
            if (documentoCategoria == null)
            {
                return NotFound();
            }

            _context.DocumentoCategoria.Remove(documentoCategoria);
            await _context.SaveChangesAsync();

            return documentoCategoria;
        }

        private bool DocumentoCategoriaExists(long id)
        {
            return _context.DocumentoCategoria.Any(e => e.DocumentoId == id);
        }
    }
}