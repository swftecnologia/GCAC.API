using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.DTOs.InstrumentoColetivo;

namespace GCAC.Core.Extensions.InstrumentoColetivo
{
    /// <summary>
    /// Métodos extensivos da entidade Categoria
    /// </summary>
    public static class CategoriaExtension
    {
        /// <summary>
        /// Converte o DTO CategoriaDTO na entidade Categoria
        /// </summary>
        /// <param name="item">Categoria a ser convertida</param>
        /// <returns></returns>
        public static Categoria AsEntitie(this CategoriaDTO item)
        {
            return new Categoria
            {
                Id = item.Id == null ? 0 : (long)item.Id,
                Descricao = item.Descricao
            };
        }

        /// <summary>
        /// Converte a entidade Categoria no DTO CategoriaDTO
        /// </summary>
        /// <param name="item">Categoria a ser convertida</param>
        /// <returns></returns>
        public static CategoriaDTO AsDTO(this Categoria item)
        {
            return new CategoriaDTO
            {
                Id = item.Id,
                Descricao = item.Descricao
            };
        }
    }
}