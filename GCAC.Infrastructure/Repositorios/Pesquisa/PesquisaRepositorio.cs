using GCAC.Core.Contratos.Repositorios.Pesquisa;
using GCAC.Core.DTOs.Pesquisa;
using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Infrastructure.Contextos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCAC.Infrastructure.Repositorios.Pesquisa
{
    /// <summary>
    /// 
    /// </summary>
    public class PesquisaRepositorio : IPesquisaRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public PesquisaRepositorio(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemDTO"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PesquisaDTO>> Pesquisar(PesquisaDTO itemDTO)
        {
            IEnumerable<PesquisaDTO> pesquisaDTO = new List<PesquisaDTO>();
            IEnumerable<Documento> documentos = await _context.Documento.Where(x => itemDTO.ClassificacaoIds.Contains(x.ClassificacaoId)).ToListAsync();

            if (documentos != null && documentos.Count() > 0)
            {
                foreach (var documento in documentos)
                {
                    pesquisaDTO.Append(new PesquisaDTO()
                    {
                        ClassificacaoId = documento.ClassificacaoId,
                        VigenciaInicial = documento.VigenciaInicial,
                        VigenciaFinal = documento.VigenciaFinal,
                        DataBase = documento.DataBaseCategoria,
                        NumeroMTE = "",
                        MunicipioId = null,
                        ParticipanteId = null
                    });
                }
            }
            
            return pesquisaDTO;
        }
    }
}
