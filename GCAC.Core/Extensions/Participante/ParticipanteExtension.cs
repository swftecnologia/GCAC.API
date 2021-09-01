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
                Matriz = item.Matriz,
                CNO = item.CNO,
                CPF = item.CPF,
                Nome = item.Nome,
                CAEPF = item.CAEPF,
                CEP = item.CEP,
                Logradouro = item.Logradouro,
                Bairro = item.Bairro,
                Complemento = item.Complemento,
                Numero = item.Numero,
                MunicipioId = item.MunicipioId,
                ParticipanteId = item.ParticipanteId,
                TipoPessoaId = item.TipoPessoaId,
                GrupoId = item.GrupoId,
                FuncaoId = item.FuncaoId,
                RepresentanteLegalId = item.RepresentanteLegalId,
                GrauEntidadeId = item.GrauEntidadeId
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
                Matriz = item.Matriz,
                CNO = item.CNO,
                CPF = item.CPF,
                Nome = item.Nome,
                CAEPF = item.CAEPF,
                CEP = item.CEP,
                Logradouro = item.Logradouro,
                Bairro = item.Bairro,
                Complemento = item.Complemento,
                Numero = item.Numero,
                MunicipioId = item.MunicipioId,
                ParticipanteId = item.ParticipanteId,
                TipoPessoaId = item.TipoPessoaId,
                GrupoId = item.GrupoId,
                FuncaoId = item.FuncaoId,
                RepresentanteLegalId = item.RepresentanteLegalId,
                GrauEntidadeId = item.GrauEntidadeId
            };
        }
    }
}