using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Contratos.Repositorios.Pesquisa;
using GCAC.Core.Contratos.Servicos.Pesquisa;
using GCAC.Core.DTOs.Pesquisa;

namespace GCAC.Core.Servicos.Pesquisa
{
    /// <summary>
    /// 
    /// </summary>
    public class PesquisaServico : IPesquisaServico
    {
        /// <summary>
        /// Repositório da entidade Pesquisa
        /// </summary>
        private readonly IPesquisaRepositorio _pesquisaRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="pesquisaRepositorio">Repositório da entidade Pesquisa</param>
        public PesquisaServico(IPesquisaRepositorio pesquisaRepositorio)
        {
            _pesquisaRepositorio = pesquisaRepositorio;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemDTO"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PesquisaDTO>> Pesquisar(PesquisaDTO itemDTO)
        {
            return await _pesquisaRepositorio.Pesquisar(itemDTO);
        }
    }
}
