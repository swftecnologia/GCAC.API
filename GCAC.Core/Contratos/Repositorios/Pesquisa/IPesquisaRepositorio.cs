using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.DTOs.Pesquisa;

namespace GCAC.Core.Contratos.Repositorios.Pesquisa
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPesquisaRepositorio
    {
        /// <summary>
        /// Realiza a pesquisa
        /// </summary>
        /// <param name="itemDTO">Pesquisa</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<IEnumerable<PesquisaDTO>> Pesquisar(PesquisaDTO itemDTO);
    }
}
