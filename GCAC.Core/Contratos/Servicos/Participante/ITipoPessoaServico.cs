using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Participante;

namespace GCAC.Core.Contratos.Servicos.Participante
{
    /// <summary>
    /// Interface de serviço para a entidade TipoPessoa
    /// </summary>
    public interface ITipoPessoaServico
    {
        /// <summary>
        /// Seleciona todos os tipos de pessoa do participante
        /// </summary>
        /// <returns>Lista de tipos de pessoa do participante</returns>
        Task<IEnumerable<TipoPessoa>> SelecionarTodos();

        /// <summary>
        /// Seleciona um tipo de pessoa do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do tipo de pessoa do participante</param>
        /// <returns>Registro do tipo de pessoa do participante solicitado</returns>
        Task<TipoPessoa> SelecionarPorId(long id);

        /// <summary>
        /// Cria um novo tipo de pessoa do participante
        /// </summary>
        /// <param name="item">Novo tipo de pessoa do participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Inserir(TipoPessoa item);

        /// <summary>
        /// Atualiza um tipo de pessoa do participante
        /// </summary>
        /// <param name="item">Tipo de pessoa do participante a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Atualizar(TipoPessoa item);

        /// <summary>
        /// Exclui um tipo de pessoa do participante
        /// </summary>
        /// <param name="item">Tipo de pessoa do participante a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Excluir(TipoPessoa item);

        /// <summary>
        /// Verifica se o tipo de pessoa do participante existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do tipo de pessoa do participante</param>
        /// <returns>Valor indicando se o tipo de pessoa do participante existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao);

        /// <summary>
        /// Verifica se o tipo de pessoa do participante existe por descrição para um identificador diferente do tipo de pessoa do participante a ser alterada
        /// </summary>
        /// <param name="id">Identificador único do tipo de pessoa do participante</param>
        /// <param name="descricao">Descrição do tipo de pessoa do participante</param>
        /// <returns>Valor indicando se o tipo de pessoa do participante existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao, long id);
    }
}