using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Participante;

namespace GCAC.Core.Contratos.Servicos.Participante
{
    /// <summary>
    /// Interface de serviço para a entidade GrauEntidade
    /// </summary>
    public interface IGrauEntidadeServico
    {
        /// <summary>
        /// Seleciona todos os graus da entidade do participante
        /// </summary>
        /// <returns>Lista de graus da entidade do participante</returns>
        Task<IEnumerable<GrauEntidade>> SelecionarTodos();

        /// <summary>
        /// Seleciona um grau da entidade do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do grau da entidade do participante</param>
        /// <returns>Registro da grau da entidade do participante solicitada</returns>
        Task<GrauEntidade> SelecionarPorId(long id);

        /// <summary>
        /// Cria um novo grau da entidade do participante
        /// </summary>
        /// <param name="item">Novo grau da entidade do participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Inserir(GrauEntidade item);

        /// <summary>
        /// Atualiza um grau da entidade do participante
        /// </summary>
        /// <param name="item">Grau da entidade do participante a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Atualizar(GrauEntidade item);

        /// <summary>
        /// Exclui um grau da entidade do participante
        /// </summary>
        /// <param name="item">Grau da entidade do participante a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Excluir(GrauEntidade item);

        /// <summary>
        /// Verifica se o grau da entidade do participante existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do grau da entidade do participante</param>
        /// <returns>Valor indicando se o grau da entidade do participante existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao);

        /// <summary>
        /// Verifica se o grau da entidade do participante existe por descrição para um identificador diferente do grau da entidade do participante a ser alterada
        /// </summary>
        /// <param name="id">Identificador único do grau da entidade do participante</param>
        /// <param name="descricao">Descrição do grau da entidade do participante</param>
        /// <returns>Valor indicando se o grau da entidade do participante existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao, long id);
    }
}