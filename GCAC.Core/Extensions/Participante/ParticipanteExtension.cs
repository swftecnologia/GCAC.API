using GCAC.Core.DTOs.Participante;

namespace GCAC.Core.Extensions.Participante
{
    /// <summary>
    /// Métodos extensivos da entidade Participante
    /// </summary>
    public static class ParticipanteExtension
    {
        /// <summary>
        /// Converte o DTO ParticipanteDTO na entidade Participante
        /// </summary>
        /// <param name="item">Participante a ser convertido</param>
        /// <returns></returns>
        public static Entidades.Participante.Participante AsEntitie(this ParticipanteDTO item)
        {
            return new Entidades.Participante.Participante
            {
                Id = item.Id == null ? 0 : (long)item.Id,
                CNPJ = item.CNPJ,
                RazaoSocial = item.RazaoSocial,
                CNO = item.CNO,
                CPF = item.CPF,
                Nome = item.Nome,
                CAEPF = item.CAEPF,
                EntidadeSindical = item.EntidadeSindical,
                ParticipanteId = item.ParticipanteId,
                AbrangenciaId = item.AbrangenciaId,
                AreaGeoeconomicaId = item.AreaGeoeconomicaId,
                FuncaoId = item.FuncaoId,
                GrauEntidadeId = item.GrauEntidadeId,
                GrupoId = item.GrupoId,
                RepresentanteLegalId = item.RepresentanteLegalId,
                TipoPessoaId = item.TipoPessoaId
            };
        }

        /// <summary>
        /// Converte a entidade Participante no DTO ParticipanteDTO
        /// </summary>
        /// <param name="item">Participante a ser convertido</param>
        /// <returns></returns>
        public static ParticipanteDTO AsDTO(this Entidades.Participante.Participante item)
        {
            return new ParticipanteDTO
            {
                Id = item.Id,
                CNPJ = item.CNPJ,
                RazaoSocial = item.RazaoSocial,
                CNO = item.CNO,
                CPF = item.CPF,
                Nome = item.Nome,
                CAEPF = item.CAEPF,
                EntidadeSindical = item.EntidadeSindical,
                ParticipanteId = item.ParticipanteId,
                AbrangenciaId = item.AbrangenciaId,
                AreaGeoeconomicaId = item.AreaGeoeconomicaId,
                FuncaoId = item.FuncaoId,
                GrauEntidadeId = item.GrauEntidadeId,
                GrupoId = item.GrupoId,
                RepresentanteLegalId = item.RepresentanteLegalId,                
                TipoPessoaId = item.TipoPessoaId
            };
        }
    }
}