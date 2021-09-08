using System.Collections.Generic;

namespace GCAC.Core.Entidades.Participante
{
    /// <summary>
    /// Entidade para representar um participante
    /// </summary>
    public record Participante : BaseEntidade
    {
        /// <summary>
        /// Construtor da entidade participante
        /// </summary>
        public Participante()
        {
        }

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
        /// Participante matriz do participante
        /// </summary>
        public Participante ParticipanteMatriz { get; init; }

        /// <summary>
        /// Abrangência do participante
        /// </summary>
        public long? AbrangenciaId { get; init; }

        /// <summary>
        /// Abrangência do participante
        /// </summary>
        public Abrangencia Abrangencia { get; init; }

        /// <summary>
        /// Área geoeconômica do participante
        /// </summary>
        public long? AreaGeoeconomicaId { get; init; }

        /// <summary>
        /// Área geoeconômica do participante
        /// </summary>
        public AreaGeoeconomica AreaGeoeconomica { get; init; }

        /// <summary>
        /// Função do participante
        /// </summary>
        public long? FuncaoId { get; init; }

        /// <summary>
        /// Função do participante
        /// </summary>
        public Funcao Funcao { get; init; }

        /// <summary>
        /// Grau da entidade do participante
        /// </summary>
        public long? GrauEntidadeId { get; init; }

        /// <summary>
        /// Grau da entidade do participante
        /// </summary>
        public GrauEntidade GrauEntidade { get; init; }

        /// <summary>
        /// Grupo do participante
        /// </summary>
        public long? GrupoId { get; init; }

        /// <summary>
        /// Grupo do participante
        /// </summary>
        public Grupo Grupo { get; init; }

        /// <summary>
        /// Representante legal do participante
        /// </summary>
        public long? RepresentanteLegalId { get; init; }

        /// <summary>
        /// Representante legal do participante
        /// </summary>
        public RepresentanteLegal RepresentanteLegal { get; init; }

        /// <summary>
        /// Tipo de pessoa do participante
        /// </summary>
        public long TipoPessoaId { get; init; }

        /// <summary>
        /// Tipo de pessoa do participante
        /// </summary>
        public TipoPessoa TipoPessoa { get; init; }

        // <summary>
        /// Relacionamento entre participante matriz e participante
        // </summary>
        public virtual ICollection<Participante> Participantes { get; init; }

        // <summary>
        /// Relacionamento entre abrangência territorial e participante que possui a abrangência territorial
        // </summary>
        public virtual ICollection<AbrangenciaTerritorial> AbrangenciasTerritoriais { get; init; }

        // <summary>
        /// Relacionamento entre contato e participante que possui o contato
        // </summary>
        public virtual ICollection<Contato> Contatos { get; init; }

        // <summary>
        /// Relacionamento entre endereço e participante que possui o endereço
        // </summary>
        public virtual ICollection<Endereco> Endererecos { get; init; }
    }
}