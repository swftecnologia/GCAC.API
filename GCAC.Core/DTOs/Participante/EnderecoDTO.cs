namespace GCAC.Core.DTOs.Participante
{
    /// <summary>
    /// Entidade para representar um endereço pertencente a um participante
    /// </summary>
    public record EnderecoDTO
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public EnderecoDTO()
        {
        }

        /// <summary>
        /// Identificador único do endereço do participante
        /// </summary>
        public long? Id { get; init; }

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
        /// Identificador único do município do participante
        /// </summary>
        public long? MunicipioId { get; init; }
    }
}