using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Contratos.Repositorios.Usuario;
using GCAC.Core.Contratos.Servicos.Usuario;
using GCAC.Core.Entidades.Usuario;

namespace GCAC.Core.Servicos.Usuario
{
    /// <summary>
    /// 
    /// </summary>
    public class ContaServico : IContaServico
    {
        /// <summary>
        /// Repositório da entidade Conta
        /// </summary>
        private readonly IContaRepositorio _contaRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="contaRepositorio">Repositório da entidade Conta</param>
        public ContaServico(IContaRepositorio contaRepositorio)
        {
            _contaRepositorio = contaRepositorio;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Conta>> SelecionarTodos()
        {
            return await _contaRepositorio.SelecionarTodos();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Conta> SelecionarPorId(long id)
        {
            return await _contaRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="tokenAtivacao"></param>
        /// <returns></returns>
        public async Task<Conta> SelecionarPorEmailETokenAtivacao(string email, string tokenAtivacao)
        {
            return await _contaRepositorio.SelecionarPorEmailETokenAtivacao(email, tokenAtivacao);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public async Task<Conta> SelecionarParaLogin(string email, string senha)
        {
            return await _contaRepositorio.SelecionarParaLogin(email, senha);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<Conta> SelecionarPorEmail(string email)
        {
            return await _contaRepositorio.SelecionarPorEmail(email);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> Inserir(Conta item)
        {
            return await _contaRepositorio.Inserir(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> Atualizar(Conta item)
        {
            return await _contaRepositorio.Atualizar(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> Excluir(Conta item)
        {
            return await _contaRepositorio.Excluir(item);
        }
    }
}
