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
    public class TipoController : ControllerBase
    {
        private readonly GCACContext _context;

        public TipoController(GCACContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipo>>> Get()
        {
            return await _context.Tipo.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tipo>> Get(long id)
        {
            var tipo = await _context.Tipo.FindAsync(id);

            if (tipo == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return tipo;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Tipo tipo)
        {
            if (id != tipo.Id)
            {
                return BadRequest("Não foi possível realizar a solicitação: erro ao validar os dados enviados.");
            }
            else if (TipoExists(tipo.Id, tipo.Descricao))
            {
                return BadRequest("Não foi possível realizar a solicitação: registro duplicado.");
            }

            _context.Entry(tipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoExists(id))
                {
                    return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
                }
                else
                {
                    throw;
                }
            }

            return Ok("Solicitação realizada com sucesso.");
        }

        [HttpPost]
        public async Task<ActionResult<Tipo>> Post(Tipo tipo)
        {
            if (TipoExists(tipo.Descricao))
            {
                return BadRequest("Não foi possível realizar a solicitação: Tipo já cadastrado.");
            }
            else
            {
                _context.Tipo.Add(tipo);
                await _context.SaveChangesAsync();

                return CreatedAtAction("Get", new { id = tipo.Id }, tipo);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Tipo>> Delete(long id)
        {
            if (CadastroExists(id))
            {
                return BadRequest("Não foi possível realizar a solicitação: Tipo tem Cadastro(s) utilizado(s).");
            }

            var tipo = await _context.Tipo.FindAsync(id);

            if (tipo == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            _context.Tipo.Remove(tipo);
            await _context.SaveChangesAsync();

            return Ok("Solicitação realizada com sucesso.");
        }

        private bool TipoExists(long id)
        {
            return _context.Tipo.Any(t => t.Id == id);
        }

        private bool TipoExists(long id, string descricao)
        {
            return _context.Tipo.Any(f => f.Id != id && f.Descricao == descricao);
        }

        private bool TipoExists(string descricao)
        {
            return _context.Tipo.Any(t => t.Descricao == descricao);
        }

        private bool CadastroExists(long id)
        {
            return _context.Cadastro.Any(c => c.TipoId == id);
        }
    }
}