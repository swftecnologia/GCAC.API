using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Participante;
using GCAC.Core.Contratos.Repositorios.Participante;
using GCAC.Core.Contratos.Servicos.Participante;

namespace GCAC.Core.Servicos.Participante
{
    /// <summary>
    /// Serviços para a entidade TipoPessoa
    /// </summary>
    public class TipoPessoaServico : ITipoPessoaServico
    {
        /// <summary>
        /// Repositório da entidade TipoPessoa
        /// </summary>
        private readonly ITipoPessoaRepositorio _tipoPessoaRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="tipoPessoaRepositorio">Repositório da entidade TipoPessoa</param>
        public TipoPessoaServico(ITipoPessoaRepositorio tipoPessoaRepositorio)
        {
            _tipoPessoaRepositorio = tipoPessoaRepositorio;
        }

        /// <summary>
        /// Seleciona todos os tipos de pessoa do participante
        /// </summary>
        /// <returns>Lista de tipos de pessoa do participante</returns>
        public async Task<IEnumerable<TipoPessoa>> SelecionarTodos()
        {
            return await _tipoPessoaRepositorio.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um tipo de pessoa do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do tipo de pessoa do participante</param>
        /// <returns>Registro do tipo de pessoa do participante solicitado</returns>
        public async Task<TipoPessoa> SelecionarPorId(long id)
        {
            return await _tipoPessoaRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// Cria um novo tipo de pessoa do participante
        /// </summary>
        /// <param name="item">Novo tipo de pessoa do participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(TipoPessoa item)
        {
            return await _tipoPessoaRepositorio.Inserir(item);
        }

        /// <summary>
        /// Atualiza um tipo de pessoa do participante
        /// </summary>
        /// <param name="item">Tipo de pessoa do participante a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(TipoPessoa item)
        {
            return await _tipoPessoaRepositorio.Atualizar(item);
        }

        /// <summary>
        /// Exclui um tipo de pessoa do participante
        /// </summary>
        /// <param name="item">Tipo de pessoa do participante a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(TipoPessoa item)
        {
            return await _tipoPessoaRepositorio.Excluir(item);
        }

        /// <summary>
        /// Verifica se o tipo de pessoa do participante existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do tipo de pessoa do participante</param>
        /// <returns>Valor indicando se o tipo de pessoa do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _tipoPessoaRepositorio.ExistePorDescricao(descricao);
        }

        /// <summary>
        /// Verifica se o tipo de pessoa do participante existe por descrição para um identificador diferente do tipo de pessoa do participante a ser alterada
        /// </summary>
        /// <param name="id">Identificador único do tipo de pessoa do participante</param>
        /// <param name="descricao">Descrição do tipo de pessoa do participante</param>
        /// <returns>Valor indicando se o tipo de pessoa do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _tipoPessoaRepositorio.ExistePorDescricao(descricao, id);
        }
    }
}