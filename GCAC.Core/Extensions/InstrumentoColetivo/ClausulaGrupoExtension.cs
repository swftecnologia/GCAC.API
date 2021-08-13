using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.DTOs.InstrumentoColetivo;

namespace GCAC.Core.Extensions.InstrumentoColetivo
{
    /// <summary>
    /// Métodos extensivos da entidade ClausulaGrupo
    /// </summary>
    public static class ClausulaGrupoExtension
    {
        /// <summary>
        /// Converte o DTO ClausulaGrupoDTO na entidade ClausulaGrupo
        /// </summary>
        /// <param name="item">Grupo da cláusula a ser convertido</param>
        /// <returns></returns>
        public static ClausulaGrupo AsEntitie(this ClausulaGrupoDTO item)
        {
            return new ClausulaGrupo
            {
                Id = item.Id == null ? 0 : (long)item.Id,
                Ordem = item.Ordem,
                Descricao = item.Descricao
            };
        }

        /// <summary>
        /// Converte a entidade ClausulaGrupo no DTO ClausulaGrupoDTO
        /// </summary>
        /// <param name="item">Grupo da cláusula a ser convertido</param>
        /// <returns></returns>
        public static ClausulaGrupoDTO AsDTO(this ClausulaGrupo item)
        {
            return new ClausulaGrupoDTO
            {
                Id = item.Id,
                Ordem = item.Ordem,
                Descricao = item.Descricao
            };
        }
    }
}