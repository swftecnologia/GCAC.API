using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.DTOs.Pesquisa;

namespace GCAC.Core.Contratos.Servicos.Pesquisa
{
    /// <summary>
    /// Interface de serviço para a entidade Pesquisa
    /// </summary>
    public interface IPesquisaServico
    {
        /// <summary>
        /// Realiza a pesquisa
        /// </summary>
        /// <param name="itemDTO">Pesquisa</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<IEnumerable<PesquisaDTO>> Pesquisar(PesquisaDTO itemDTO);
    }
}
