using System;

namespace GCAC.Core.Entidades.Integracao
{
    /// <summary>
    /// Entidade para representar uma entidade sindical do CNES
    /// </summary>
    public record EntidadeSindicalListaBaseTerritorialCNES : BaseEntidade
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public EntidadeSindicalListaBaseTerritorialCNES()
        {
        }

        /// <summary>
        /// CNPJ da entidade sindical do CNES
        /// </summary>
        public string CNPJ { get; set; }

        /// <summary>
        /// Base territorial da entidade sindical do CNES
        /// </summary>
        public string BaseTerritorial { get; set; }

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