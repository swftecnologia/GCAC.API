using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Integracao;

namespace GCAC.Core.Interfaces.Repositorios.Integracao
{
    /// <summary>
    /// Interface de repositório para uma entidade sindical do CNES
    /// </summary>
    public interface IEntidadeSindicalCNESRepositorio
    {
        /// <summary>
        /// Cria uma nova entidade sindical do CNES e/ou atualiza uma entidade sindical do CNES existente
        /// </summary>
        /// <param name="itens">Lista de novas entidades sindicais do CNES a serem criadas e/ou atualizadas</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> InserirOuAtualizar(List<EntidadeSindicalListaBaseTerritorialCNES> itens);

        /// <summary>
        /// Cria uma nova entidade sindical do CNES e/ou atualiza uma entidade sindical do CNES existente
        /// </summary>
        /// <param name="itens">Lista de novas entidades sindicais do CNES a serem criadas e/ou atualizadas</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> InserirOuAtualizar(List<EntidadeSindicalListaCategoriaCNES> itens);

        /// <summary>
        /// Cria uma nova entidade sindical do CNES e/ou atualiza uma entidade sindical do CNES existente
        /// </summary>
        /// <param name="itens">Lista de novas entidades sindicais do CNES a serem criadas e/ou atualizadas</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> InserirOuAtualizar(List<EntidadeSindicalListaGeralCNES> itens);
    }
}