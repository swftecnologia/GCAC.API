using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.DTOs.InstrumentoColetivo;

namespace GCAC.Core.Extensions.InstrumentoColetivo
{
    /// <summary>
    /// Métodos extensivos da entidade Clausula
    /// </summary>
    public static class ClausulaExtension
    {
        /// <summary>
        /// Converte o DTO ClausulaDTO na entidade Clausula
        /// </summary>
        /// <param name="item">Cláusula a ser convertida</param>
        /// <returns></returns>
        public static Clausula AsEntitie(this ClausulaDTO item)
        {
            return new Clausula
            {
                Id = item.Id == null ? 0 : (long)item.Id,
                VigenciaInicial = item.VigenciaInicial,
                VigenciaFinal = item.VigenciaFinal,
                VigenciaDiferenciada = item.VigenciaDiferenciada,
                Titulo = item.Titulo,
                Descricao = item.Descricao,
                ClausulaSubGrupoId = item.ClausulaSubGrupoId
            };
        }

        /// <summary>
        /// Converte a entidade Clausula no DTO ClausulaDTO
        /// </summary>
        /// <param name="item">Cláusula a ser convertida</param>
        /// <returns></returns>
        public static ClausulaDTO AsDTO(this Clausula item)
        {
            return new ClausulaDTO
            {
                Id = item.Id,
                VigenciaInicial = item.VigenciaInicial,
                VigenciaFinal = item.VigenciaFinal,
                VigenciaDiferenciada = item.VigenciaDiferenciada,
                Titulo = item.Titulo,
                Descricao = item.Descricao,
                ClausulaSubGrupoId = item.ClausulaSubGrupoId
            };
        }
    }
}