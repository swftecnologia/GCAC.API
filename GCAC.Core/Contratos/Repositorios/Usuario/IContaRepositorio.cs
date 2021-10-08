using System.Threading.Tasks;
using GCAC.Core.Entidades.Usuario;

namespace GCAC.Core.Contratos.Repositorios.Usuario
{
    /// <summary>
    /// Interface de repositório para a entidade Conta
    /// </summary>
    public interface IContaRepositorio : IBaseRepositorio<Conta>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="tokenAtivacao"></param>
        /// <returns></returns>
        Task<Conta> SelecionarPorEmailETokenAtivacao(string email, string tokenAtivacao);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        Task<Conta> SelecionarParaLogin(string email, string senha);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<Conta> SelecionarPorEmail(string email);
    }
}
