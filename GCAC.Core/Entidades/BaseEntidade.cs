namespace GCAC.Core.Entidades
{
    /// <summary>
    /// Classe base das entidades
    /// </summary>
    public abstract record BaseEntidade
    {
        /// <summary>
        /// Identificador único da entidade (PK)
        /// </summary>
        public long Id { get; set; }
    }
}