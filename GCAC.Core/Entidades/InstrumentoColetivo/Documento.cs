using System;

namespace GCAC.Core.Entidades.InstrumentoColetivo
{
    /// <summary>
    /// Entidade para representar um documento de instrumento coletivo
    /// </summary>
    public record Documento : BaseEntidade
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public Documento()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NumeroSolicitacaoRegistroMTE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? VigenciaInicial { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? VigenciaFinal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? DataBaseCategoria { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long ClassificacaoId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? ParticipanteId { get; set; }
    }
}