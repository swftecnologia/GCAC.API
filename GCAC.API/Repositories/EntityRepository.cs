using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.API.Data;
using System;
using System.Reflection;
using System.Text;
using System.Linq.Expressions;

namespace GCAC.API.Repositories
{
    public class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class
    {
        private readonly GCACContext _context;
        private DbSet<TEntity> _entity = null;

        public EntityRepository(GCACContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>();
        }

        /// <summary>
        /// Lista todos os registros
        /// </summary>
        /// <returns>Lista de itens da entidade solicitada</returns>
        public async Task<IEnumerable<TEntity>> ListarTodos()
        {
            return await _entity.ToListAsync();
        }

        /// <summary>
        /// Seleciona um registro
        /// </summary>
        /// <param name="id">Chave primária da entidade a ser selecionada</param>
        /// <returns>Item único da entidade solicitada</returns>
        public async Task<TEntity> SelecionarPorId(long id)
        {
            return await _entity.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> SelecionarPorCriterios(Dictionary<string, string> criterios)
        {
            var query = _entity.Select(q => q);
            
            foreach (var criterio in criterios)
            {
                PropertyInfo propriedade = typeof(TEntity).GetProperty(criterio.Key);

                if (propriedade != null)
                {
                    query = query.Where(q => q.GetType().GetProperty(propriedade.Name).GetValue(q).Equals(criterio.Value));
                }
            }

            //IEnumerable ls = query.ToList();
            //return Json(ls, JsonRequestBehavior.AllowGet);
            //return ListarTodos().Result.Where(l => l.GetType().GetProperty(propriedade).GetValue(l, null).Equals(termo)).SingleOrDefault();
            return await query.ToListAsync();
        }

        public async Task<TEntity> SelecionarPorTermo(string termo, string propriedade)
        {
            return ListarTodos().Result.Where(l => l.GetType().GetProperty(propriedade).GetValue(l, null).Equals(termo)).SingleOrDefault();
        }

        public async Task<TEntity> SelecionarPorIdTermo(long id, string termo, string propriedade)
        {
            return ListarTodos().Result.Where(l => l.GetType().GetProperty("Id").GetValue(l, null).Equals(termo) && l.GetType().GetProperty(propriedade).GetValue(l, null).Equals(termo)).SingleOrDefault();
        }

        /// <summary>
        /// Insere um registro
        /// </summary>
        /// <param name="item">Entidade a ser inserida</param>
        /// <returns>Quantidade de registros afetados pela operação para a entidade informada<</returns>
        public async Task<int> Inserir(TEntity item)
        {
            _entity.Add(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza um registro
        /// </summary>
        /// <param name="item">Entidade a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação para a entidade informada</returns>
        public async Task<int> Atualizar(TEntity item)
        {
            _entity.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Exclui um registro
        /// </summary>
        /// <param name="item">Entidade a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação para a entidade informada<</returns>
        public async Task<int> Excluir(TEntity item)
        {
            _entity.Remove(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Checa se a entidade existe
        /// </summary>
        /// <param name="id">Chave primária da entidade a ser verificada</param>
        /// <returns>Booleano indicando se a entidade existe</returns>
        public async Task<bool> Existe(long id)
        {
            TEntity item = await _entity.FindAsync(id);
            return item == null ? false : true;
        }

        public async Task<bool> ExistePorTermo(string termo, string propriedade)
        {
            return ListarTodos().Result.Any(l => l.GetType().GetProperty(propriedade).GetValue(l, null).Equals(termo));
        }

        public async Task<bool> ExistePorIdTermo(long id, string termo, string propriedade)
        {
            return ListarTodos().Result.Any(l => l.GetType().GetProperty("Id").GetValue(l, null).Equals(termo) && l.GetType().GetProperty(propriedade).GetValue(l, null).Equals(termo));
        }

        public async Task<bool> ExisteEntidadeRelacionada(long id, string propriedade)
        {
            throw new System.NotImplementedException();
        }
    }
}