using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Usuario;

namespace GCAC.Core.Contratos.Servicos.Usuario
{
    /// <summary>
    /// Interface de serviço para a entidade Conta
    /// </summary>
    public interface IContaServico
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Conta>> SelecionarTodos();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Conta> SelecionarPorId(long id);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<int> Inserir(Conta item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<int> Atualizar(Conta item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<int> Excluir(Conta item);
    }
}
