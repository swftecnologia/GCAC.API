using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Participante;

namespace GCAC.Core.Interfaces.Servicos.Participante
{
    /// <summary>
    /// Interface de serviço para a entidade RepresentanteLegal
    /// </summary>
    public interface IRepresentanteLegalServico
    {
        /// <summary>
        /// Seleciona todos os representantes legais do participante
        /// </summary>
        /// <returns>Lista de representantes legais do participante</returns>
        Task<IEnumerable<RepresentanteLegal>> SelecionarTodos();

        /// <summary>
        /// Seleciona um representante legal do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do representante legal do participante</param>
        /// <returns>Registro do representante legal do participante solicitada</returns>
        Task<RepresentanteLegal> SelecionarPorId(long id);

        /// <summary>
        /// Cria um novo representante legal do participante
        /// </summary>
        /// <param name="item">Novo representante legal do participante a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Inserir(RepresentanteLegal item);

        /// <summary>
        /// Atualiza um representante legal do participante
        /// </summary>
        /// <param name="item">Representante legal do participante a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Atualizar(RepresentanteLegal item);

        /// <summary>
        /// Exclui um representante legal do participante
        /// </summary>
        /// <param name="item">Representante legal do participante a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Excluir(RepresentanteLegal item);

        /// <summary>
        /// Verifica se o representante legal do participante existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do representante legal do participante</param>
        /// <returns>Valor indicando se o representante legal do participante existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao);

        /// <summary>
        /// Verifica se o representante legal do participante existe por descrição para um identificador diferente do representante legal do participante a ser alterada
        /// </summary>
        /// <param name="id">Identificador único do representante legal do participante</param>
        /// <param name="descricao">Descrição do representante legal do participante</param>
        /// <returns>Valor indicando se o representante legal do participante existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao, long id);
    }
}