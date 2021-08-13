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
    public class RepresentanteLegalController : ControllerBase
    {
        private readonly GCACContext _context;

        public RepresentanteLegalController(GCACContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepresentanteLegal>>> Get()
        {
            return await _context.RepresentanteLegal.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RepresentanteLegal>> Get(long id)
        {
            var representanteLegal = await _context.RepresentanteLegal.FindAsync(id);

            if (representanteLegal == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return representanteLegal;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, RepresentanteLegal representanteLegal)
        {
            if (id != representanteLegal.Id)
            {
                return BadRequest("Não foi possível realizar a solicitação: erro ao validar os dados enviados.");
            }
            else if (RepresentanteLegalExists(representanteLegal.Id, representanteLegal.Descricao))
            {
                return BadRequest("Não foi possível realizar a solicitação: registro duplicado.");
            }

            _context.Entry(representanteLegal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepresentanteLegalExists(id))
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
        public async Task<ActionResult<RepresentanteLegal>> Post(RepresentanteLegal representanteLegal)
        {
            if (RepresentanteLegalExists(representanteLegal.Descricao))
            {
                return BadRequest("Não foi possível realizar a solicitação: Representante Legal já cadastrado.");
            }
            else
            {
                _context.RepresentanteLegal.Add(representanteLegal);
                await _context.SaveChangesAsync();

                return CreatedAtAction("Get", new { id = representanteLegal.Id }, representanteLegal);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RepresentanteLegal>> Delete(long id)
        {
            if (CadastroExists(id))
            {
                return BadRequest("Não foi possível realizar a solicitação: Representante Legal tem Cadastro(s) utilizado(s).");
            }

            var representanteLegal = await _context.RepresentanteLegal.FindAsync(id);
            
            if (representanteLegal == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            _context.RepresentanteLegal.Remove(representanteLegal);
            await _context.SaveChangesAsync();

            return Ok("Solicitação realizada com sucesso.");
        }

        private bool RepresentanteLegalExists(long id)
        {
            return _context.RepresentanteLegal.Any(rl => rl.Id == id);
        }

        private bool RepresentanteLegalExists(long id, string descricao)
        {
            return _context.RepresentanteLegal.Any(f => f.Id != id && f.Descricao == descricao);
        }

        private bool RepresentanteLegalExists(string descricao)
        {
            return _context.RepresentanteLegal.Any(rl => rl.Descricao == descricao);
        }

        private bool CadastroExists(long id)
        {
            return _context.Cadastro.Any(c => c.RepresentanteLegalId == id);
        }
    }
}