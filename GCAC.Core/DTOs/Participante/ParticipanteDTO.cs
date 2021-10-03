namespace GCAC.Core.DTOs.Participante
{
    /// <summary>
    /// Entidade para representar um participante
    /// </summary>
    public record ParticipanteDTO
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public ParticipanteDTO()
        {
        }

        /// <summary>
        /// Identificador único do participante (PK)
        /// </summary>
        public long? Id { get; init; }

        /// <summary>
        /// CNPJ do participante
        /// </summary>
        public string CNPJ { get; init; }

        /// <summary>
        /// Razão Social do participante
        /// </summary>
        public string RazaoSocial { get; init; }

        /// <summary>
        /// Matriz do participante
        /// </summary>
        public bool Matriz { get; init; }

        /// <summary>
        /// CNO do participante
        /// </summary>
        public string CNO { get; init; }

        /// <summary>
        /// CPF do participante
        /// </summary>
        public string CPF { get; init; }

        /// <summary>
        /// Nome do participante
        /// </summary>
        public string Nome { get; init; }

        /// <summary>
        /// CAEPF do participante
        /// </summary>
        public string CAEPF { get; init; }

        /// <summary>
        /// Participante matriz do participante
        /// </summary>
        public long? ParticipanteId { get; init; }

        /// <summary>
        /// Abrangência do participante
        /// </summary>
        public long? AbrangenciaId { get; init; }

        /// <summary>
        /// Área geoeconômica do participante
        /// </summary>
        public long? AreaGeoeconomicaId { get; init; }

        /// <summary>
        /// Tipo de pessoa do participante
        /// </summary>
        public long TipoPessoaId { get; init; }

        /// <summary>
        /// Grupo do participante
        /// </summary>
        public long? GrupoId { get; init; }

        /// <summary>
        /// Função do participante
        /// </summary>
        public long? FuncaoId { get; init; }

        /// <summary>
        /// Representante legal do participante
        /// </summary>
        public long? RepresentanteLegalId { get; init; }

        /// <summary>
        /// Grau da entidade do participante
        /// </summary>
        public long? GrauEntidadeId { get; init; }
    }
}