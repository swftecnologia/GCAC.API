namespace GCAC.Core.Entidades.Localidade
{
    /// <summary>
    /// Entidade para representar um estado
    /// </summary>
    public record Estado : BaseEntidade
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public Estado()
        {
        }

        /// <summary>
        /// Sigla do estado
        /// </summary>
        public string Sigla { get; init; }
        
        /// <summary>
        /// Nome do estado
        /// </summary>
        public string Nome { get; init; }

        /// <summary>
        /// Identificador único do país ao qual o estado pertence
        /// </summary>
        public long PaisId { get; init; }
        
        /// <summary>
        /// País ao qual o estado pertence
        /// </summary>
        public Pais Pais { get; init; }
    }
}