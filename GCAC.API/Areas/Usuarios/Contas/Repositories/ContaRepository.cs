using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.API.Data;
using GCAC.API.Areas.Usuarios.Contas.Entities;

namespace GCAC.API.Areas.Usuarios.Contas.Repositories
{
    public class ContaRepository: IContaRepository
    {
        private readonly GCACContext _context;

        public ContaRepository(GCACContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Conta>> List()
        {
            return await _context.Conta.ToListAsync();
        }

        public async Task<Conta> Get(long id)
        {
            return await _context.Conta.Where(t => t.Id == id).SingleOrDefaultAsync();
        }

        public async Task<Conta> Get(string email, string tokenAtivacao)
        {
            return await _context.Conta.Where(t => t.Email.ToLower() == email.ToLower() && t.TokenAtivacao.ToString() == tokenAtivacao).SingleOrDefaultAsync();
        }

        public async Task<Conta> GetForLogin(string email, string senha)
        {
            return await _context.Conta.Where(t => t.Email.ToLower() == email.ToLower() && t.Senha == senha).SingleOrDefaultAsync();
        }

        public async Task<Conta> Get(string email)
        {
            return await _context.Conta.Where(t => t.Email.ToLower() == email.ToLower()).SingleOrDefaultAsync();
        }

        public async Task<int> Create(Conta item)
        {
            _context.Conta.Add(item);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Conta item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Conta item)
        {
            _context.Conta.Remove(item);
            return await _context.SaveChangesAsync();
        }
    }
}
