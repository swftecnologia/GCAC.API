using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.DTOs.InstrumentoColetivo;

namespace GCAC.Core.Extensions.InstrumentoColetivo
{
    /// <summary>
    /// Métodos extensivos da entidade EntidadeSindical
    /// </summary>
    public static class EntidadeSindicalExtension
    {
        /// <summary>
        /// Converte o DTO EntidadeSindicalDTO na entidade EntidadeSindical
        /// </summary>
        /// <param name="item">Entidade sindical a ser convertida</param>
        /// <returns></returns>
        public static EntidadeSindical AsEntitie(this EntidadeSindicalDTO item)
        {
            return new EntidadeSindical
            {
                Id = item.Id == null ? 0 : (long)item.Id,
                CNPJ = item.CNPJ,
                RazaoSocial = item.RazaoSocial,
                Sigla = item.Sigla,
                Denominacao = item.Denominacao,
                Grau = item.Grau,
                Abrangencia = item.Abrangencia,
                Grupo = item.Grupo,
                Categoria = item.Categoria,
                Logradouro = item.Logradouro,
                Complemento = item.Complemento,
                Numero = item.Numero,
                Bairro = item.Bairro,
                CEP = item.CEP,
                EstadoId = item.EstadoId,
                MunicipioId = item.MunicipioId,
                Email = item.Email,
                Telefone1 = item.Telefone1,
                Telefone2 = item.Telefone2,
                NomePresidente = item.NomePresidente,
                Regiao = item.Regiao
            };
        }

        /// <summary>
        /// Converte a entidade EntidadeSindical no DTO EntidadeSindicalDTO
        /// </summary>
        /// <param name="item">Região a ser convertida</param>
        /// <returns></returns>
        public static EntidadeSindicalDTO AsDTO(this EntidadeSindical item)
        {
            return new EntidadeSindicalDTO
            {
                Id = item.Id,
                CNPJ = item.CNPJ,
                RazaoSocial = item.RazaoSocial,
                Sigla = item.Sigla,
                Denominacao = item.Denominacao,
                Grau = item.Grau,
                Abrangencia = item.Abrangencia,
                Grupo = item.Grupo,
                Categoria = item.Categoria,
                Logradouro = item.Logradouro,
                Complemento = item.Complemento,
                Numero = item.Numero,
                Bairro = item.Bairro,
                CEP = item.CEP,
                EstadoId = item.EstadoId,
                MunicipioId = item.MunicipioId,
                Email = item.Email,
                Telefone1 = item.Telefone1,
                Telefone2 = item.Telefone2,
                NomePresidente = item.NomePresidente,
                Regiao = item.Regiao
            };
        }
    }
}