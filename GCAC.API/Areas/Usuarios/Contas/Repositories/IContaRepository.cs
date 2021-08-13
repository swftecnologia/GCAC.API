using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.API.Areas.Usuarios.Contas.Entities;

namespace GCAC.API.Areas.Usuarios.Contas.Repositories
{
    public interface IContaRepository
    {
        Task<IEnumerable<Conta>> List();

        Task<Conta> Get(long id);

        Task<Conta> Get(string email);

        Task<Conta> Get(string email, string tokenAtivacao);

        Task<Conta> GetForLogin(string email, string senha);

        Task<int> Create(Conta item);

        Task<int> Update(Conta item);

        Task<int> Delete(Conta item);
    }
}