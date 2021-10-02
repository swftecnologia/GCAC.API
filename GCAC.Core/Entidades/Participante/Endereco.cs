using GCAC.Core.Entidades.Localidade;

namespace GCAC.Core.Entidades.Participante
{
    /// <summary>
    /// Entidade para representar um endereço do participante
    /// </summary>
    public record Endereco : BaseEntidade
    {
        /// <summary>
        /// Construtor da entidade endereço do participante
        /// </summary>
        public Endereco()
        {
        }

        /// <summary>
        /// CEP do participante
        /// </summary>
        public string CEP { get; init; }

        /// <summary>
        /// Logradouro do participante
        /// </summary>
        public string Logradouro { get; init; }

        /// <summary>
        /// Bairro do participante
        /// </summary>
        public string Bairro { get; init; }

        /// <summary>
        /// Complemento do participante
        /// </summary>
        public string Complemento { get; init; }

        /// <summary>
        /// Numero do participante
        /// </summary>
        public string Numero { get; init; }

        /// <summary>
        /// Informa se o endereço cadastrado é o endereço sede do participante
        /// </summary>
        public bool Sede { get; init; }

        /// <summary>
        /// Identificador único do participante
        /// </summary>
        public long? ParticipanteId { get; init; }

        /// <summary>
        /// Participante
        /// </summary>
        public Participante Participante { get; init; }

        /// <summary>
        /// Identificador único do município do participante
        /// </summary>
        public long MunicipioId { get; init; }

        /// <summary>
        /// Município do participante
        /// </summary>
        public Municipio Municipio { get; init; }
    }
}