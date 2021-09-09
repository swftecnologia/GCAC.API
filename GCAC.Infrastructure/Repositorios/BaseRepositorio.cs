using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.Core.Contratos.Repositorios;
using GCAC.Infrastructure.Contextos;

namespace GCAC.Infrastructure.Repositorios
{
    /// <summary>
    /// Implementação de repositorio base
    /// </summary>
    public class BaseRepositorio<T> : IBaseRepositorio<T> where T : class
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;
        
        /// <summary>
        /// Tabela do banco de dados
        /// </summary>
        private DbSet<T> _table = null;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public BaseRepositorio(Context context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        /// <summary>
        /// Seleciona todos os registros
        /// </summary>
        /// <returns>Lista de registros</returns>
        public async Task<IEnumerable<T>> SelecionarTodos()
        {
            return await _table.ToListAsync();
        }

        /// <summary>
        /// Seleciona um registro pelo seu identificador único
        /// </summary>
        /// <param name="id">Identificador único</param>
        /// <returns>Registro solicitado</returns>
        public async Task<T> SelecionarPorId(long id)
        {
            return await _table.FindAsync(id);
        }

        /// <summary>
        /// Insere um novo registro
        /// </summary>
        /// <param name="item">Novo registro a ser inserido</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(T item)
        {
            _context.ChangeTracker.Clear();
            _table.Add(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza um registro existente
        /// </summary>
        /// <param name="item">Registro a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(T item)
        {
            _context.ChangeTracker.Clear();
            _table.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Exclui um registro existente
        /// </summary>
        /// <param name="item">Registro a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(T item)
        {
            _context.ChangeTracker.Clear();
            _table.Remove(item);
            return await _context.SaveChangesAsync();
        }
    }
}