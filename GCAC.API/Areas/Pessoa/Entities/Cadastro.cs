using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GCAC.API.Areas.InstrumentoColetivo.Entities;
using GCAC.API.Extensions;

namespace GCAC.API.Areas.Pessoa.Entities
{
    [Table("Cadastro", Schema = "Pessoa")]
    public partial class Cadastro
    {
        public Cadastro()
        {
            CadastroContato = new HashSet<CadastroContato>();
            //CadastroMunicipio = new HashSet<CadastroMunicipio>();
            //InverseCadastroNavigation = new HashSet<Cadastro>();
            //Documento = new HashSet<Documento>();
        }

        [Key]
        public long Id { get; set; }

        [Column(name: "CNPJ")]
        [RequiredIf(propriedade: "CNPJ")]
        [StringLengthIf(propriedade: "CNPJ", minimumLength: 14, maximumLength: 14)]
        public string CNPJ { get; set; }

        [RequiredIf(propriedade: "RazaoSocial")]
        [StringLengthIf(propriedade: "RazaoSocial", minimumLength: 2, maximumLength: 200)]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "A Matriz é obrigatória.")]
        public bool Matriz { get; set; }

        [Column(name: "CNO")]
        [StringLengthIf(propriedade: "CNO", minimumLength: 12, maximumLength: 12)]
        public string CNO { get; set; }

        [Column(name: "CPF")]
        [RequiredIf(propriedade: "CPF")]
        [StringLengthIf(propriedade: "CPF", minimumLength: 11, maximumLength: 11)]
        public string CPF { get; set; }

        [RequiredIf(propriedade: "Nome")]
        [StringLengthIf(propriedade: "Nome", minimumLength: 2, maximumLength: 200)]
        public string Nome { get; set; }

        [Column(name: "CAEPF")]
        [StringLengthIf(propriedade: "CAEPF", minimumLength: 14, maximumLength: 14)]
        public string CAEPF { get; set; }

        [Column(name: "CEP")]
        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [StringLength(maximumLength: 8, ErrorMessage = "O CEP deve conter exatamente {1} caracteres.", MinimumLength = 8)]
        public string CEP { get; set; }
        
        [Required(ErrorMessage = "O Logradouro é obrigatório.")]
        [StringLength(maximumLength: 200, ErrorMessage = "O Logradouro deve conter de {2} a {1} caracteres.", MinimumLength = 2)]
        public string Logradouro { get; set; }
        
        [Required(ErrorMessage = "O Bairro é obrigatório.")]
        [StringLength(maximumLength: 100, ErrorMessage = "O Bairro deve conter de {2} a {1} caracteres.", MinimumLength = 2)]
        public string Bairro { get; set; }

        [StringLengthIf(propriedade: "Complemento", minimumLength: 2, maximumLength: 50)]
        public string Complemento { get; set; }

        [StringLengthIf(propriedade: "Numero", minimumLength: 1, maximumLength: 10)]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O Estado é obrigatório.")]
        [Range(minimum: 1, maximum: long.MaxValue, ErrorMessage = "O Estado é obrigatório.")]
        public long EstadoId { get; set; }

        [Required(ErrorMessage = "O Município é obrigatório.")]
        [Range(minimum: 1, maximum: long.MaxValue, ErrorMessage = "O Município é obrigatório.")]
        public long MunicipioId { get; set; }

        public long? CadastroId { get; set; }

        [Required(ErrorMessage = "O Tipo é obrigatório.")]
        [Range(minimum: 1, maximum: long.MaxValue, ErrorMessage = "O Tipo é obrigatório.")]
        public long TipoId { get; set; }

        public long? GrupoId { get; set; }
        
        public long? FuncaoId { get; set; }

        public long? RepresentanteLegalId { get; set; }
        
        public long? GrauEntidadeId { get; set; }

        //[ForeignKey(name: nameof(CadastroId))]
        //[InverseProperty(property: nameof(Cadastro.InverseCadastroNavigation))]
        //public virtual Cadastro CadastroNavigation { get; set; }

        //[ForeignKey(name: nameof(EstadoId))]
        //[InverseProperty(property: "Cadastro")]
        //public virtual Estado Estado { get; set; }

        //[ForeignKey(name: nameof(MunicipioId))]
        //[InverseProperty(property: "Cadastro")]
        //public virtual Municipio Municipio { get; set; }

        [ForeignKey(name: nameof(FuncaoId))]
        [InverseProperty(property: "Cadastro")]
        public virtual Funcao Funcao { get; set; }
        
        [ForeignKey(name: nameof(GrauEntidadeId))]
        [InverseProperty(property: "Cadastro")]
        public virtual GrauEntidade GrauEntidade { get; set; }
        
        [ForeignKey(name: nameof(GrupoId))]
        [InverseProperty(property: "Cadastro")]
        public virtual Grupo Grupo { get; set; }
        
        [ForeignKey(name: nameof(RepresentanteLegalId))]
        [InverseProperty(property: "Cadastro")]
        public virtual RepresentanteLegal RepresentanteLegal { get; set; }
        
        [ForeignKey(name: nameof(TipoId))]
        [InverseProperty(property: "Cadastro")]
        public virtual Tipo Tipo { get; set; }
        public enum EnumTipo
        {
            Fisica = 1,
            Juridica = 2
        }

        [InverseProperty(property: "Cadastro")]
        public virtual ICollection<CadastroContato> CadastroContato { get; set; }
        
        //[InverseProperty(property: "Cadastro")]
        //public virtual ICollection<CadastroMunicipio> CadastroMunicipio { get; set; }

        //[InverseProperty("Cadastro")]
        //public virtual ICollection<Documento> Documento { get; set; }

        //[InverseProperty(property: "Cadastro")]
        //public virtual ICollection<DocumentoRepresentante> DocumentoRepresentante { get; set; }

        //[InverseProperty(property: "Cadastro")]
        //public virtual ICollection<DocumentoRepresentanteLegal> DocumentoRepresentanteLegal { get; set; }

        //[InverseProperty(property: nameof(Cadastro.CadastroNavigation))]
        //public virtual ICollection<Cadastro> InverseCadastroNavigation { get; set; }
    }
}