using System;

namespace GCAC.Core.Entidades.Integracao
{
    /// <summary>
    /// Entidade para representar uma entidade sindical do CNES
    /// </summary>
    public record EntidadeSindicalListaGeralCNES : BaseEntidade
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public EntidadeSindicalListaGeralCNES()
        {
        }

        /// <summary>
        /// Razão Social da entidade sindical do CNES
        /// </summary>
        public string RazaoSocial { get; set; }

        /// <summary>
        /// CNPJ da entidade sindical do CNES
        /// </summary>
        public string CNPJ { get; set; }

        /// <summary>
        /// Grau da entidade sindical do CNES
        /// </summary>
        public string Grau { get; set; }

        /// <summary>
        /// Grupo da entidade sindical do CNES
        /// </summary>
        public string Grupo { get; set; }

        /// <summary>
        /// Área geoeconômica da entidade sindical do CNES
        /// </summary>
        public string AreaGeoeconomica { get; set; }

        /// <summary>
        /// Abrangência da entidade sindical do CNES
        /// </summary>
        public string Abrangencia { get; set; }

        /// <summary>
        /// UF da sede da entidade sindical do CNES
        /// </summary>
        public string UFSede { get; set; }

        /// <summary>
        /// Localidade da sede da entidade sindical do CNES
        /// </summary>
        public string LocalidadeSede { get; set; }

        /// <summary>
        /// Bairro da entidade sindical do CNES
        /// </summary>
        public string Bairro { get; set; }

        /// <summary>
        /// Logradouro da entidade sindical do CNES
        /// </summary>
        public string Logradouro { get; set; }

        /// <summary>
        /// Número da entidade sindical do CNES
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Data da criação da entidade sindical do CNES
        /// </summary>
        public DateTime? DataCriacao { get; set; }

        /// <summary>
        /// Data da atualização da entidade sindical do CNES
        /// </summary>
        public DateTime? DataAtualizacao { get; set; }
    }
}