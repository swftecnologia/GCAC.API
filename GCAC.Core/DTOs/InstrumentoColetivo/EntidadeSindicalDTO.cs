namespace GCAC.Core.DTOs.InstrumentoColetivo
{
    /// <summary>
    /// DTO para representar uma entidade sindical
    /// </summary>
    public record EntidadeSindicalDTO
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public EntidadeSindicalDTO()
        {
        }

        /// <summary>
        /// Identificador único da entidade sindical (PK)
        /// </summary>
        public long? Id { get; init; }

        /// <summary>
        /// CNPJ da entidade sindical
        /// </summary>
        public string CNPJ { get; init; }

        /// <summary>
        /// Razão Social da entidade sindical
        /// </summary>
        public string RazaoSocial { get; init; }

        /// <summary>
        /// Sigla da entidade sindical
        /// </summary>
        public string Sigla { get; init; }

        /// <summary>
        /// Denominação da entidade sindical
        /// </summary>
        public string Denominacao { get; init; }

        /// <summary>
        /// Grau da entidade sindical
        /// </summary>
        public string Grau { get; init; }

        /// <summary>
        /// Abrangência da entidade sindical
        /// </summary>
        public string Abrangencia { get; init; }

        /// <summary>
        /// Grupo da entidade sindical
        /// </summary>
        public string Grupo { get; init; }

        /// <summary>
        /// Categoria da entidade sindical
        /// </summary>
        public string Categoria { get; init; }

        /// <summary>
        /// Logradouro da entidade sindical
        /// </summary>
        public string Logradouro { get; init; }

        /// <summary>
        /// Complemento da entidade sindical
        /// </summary>
        public string Complemento { get; init; }

        /// <summary>
        /// Número da entidade sindical
        /// </summary>
        public string Numero { get; init; }

        /// <summary>
        /// Bairro da entidade sindical
        /// </summary>
        public string Bairro { get; init; }

        /// <summary>
        /// CEP da entidade sindical
        /// </summary>
        public string CEP { get; init; }

        /// <summary>
        /// Identificador único do estado ao qual a entidade sindical pertence
        /// </summary>
        public long EstadoId { get; init; }

        /// <summary>
        /// Identificador único do município ao qual a entidade sindical pertence
        /// </summary>
        public long MunicipioId { get; init; }

        /// <summary>
        /// E-mail da entidade sindical
        /// </summary>
        public string Email { get; init; }

        /// <summary>
        /// Telefone 1 da entidade sindical
        /// </summary>
        public string Telefone1 { get; init; }

        /// <summary>
        /// Telefone 2 da entidade sindical
        /// </summary>
        public string Telefone2 { get; init; }

        /// <summary>
        /// Nome do presidente da entidade sindical
        /// </summary>
        public string NomePresidente { get; init; }

        /// <summary>
        /// Região da entidade sindical
        /// </summary>
        public string Regiao { get; init; }
    }
}