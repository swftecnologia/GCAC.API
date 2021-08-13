using System.Collections.Generic;
using System.Threading.Tasks;

namespace GCAC.API.Repositories
{
    public interface IEntityRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> ListarTodos();

        Task<TEntity> SelecionarPorId(long id);

        Task<IEnumerable<TEntity>> SelecionarPorCriterios(Dictionary<string, string> criterios);

        Task<TEntity> SelecionarPorTermo(string termo, string propriedade);

        Task<TEntity> SelecionarPorIdTermo(long id, string termo, string propriedade);

        Task<int> Inserir(TEntity item);

        Task<int> Atualizar(TEntity item);

        Task<int> Excluir(TEntity item);

        Task<bool> Existe(long id);

        Task<bool> ExistePorTermo(string termo, string propriedade);

        Task<bool> ExistePorIdTermo(long id, string termo, string propriedade);

        Task<bool> ExisteEntidadeRelacionada(long id, string propriedade);
    }
}