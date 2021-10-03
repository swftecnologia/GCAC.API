using System;

namespace GCAC.Core.Entidades.Integracao
{
    /// <summary>
    /// Entidade para representar uma entidade sindical do CNES
    /// </summary>
    public record EntidadeSindicalListaCategoriaCNES : BaseEntidade
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public EntidadeSindicalListaCategoriaCNES()
        {
        }

        /// <summary>
        /// CNPJ da entidade sindical do CNES
        /// </summary>
        public string CNPJ { get; set; }

        /// <summary>
        /// Base territorial da entidade sindical do CNES
        /// </summary>
        public string Categoria { get; set; }

        /// <summary>
        /// Data da criação da entidade sindical do CNES
        /// </summary>
        public DateTime? DataCriacao { get; set; }

        /// <summary>
        /// Data da atualização da entidade sindical do CNES
        /// </summary>
        public DateTime? DataAtualizacao { get; set; }
    }
}