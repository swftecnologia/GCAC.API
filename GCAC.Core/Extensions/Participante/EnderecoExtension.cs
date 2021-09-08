using GCAC.Core.Entidades.Participante;
using GCAC.Core.DTOs.Participante;

namespace GCAC.Core.Extensions.Participante
{
    /// <summary>
    /// Métodos extensivos da entidade Endereco
    /// </summary>
    public static class EnderecoExtension
    {
        /// <summary>
        /// Converte o DTO EnderecoDTO na entidade Endereco
        /// </summary>
        /// <param name="item">Endereço do participante a ser convertido</param>
        /// <returns></returns>
        public static Endereco AsEntitie(this EnderecoDTO item)
        {
            return new Endereco
            {
                Id = item.Id == null ? 0 : (long)item.Id,
                CEP = item.CEP,
                Logradouro = item.Logradouro,
                Bairro = item.Bairro,
                Complemento = item.Complemento,
                Numero = item.Numero,
                Sede = item.Sede,
                MunicipioId = item.MunicipioId == null ? 0 : (long)item.MunicipioId,
                ParticipanteId = item.ParticipanteId == null ? 0 : (long)item.ParticipanteId
            };
        }

        /// <summary>
        /// Converte a entidade Endereco no DTO EnderecoDTO
        /// </summary>
        /// <param name="item">Endereço do participante a ser convertida</param>
        /// <returns></returns>
        public static EnderecoDTO AsDTO(this Endereco item)
        {
            return new EnderecoDTO
            {
                Id = item.Id,
                CEP = item.CEP,
                Logradouro = item.Logradouro,
                Bairro = item.Bairro,
                Complemento = item.Complemento,
                Numero = item.Numero,
                Sede = item.Sede,
                MunicipioId = item.MunicipioId,
                ParticipanteId = item.ParticipanteId
            };
        }
    }
}