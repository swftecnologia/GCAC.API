using GCAC.Core.Entidades.Participante;
using GCAC.Core.DTOs.Participante;

namespace GCAC.Core.Extensions.Participante
{
    /// <summary>
    /// Métodos extensivos da entidade AbrangenciaTerritorial
    /// </summary>
    public static class AbrangenciaTerritorialExtension
    {
        /// <summary>
        /// Converte o DTO AbrangenciaTerritorialDTO na entidade AbrangenciaTerritorial
        /// </summary>
        /// <param name="item">Abrangência territorial a ser convertida</param>
        /// <returns></returns>
        public static AbrangenciaTerritorial AsEntitie(this AbrangenciaTerritorialDTO item)
        {
            return new AbrangenciaTerritorial
            {
                ParticipanteId = item.ParticipanteId == null ? 0 : (long)item.ParticipanteId,
                MunicipioId = item.MunicipioId == null ? 0 : (long)item.MunicipioId
            };
        }

        /// <summary>
        /// Converte a entidade Territorial no DTO AbrangenciaTerritorialDTO
        /// </summary>
        /// <param name="item">Abrangência territorial a ser convertida</param>
        /// <returns></returns>
        public static AbrangenciaTerritorialDTO AsDTO(this AbrangenciaTerritorial item)
        {
            return new AbrangenciaTerritorialDTO
            {
                ParticipanteId = item.ParticipanteId,
                MunicipioId = item.MunicipioId
            };
        }
    }
}