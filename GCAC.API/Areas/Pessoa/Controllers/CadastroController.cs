using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GCAC.API.Areas.Pessoa.Entities;
using GCAC.API.Data;
using GCAC.API.Enums;

namespace GCAC.API.Areas.Pessoa.Controllers
{
    [Route("api/pessoa/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly GCACContext _context;

        public CadastroController(GCACContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cadastro>>> Get()
        {
            return await _context.Cadastro
                //.Include(m => m.Estado)
                //.Include(m => m.Municipio)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cadastro>> Get(long id)
        {
            var cadastro = await _context.Cadastro
                .Include(c => c.Grupo)
                //.Include(m => m.Estado)
                //.Include(m => m.Municipio)
                .Where(c => c.Id == id)
                .SingleOrDefaultAsync();

            if (cadastro == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            return cadastro;
        }

        [Route("obter-cadastros-por-tipo")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cadastro>>> GetByTipo(long id)
        {
            return await _context.Cadastro
                .Include(c => c.Tipo)
                .Include(c => c.Grupo)
                //.Include(c => c.CadastroNavigation)
                .Include(c => c.Funcao)
                .Include(c => c.RepresentanteLegal)
                .Include(c => c.GrauEntidade)
                //.Include(c => c.Estado)
                //.Include(c => c.Municipio)
                .Where(c => c.TipoId == id).ToListAsync();
        }

        [Route("obter-cadastros-por-grupo")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cadastro>>> GetByGrupo(long id)
        {
            return await _context.Cadastro
                .Include(c => c.Tipo)
                .Include(c => c.Grupo)
                //.Include(c => c.CadastroNavigation)
                .Include(c => c.Funcao)
                .Include(c => c.RepresentanteLegal)
                .Include(c => c.GrauEntidade)
                //.Include(c => c.Estado)
                //.Include(c => c.Municipio)
                .Where(c => c.GrupoId == id).ToListAsync();
        }

        [Route("obter-cadastros-por-cnpj-cei")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cadastro>>> GetByCNPJCEI()
        {
            return await _context.Cadastro
                .Include(c => c.Tipo)
                .Include(c => c.Grupo)
                //.Include(c => c.CadastroNavigation)
                .Include(c => c.Funcao)
                .Include(c => c.RepresentanteLegal)
                .Include(c => c.GrauEntidade)
                //.Include(c => c.Estado)
                //.Include(c => c.Municipio)
                .Where(c => ((!String.IsNullOrEmpty(c.CNPJ)) == true || (!String.IsNullOrEmpty(c.CNO) == true)) && c.GrupoId != null).ToListAsync();
        }

        [Route("obter-cadastros-por-tipo-representante-legal")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cadastro>>> GetByTipoRepresentanteLegal()
        {
            return await _context.Cadastro
                .Include(c => c.Tipo)
                .Include(c => c.Grupo)
                //.Include(c => c.CadastroNavigation)
                .Include(c => c.Funcao)
                .Include(c => c.RepresentanteLegal)
                .Include(c => c.GrauEntidade)
                //.Include(c => c.Estado)
                //.Include(c => c.Municipio)
                .Where(c => c.TipoId == 1 && (c.RepresentanteLegalId == 1 || c.RepresentanteLegalId == 2)).ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Cadastro cadastro)
        {
            if (id != cadastro.Id)
            {
                return BadRequest("Não foi possível realizar a solicitação: erro ao validar os dados enviados.");
            }
            else if (CadastroExists(cadastro.Id, cadastro.CNO, cadastro.CNPJ, cadastro.CPF))
            {
                return BadRequest("Não foi possível realizar a solicitação: registro duplicado.");
            }

            _context.Entry(cadastro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadastroExists(id))
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
        public async Task<ActionResult<Cadastro>> Post(Cadastro cadastro)
        {
            if (cadastro.TipoId == (int)Cadastro.EnumTipo.Fisica)
            {
                if (String.IsNullOrEmpty(cadastro.CPF))
                {
                    return BadRequest("O CPF é obrigatório.");
                }
                else if (String.IsNullOrEmpty(cadastro.Nome))
                {
                    return BadRequest("O Nome é obrigatório.");
                }
            }
            else if (cadastro.TipoId == (int)Cadastro.EnumTipo.Juridica)
            {
                if (String.IsNullOrEmpty(cadastro.CNPJ))
                {
                    return BadRequest("O CNPJ é obrigatório.");
                }
                if (String.IsNullOrEmpty(cadastro.RazaoSocial))
                {
                    return BadRequest("A Razão Social é obrigatória.");
                }
            }

            if (CadastroExists(cadastro.CNPJ, cadastro.CNO, cadastro.CPF, cadastro.CAEPF))
            {
                return BadRequest("Não foi possível realizar a solicitação: Cadastro existente.");
            }

            _context.Cadastro.Add(cadastro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = cadastro.Id }, cadastro);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cadastro>> Delete(long id)
        {
            var cadastro = await _context.Cadastro.FindAsync(id);

            if (cadastro == null)
            {
                return NotFound("Não foi possível realizar a solicitação: registro não encontrado.");
            }

            _context.Cadastro.Remove(cadastro);
            await _context.SaveChangesAsync();

            return Ok("Solicitação realizada com sucesso.");
        }

        private bool CadastroExists(long id)
        {
            return _context.Cadastro.Any(e => e.Id == id);
        }

        private bool CadastroExists(long id, string cno, string cnpj, string cpf)
        {
            return _context.Cadastro.Any(c => c.Id != id && ((c.CNO != null && c.CNO == cno) || (c.CNPJ != null && c.CNPJ == cnpj) || (c.CPF != null && c.CPF == cpf)));
        }

        private bool CadastroExists(string cnpj, string cno, string cpf, string caepf)
        {
            bool cadastroExiste = false;
            bool CNPJExiste = String.IsNullOrEmpty(cnpj) ? false : _context.Cadastro.Any(c => c.CNPJ == cnpj);
            bool CNOExiste = String.IsNullOrEmpty(cno) ? false : _context.Cadastro.Any(c => c.CNO == cno);
            bool CPFExiste = String.IsNullOrEmpty(cpf) ? false : _context.Cadastro.Any(c => c.CPF == cpf);
            bool CAEPFExiste = String.IsNullOrEmpty(caepf) ? false : _context.Cadastro.Any(c => c.CAEPF == caepf);
            
            if (CNPJExiste || CNOExiste || CPFExiste || CAEPFExiste)
            {
                cadastroExiste = true;
            }

            return cadastroExiste;
        }
    }
}