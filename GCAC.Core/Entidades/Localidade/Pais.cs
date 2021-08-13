namespace GCAC.Core.Entidades.Localidade
{
    /// <summary>
    /// Entidade para representar um país
    /// </summary>
    public record Pais
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public Pais()
        {
        }

        /// <summary>
        /// Identificador único do país (PK)
        /// </summary>
        public long Id { get; init; }
        
        /// <summary>
        /// Sigla do país
        /// </summary>
        public string Sigla { get; init; }
        
        /// <summary>
        /// Nome do país
        /// </summary>
        public string Nome { get; init; }
    }
}