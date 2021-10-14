using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCAC.Core.DTOs.Pesquisa
{
    /// <summary>
    /// 
    /// </summary>
    public class PesquisaDTO
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public PesquisaDTO()
        {
        }

        public long[] ClassificacaoIds { get; set; }
        public long ClassificacaoId { get; set; }
        public DateTime? VigenciaInicial { get; set; }
        public DateTime? VigenciaFinal { get; set; }
        public DateTime? DataBase { get; set; }
        public string NumeroMTE { get; set; }
        public long[] MunicipioId { get; set; }
        public long[] ParticipanteId { get; set; }
    }
}
