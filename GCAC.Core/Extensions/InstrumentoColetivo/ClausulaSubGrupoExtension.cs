using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.DTOs.InstrumentoColetivo;

namespace GCAC.Core.Extensions.InstrumentoColetivo
{
    /// <summary>
    /// Métodos extensivos da entidade ClausulaSubGrupo
    /// </summary>
    public static class ClausulaSubGrupoExtension
    {
        /// <summary>
        /// Converte o DTO ClausulaSubGrupoDTO na entidade ClausulaSubGrupo
        /// </summary>
        /// <param name="item">Sub-Grupo do grupo da cláusula a ser convertida</param>
        /// <returns></returns>
        public static ClausulaSubGrupo AsEntitie(this ClausulaSubGrupoDTO item)
        {
            return new ClausulaSubGrupo
            {
                Id = item.Id == null ? 0 : (long)item.Id,
                Ordem = item.Ordem,
                Descricao = item.Descricao,
                ClausulaGrupoId = item.ClausulaGrupoId
            };
        }

        /// <summary>
        /// Converte a entidade ClausulaSubGrupo no DTO ClausulaSubGrupoDTO
        /// </summary>
        /// <param name="item">Sub-Grupo do grupo da cláusula a ser convertida</param>
        /// <returns></returns>
        public static ClausulaSubGrupoDTO AsDTO(this ClausulaSubGrupo item)
        {
            return new ClausulaSubGrupoDTO
            {
                Id = item.Id,
                Ordem = item.Ordem,
                Descricao = item.Descricao,
                ClausulaGrupoId = item.ClausulaGrupoId
            };
        }
    }
}