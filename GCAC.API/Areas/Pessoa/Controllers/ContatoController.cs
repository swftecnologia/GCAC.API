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
    public class ContatoController : ControllerBase
    {
        private readonly GCACContext _context;

        public ContatoController(GCACContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contato>>> Get()
        {
            return await _context.Contato.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contato>> Get(long id)
        {
            var contato = await _context.Contato.FindAsync(id);

            if (contato == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return contato;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Contato contato)
        {
            if (id != contato.Id)
            {
                return BadRequest("Não foi possível realizar a solicitação: erro ao validar os dados enviados.");
            }
            else if (ContatoExists(contato.Id, contato.Descricao))
            {
                return BadRequest("Não foi possível realizar a solicitação: registro duplicado.");
            }

            _context.Entry(contato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContatoExists(id))
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
        public async Task<ActionResult<Contato>> Post(Contato contato)
        {
            if (ContatoExists(contato.Descricao))
            {
                return BadRequest("Não foi possível realizar a solicitação: Contato já cadastrado.");
            }
            else
            {
                _context.Contato.Add(contato);
                await _context.SaveChangesAsync();

                return CreatedAtAction("Get", new { id = contato.Id }, contato);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Contato>> Delete(long id)
        {
            if (CadastroExists(id))
            {
                return BadRequest("Não foi possível realizar a solicitação: Contato tem Cadastro(s) utilizado(s).");
            }

            var contato = await _context.Contato.FindAsync(id);

            if (contato == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            _context.Contato.Remove(contato);
            await _context.SaveChangesAsync();

            return Ok("Solicitação realizada com sucesso.");
        }

        private bool ContatoExists(long id)
        {
            return _context.Contato.Any(c => c.Id == id);
        }

        private bool ContatoExists(long id, string descricao)
        {
            return _context.Contato.Any(c => c.Id != id && c.Descricao == descricao);
        }

        private bool ContatoExists(string descricao)
        {
            return _context.Contato.Any(c => c.Descricao == descricao);
        }

        private bool CadastroExists(long id)
        {
            return _context.Cadastro.Any(c => c.CadastroContato.Any(cc => cc.ContatoId == id));
        }
    }
}