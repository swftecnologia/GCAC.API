using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.DTOs.InstrumentoColetivo;

namespace GCAC.Core.Extensions.InstrumentoColetivo
{
    /// <summary>
    /// Métodos extensivos da entidade Documento
    /// </summary>
    public static class DocumentoExtension
    {
        /// <summary>
        /// Converte o DTO DocumentoDTO na entidade Documento
        /// </summary>
        /// <param name="item">Documento a ser convertido</param>
        /// <returns></returns>
        public static Documento AsEntitie(this DocumentoDTO item)
        {
            return new Documento
            {
                Id = item.Id == null ? 0 : (long)item.Id,
                VigenciaInicial = item.VigenciaInicial,
                VigenciaFinal = item.VigenciaFinal,
                DataBaseCategoria = item.DataBaseCategoria,
                ClassificacaoId = item.ClassificacaoId,
                ParticipanteId = item.ParticipanteId,
                AbrangenciaId = item.AbrangenciaId
            };
        }

        /// <summary>
        /// Converte a entidade Documento no DTO DocumentoDTO
        /// </summary>
        /// <param name="item">Documento a ser convertido</param>
        /// <returns></returns>
        public static DocumentoDTO AsDTO(this Documento item)
        {
            return new DocumentoDTO
            {
                Id = item.Id,
                VigenciaInicial = item.VigenciaInicial,
                VigenciaFinal = item.VigenciaFinal,
                DataBaseCategoria = item.DataBaseCategoria,
                ClassificacaoId = item.ClassificacaoId,
                ParticipanteId = item.ParticipanteId,
                AbrangenciaId = item.AbrangenciaId
            };
        }
    }
}