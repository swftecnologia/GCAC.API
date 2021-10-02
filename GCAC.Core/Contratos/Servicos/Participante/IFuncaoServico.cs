using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Participante;

namespace GCAC.Core.Contratos.Servicos.Participante
{
    /// <summary>
    /// Interface de serviço para a entidade Funcao
    /// </summary>
    public interface IFuncaoServico
    {
        /// <summary>
        /// Seleciona todas as funções do participante
        /// </summary>
        /// <returns>Lista de funções do participante</returns>
        Task<IEnumerable<Funcao>> SelecionarTodos();

        /// <summary>
        /// Seleciona uma função do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da função do participante</param>
        /// <returns>Registro da função do participante solicitada</returns>
        Task<Funcao> SelecionarPorId(long id);

        /// <summary>
        /// Cria uma nova função do participante
        /// </summary>
        /// <param name="item">Nova função do participante a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Inserir(Funcao item);

        /// <summary>
        /// Atualiza uma função do participante
        /// </summary>
        /// <param name="item">Função do participante a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Atualizar(Funcao item);

        /// <summary>
        /// Exclui uma função do participante
        /// </summary>
        /// <param name="item">Função do participante a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Excluir(Funcao item);

        /// <summary>
        /// Verifica se a função do participante existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição da função do participante</param>
        /// <returns>Valor indicando se a função do participante existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao);

        /// <summary>
        /// Verifica se a função do participante existe por descrição para um identificador diferente da função do participante a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da função do participante</param>
        /// <param name="descricao">Descrição da função do participante</param>
        /// <returns>Valor indicando se a função do participante existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao, long id);
    }
}