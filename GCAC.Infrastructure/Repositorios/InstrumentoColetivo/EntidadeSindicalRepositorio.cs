using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.Interfaces.Repositorios.InstrumentoColetivo;
using GCAC.Infrastructure.Contextos;

namespace GCAC.Infrastructure.Repositorios.InstrumentoColetivo
{
    /// <summary>
    /// Repositório para a entidade EntidadeSindical
    /// </summary>
    public class EntidadeSindicalRepositorio : IEntidadeSindicalRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public EntidadeSindicalRepositorio(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Seleciona todas as entidades sindicais
        /// </summary>
        /// <returns>Lista de entidades sindicais</returns>
        public async Task<IEnumerable<EntidadeSindical>> SelecionarTodos()
        {
            return await _context.EntidadeSindical.ToListAsync();
        }

        /// <summary>
        /// Seleciona uma entidade sindical pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da entidade sindical</param>
        /// <returns>Registro da entidade sindical solicitada</returns>
        public async Task<EntidadeSindical> SelecionarPorId(long id)
        {
            return await _context.EntidadeSindical.FindAsync(id);
        }

        /// <summary>
        /// Cria uma nova entidade sindical
        /// </summary>
        /// <param name="item">Nova entidade sindical a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(EntidadeSindical item)
        {
            _context.ChangeTracker.Clear();
            _context.EntidadeSindical.Add(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza uma entidade sindical
        /// </summary>
        /// <param name="item">Entidade sindical a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(EntidadeSindical item)
        {
            _context.ChangeTracker.Clear();
            _context.EntidadeSindical.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Exclui uma entidade sindical
        /// </summary>
        /// <param name="item">Entidade sindical a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(EntidadeSindical item)
        {
            _context.ChangeTracker.Clear();
            _context.EntidadeSindical.Remove(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Verifica se a entidade sindical existe por título
        /// </summary>
        /// <param name="cnpj">CNPJ da entidade sindical</param>
        /// <returns>Valor indicando se a entidade sindical existe ou não</returns>
        public async Task<bool> ExistePorCNPJ(string cnpj)
        {
            return await _context.EntidadeSindical.AnyAsync(entidadeSindical => entidadeSindical.CNPJ == cnpj);
        }

        /// <summary>
        /// Verifica se a entidade sindical existe por título para um identificador diferente da entidade sindical a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da entidade sindical</param>
        /// <param name="cnpj">CNPJ da entidade sindical</param>
        /// <returns>Valor indicando se a entidade sindical existe ou não</returns>
        public async Task<bool> ExistePorCNPJ(string cnpj, long id)
        {
            return await _context.EntidadeSindical.AnyAsync(entidadeSindical => entidadeSindical.CNPJ == cnpj && entidadeSindical.Id != id);
        }
    }
}