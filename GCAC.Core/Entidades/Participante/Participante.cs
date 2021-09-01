using GCAC.Core.Entidades.Localidade;
using System.Collections.Generic;

namespace GCAC.Core.Entidades.Participante
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
        /// Município do participante
        /// </summary>
        public long MunicipioId { get; init; }

        /// <summary>
        /// Município do participante
        /// </summary>
        public Municipio Municipio { get; init; }

        /// <summary>
        /// Participante matriz do participante
        /// </summary>
        public long? ParticipanteId { get; init; }

        /// <summary>
        /// Participante matriz do participante
        /// </summary>
        public Participante ParticipanteMatriz { get; init; }

        /// <summary>
        /// Tipo de pessoa do participante
        /// </summary>
        public long TipoPessoaId { get; init; }

        /// <summary>
        /// Grupo do participante
        /// </summary>
        public long? GrupoId { get; init; }

        /// <summary>
        /// Grupo do participante
        /// </summary>
        public Grupo Grupo { get; init; }

        /// <summary>
        /// Função do participante
        /// </summary>
        public long? FuncaoId { get; init; }

        /// <summary>
        /// Função do participante
        /// </summary>
        public Funcao Funcao { get; init; }

        /// <summary>
        /// Representante legal do participante
        /// </summary>
        public long? RepresentanteLegalId { get; init; }

        /// <summary>
        /// Representante legal do participante
        /// </summary>
        public RepresentanteLegal RepresentanteLegal { get; init; }

        /// <summary>
        /// Grau da entidade do participante
        /// </summary>
        public long? GrauEntidadeId { get; init; }

        /// <summary>
        /// Grau da entidade do participante
        /// </summary>
        public GrauEntidade GrauEntidade { get; init; }

        // <summary>
        /// Relacionamento entre participante matriz e participante
        // </summary>
        public virtual ICollection<Participante> Participantes { get; set; }

        // <summary>
        /// Relacionamento entre contato e participante que possui o contato
        // </summary>
        public virtual ICollection<Contato> Contatos { get; set; }
    }
}