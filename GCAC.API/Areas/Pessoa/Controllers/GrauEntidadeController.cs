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
    public class GrauEntidadeController : ControllerBase
    {
        private readonly GCACContext _context;

        public GrauEntidadeController(GCACContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrauEntidade>>> Get()
        {
            return await _context.GrauEntidade.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GrauEntidade>> Get(long id)
        {
            var grauEntidade = await _context.GrauEntidade.FindAsync(id);

            if (grauEntidade == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return grauEntidade;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, GrauEntidade grauEntidade)
        {
            if (id != grauEntidade.Id)
            {
                return BadRequest("Não foi possível realizar a solicitação: erro ao validar os dados enviados.");
            }
            else if (GrauEntidadeExists(grauEntidade.Id, grauEntidade.Descricao))
            {
                return BadRequest("Não foi possível realizar a solicitação: registro duplicado.");
            }

            _context.Entry(grauEntidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrauEntidadeExists(id))
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
        public async Task<ActionResult<GrauEntidade>> Post(GrauEntidade grauEntidade)
        {
            if (GrauEntidadeExists(grauEntidade.Descricao))
            {
                return BadRequest("Não foi possível realizar a solicitação: Grau da Entidade já cadastrada.");
            }
            else
            {
                _context.GrauEntidade.Add(grauEntidade);
                await _context.SaveChangesAsync();

                return CreatedAtAction("Get", new { id = grauEntidade.Id }, grauEntidade);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GrauEntidade>> Delete(long id)
        {
            if (CadastroExists(id))
            {
                return BadRequest("Não foi possível realizar a solicitação: Grau de Entidade tem Cadastro(s) utilizado(s).");
            }

            var grauEntidade = await _context.GrauEntidade.FindAsync(id);
            
            if (grauEntidade == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            _context.GrauEntidade.Remove(grauEntidade);
            await _context.SaveChangesAsync();

            return Ok("Solicitação realizada com sucesso.");
        }

        private bool GrauEntidadeExists(long id)
        {
            return _context.GrauEntidade.Any(ge => ge.Id == id);
        }

        private bool GrauEntidadeExists(long id, string descricao)
        {
            return _context.GrauEntidade.Any(f => f.Id != id && f.Descricao == descricao);
        }

        private bool GrauEntidadeExists(string descricao)
        {
            return _context.GrauEntidade.Any(ge => ge.Descricao == descricao);
        }

        private bool CadastroExists(long id)
        {
            return _context.Cadastro.Any(c => c.GrauEntidadeId == id);
        }
    }
}