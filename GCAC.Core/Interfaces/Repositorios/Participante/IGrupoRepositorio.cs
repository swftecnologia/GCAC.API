using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Participante;

namespace GCAC.Core.Interfaces.Repositorios.Participante
{
    /// <summary>
    /// Interface de repositório para a entidade Grupo
    /// </summary>
    public interface IGrupoRepositorio
    {
        /// <summary>
        /// Seleciona todos os grupos do participante
        /// </summary>
        /// <returns>Lista de grupos do participante</returns>
        Task<IEnumerable<Grupo>> SelecionarTodos();

        /// <summary>
        /// Seleciona um grupo do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do grupo do participante</param>
        /// <returns>Registro do grupo do participante solicitado</returns>
        Task<Grupo> SelecionarPorId(long id);

        /// <summary>
        /// Cria um novo grupo do participante
        /// </summary>
        /// <param name="item">Novo grupo do participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Inserir(Grupo item);

        /// <summary>
        /// Atualiza um grupo do participante
        /// </summary>
        /// <param name="item">Grupo do participante a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Atualizar(Grupo item);

        /// <summary>
        /// Exclui um grupo do participante
        /// </summary>
        /// <param name="item">Grupo do participante a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Excluir(Grupo item);

        /// <summary>
        /// Verifica se o grupo do participante existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do grupo do participante</param>
        /// <returns>Valor indicando se o grupo do participante existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao);

        /// <summary>
        /// Verifica se o grupo do participante existe por descrição para um identificador diferente do grupo do participante a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do grupo do participante</param>
        /// <param name="descricao">Descrição do grupo do participante</param>
        /// <returns>Valor indicando se o grupo do participante existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao, long id);
    }
}