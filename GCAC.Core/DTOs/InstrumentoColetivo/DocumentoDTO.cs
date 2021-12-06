using System;

namespace GCAC.Core.DTOs.InstrumentoColetivo
{
    /// <summary>
    /// DTO para representar um documento de instrumento coletivo
    /// </summary>
    public record DocumentoDTO
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public DocumentoDTO()
        {
        }

        /// <summary>
        /// Identificador único do sub-grupo da cláusula (PK)
        /// </summary>
        public long? Id { get; init; }

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