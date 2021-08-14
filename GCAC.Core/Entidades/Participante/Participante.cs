﻿namespace GCAC.Core.Entidades.Participante
{
    /// <summary>
    /// Entidade para representar um participante
    /// </summary>
    public record Participante
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public Participante()
        {
        }

        /// <summary>
        /// Identificador único do participante (PK)
        /// </summary>
        public long Id { get; init; }

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
        /// Estado do participante
        /// </summary>
        public long EstadoId { get; init; }

        /// <summary>
        /// Município do participante
        /// </summary>
        public long MunicipioId { get; init; }

        /// <summary>
        /// Participante matriz do participante
        /// </summary>
        public long? ParticipanteId { get; init; }

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