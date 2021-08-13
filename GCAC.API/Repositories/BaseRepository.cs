using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.API.Data;
using GCAC.Infrastructure.Contextos;

namespace GCAC.API.Repositories
{
    /// <summary>
    /// Repositório genérico para operações de CRUD das entidades
    /// </summary>
    /// <typeparam name="T">Entidade</typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly Context _context;
        private DbSet<T> _entity = null;

        /// <summary>
        /// Construtor do repositório
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(Context context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        /// <summary>
        /// Lista todos os registros
        /// </summary>
        /// <returns>Lista de registros da entidade solicitada</returns>
        public async Task<IEnumerable<T>> ListarTodos()
        {
            return await _entity.ToListAsync();
        }
        //TODO: Criar listagem e seleção com include genérico

        /// <summary>
        /// Lista todos os registros de acordo com os critérios de pesquisa informados
        /// </summary>
        /// <param name="criterios">Condições de pesquisa</param>
        /// <returns>Lista de registros da entidade solicitada</returns>
        public async Task<IEnumerable<T>> ListarComCriterios(List<(string Propriedade, object Valor, bool Igual, string Operador)> criterios)
        {
            var query = await PesquisarComCriterios(criterios);
            return _entity.Where(query);
        }

        /// <summary>
        /// Seleciona um registro pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único</param>
        /// <returns>Registro da entidade solicitada</returns>
        public async Task<T> SelecionarPorId(long id)
        {
            return await _entity.FindAsync(id);
        }

        /// <summary>
        /// Insere um registro
        /// </summary>
        /// <param name="item">Entidade</param>
        /// <returns>Quantidade de registros afetados pela operação para a entidade informada</returns>
        public async Task<int> Inserir(T item)
        {
            _context.ChangeTracker.Clear();
            _entity.Add(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza um registro
        /// </summary>
        /// <param name="item">Entidade</param>
        /// <returns>Quantidade de registros afetados pela operação para a entidade informada</returns>
        public async Task<int> Atualizar(T item)
        {
            _context.ChangeTracker.Clear();
            _entity.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Exclui um registro
        /// </summary>
        /// <param name="item">Entidade</param>
        /// <returns>Quantidade de registros afetados pela operação para a entidade informada</returns>
        public async Task<int> Excluir(T item)
        {
            _context.ChangeTracker.Clear();
            _entity.Remove(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Checa se a entidade existe
        /// </summary>
        /// <param name="id">Identificador único</param>
        /// <returns>Booleano indicando se a entidade existe</returns>
        public async Task<bool> Existe(long id)
        {
            T item = await _entity.FindAsync(id);
            return item == null ? false : true;
        }

        /// <summary>
        /// Checa se a entidade existe de acordo com os critérios de pesquisa informados
        /// </summary>
        /// <param name="criterios">Condições de pesquisa</param>
        /// <returns>Booleano indicando se a entidade existe</returns>
        public async Task<bool> ExisteComCriterios(List<(string Propriedade, object Valor, bool Igual, string Operador)> criterios)
        {
            var query = await PesquisarComCriterios(criterios);
            var resultado = _entity.Where(query);

            if (resultado.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Monta uma consulta LINQ dinâmica para uma entidade qualquer
        /// </summary>
        /// <param name="criterios">Condições de pesquisa</param>
        /// <returns>Consulta montada com critérios da entidade solicitada</returns>
        private async Task<Func<T, bool>> PesquisarComCriterios(List<(string Propriedade, object Valor, bool Igual, string Operador)> criterios)
        {
            var parametro = Expression.Parameter(typeof(T));
            Expression predicado = Expression.Constant(true);

            foreach (var criterio in criterios)
            {
                Expression propriedade = Expression.Property(parametro, criterio.Propriedade);
                Expression comparacao = Expression.Constant(true);

                if (criterio.Igual)
                {
                    comparacao = Expression.Equal(propriedade, Expression.Constant(criterio.Valor));
                }
                else
                {
                    comparacao = Expression.NotEqual(propriedade, Expression.Constant(criterio.Valor));
                }

                if (criterio.Operador == "OR")
                {
                    predicado = Expression.Or(predicado, comparacao);
                }
                else
                {
                    predicado = Expression.And(predicado, comparacao);
                }
            }

            var query = Expression.Lambda<Func<T, bool>>(predicado, parametro).Compile();
            return query;
        }
    }
}