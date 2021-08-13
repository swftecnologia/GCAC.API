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
    public class FuncaoController : ControllerBase
    {
        private readonly GCACContext _context;

        public FuncaoController(GCACContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcao>>> Get()
        {
            return await _context.Funcao.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Funcao>> Get(long id)
        {
            var funcao = await _context.Funcao.FindAsync(id);

            if (funcao == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return funcao;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Funcao funcao)
        {
            if (id != funcao.Id)
            {
                return BadRequest("Não foi possível realizar a solicitação: erro ao validar os dados enviados.");
            }
            else if (FuncaoExists(funcao.Id, funcao.Descricao))
            {
                return BadRequest("Não foi possível realizar a solicitação: registro duplicado.");
            }

            _context.Entry(funcao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncaoExists(id))
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
        public async Task<ActionResult<Funcao>> Post(Funcao funcao)
        {
            if (FuncaoExists(funcao.Descricao))
            {
                return BadRequest("Não foi possível realizar a solicitação: Função já cadastrada.");
            }
            else
            {
                _context.Funcao.Add(funcao);
                await _context.SaveChangesAsync();

                return CreatedAtAction("Get", new { id = funcao.Id }, funcao);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Funcao>> Delete(long id)
        {
            if (CadastroExists(id))
            {
                return BadRequest("Não foi possível realizar a solicitação: Função tem Cadastro(s) utilizado(s).");
            }

            var funcao = await _context.Funcao.FindAsync(id);
            
            if (funcao == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            _context.Funcao.Remove(funcao);
            await _context.SaveChangesAsync();

            return Ok("Solicitação realizada com sucesso.");
        }

        private bool FuncaoExists(long id)
        {
            return _context.Funcao.Any(f => f.Id == id);
        }

        private bool FuncaoExists(long id, string descricao)
        {
            return _context.Funcao.Any(f => f.Id != id && f.Descricao == descricao);
        }

        private bool FuncaoExists(string descricao)
        {
            return _context.Funcao.Any(f => f.Descricao == descricao);
        }

        private bool CadastroExists(long id)
        {
            return _context.Cadastro.Any(c => c.FuncaoId == id);
        }
    }
}