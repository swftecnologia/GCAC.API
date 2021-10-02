using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.InstrumentoColetivo;

namespace GCAC.Core.Interfaces.Servicos.InstrumentoColetivo
{
    /// <summary>
    /// Interface de serviço para a entidade EntidadeSindical
    /// </summary>
    public interface IEntidadeSindicalServico
    {
        /// <summary>
        /// Seleciona todas as entidades sindicais
        /// </summary>
        /// <returns>Lista de entidades sindicais</returns>
        Task<IEnumerable<EntidadeSindical>> SelecionarTodos();

        /// <summary>
        /// Seleciona uma entidade sindical pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da entidade sindical</param>
        /// <returns>Registro da entidade sindical solicitada</returns>
        Task<EntidadeSindical> SelecionarPorId(long id);

        /// <summary>
        /// Cria uma nova entidade sindical
        /// </summary>
        /// <param name="item">Nova entidade sindical a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Inserir(EntidadeSindical item);

        /// <summary>
        /// Atualiza uma entidade sindical
        /// </summary>
        /// <param name="item">Entidade sindical a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Atualizar(EntidadeSindical item);

        /// <summary>
        /// Exclui uma entidade sindical
        /// </summary>
        /// <param name="item">Entidade sindical a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Excluir(EntidadeSindical item);

        /// <summary>
        /// Verifica se a entidade sindical existe por título
        /// </summary>
        /// <param name="cnpj">CNPJ da entidade sindical</param>
        /// <returns>Valor indicando se a entidade sindical existe ou não</returns>
        Task<bool> ExistePorCNPJ(string cnpj);

        /// <summary>
        /// Verifica se a entidade sindical existe por título para um identificador diferente da entidade sindical a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da entidade sindical</param>
        /// <param name="cnpj">CNPJ da entidade sindical</param>
        /// <returns>Valor indicando se a entidade sindical existe ou não</returns>
        Task<bool> ExistePorCNPJ(string cnpj, long id);
    }
}