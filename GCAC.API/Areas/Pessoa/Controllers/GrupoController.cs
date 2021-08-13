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
    public class GrupoController : ControllerBase
    {
        private readonly GCACContext _context;

        public GrupoController(GCACContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grupo>>> Get()
        {
            return await _context.Grupo.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Grupo>> Get(long id)
        {
            var grupo = await _context.Grupo.FindAsync(id);

            if (grupo == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return grupo;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Grupo grupo)
        {
            if (id != grupo.Id)
            {
                return BadRequest("Não foi possível realizar a solicitação: erro ao validar os dados enviados.");
            }
            else if (GrupoExists(grupo.Id, grupo.Descricao))
            {
                return BadRequest("Não foi possível realizar a solicitação: registro duplicado.");
            }

            _context.Entry(grupo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoExists(id))
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
        public async Task<ActionResult<Grupo>> Post(Grupo grupo)
        {
            if (GrupoExists(grupo.Descricao))
            {
                return BadRequest("Não foi possível realizar a solicitação: Grupo já cadastrado.");
            }
            else
            {
                _context.Grupo.Add(grupo);
                await _context.SaveChangesAsync();

                return CreatedAtAction("Get", new { id = grupo.Id }, grupo);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Grupo>> Delete(long id)
        {
            if (CadastroExists(id))
            {
                return BadRequest("Não foi possível realizar a solicitação: Grupo tem Cadastro(s) utilizado(s).");
            }

            var grupo = await _context.Grupo.FindAsync(id);
            
            if (grupo == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            _context.Grupo.Remove(grupo);
            await _context.SaveChangesAsync();

            return Ok("Solicitação realizada com sucesso.");
        }

        private bool GrupoExists(long id)
        {
            return _context.Grupo.Any(g => g.Id == id);
        }

        private bool GrupoExists(long id, string descricao)
        {
            return _context.Grupo.Any(f => f.Id != id && f.Descricao == descricao);
        }

        private bool GrupoExists(string descricao)
        {
            return _context.Grupo.Any(g => g.Descricao == descricao);
        }

        private bool CadastroExists(long id)
        {
            return _context.Cadastro.Any(c => c.GrupoId == id);
        }
    }
}