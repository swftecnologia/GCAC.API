using GCAC.API.Areas.Pessoa.Entities;
using GCAC.Core.Entidades.InstrumentoColetivo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCAC.API.Areas.InstrumentoColetivo.Entities
{
    [Table("Documento", Schema = "InstrumentoColetivo")]
    public partial class Documento
    {
        public Documento()
        {
            //DocumentoCategoria = new HashSet<DocumentoCategoria>();
            //DocumentoRepresentante = new HashSet<DocumentoRepresentante>();
            //DocumentoRepresentanteLegal = new HashSet<DocumentoRepresentanteLegal>();
        }

        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "A Vigência Inicial é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime VigenciaInicial { get; set; }

        [Required(ErrorMessage = "A Vigência Final é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime VigenciaFinal { get; set; }

        [Required(ErrorMessage = "A Data-Base da Categoria é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataBaseCategoria { get; set; }

        [Required(ErrorMessage = "A Classificação é obrigatória.")]
        [Range(minimum: 1, maximum: long.MaxValue, ErrorMessage = "A Classificação é obrigatória.")]
        public long ClassificacaoId { get; set; }

        [Required(ErrorMessage = "O Solicitante é obrigatório.")]
        [Range(minimum: 1, maximum: long.MaxValue, ErrorMessage = "O Solicitante é obrigatório.")]
        public long CadastroId { get; set; }

        [Required(ErrorMessage = "A Abrangência é obrigatória.")]
        [Range(minimum: 1, maximum: long.MaxValue, ErrorMessage = "A Abrangência é obrigatória.")]
        public long AbrangenciaId { get; set; }

        //[ForeignKey(nameof(ClassificacaoId))]
        //[InverseProperty("Documento")]
        //public virtual Classificacao Classificacao { get; set; }

        //[ForeignKey(nameof(CadastroId))]
        //[InverseProperty("Documento")]
        //public virtual Cadastro Cadastro { get; set; }

        //[ForeignKey(nameof(AbrangenciaId))]
        //[InverseProperty("Documento")]
        //public virtual Abrangencia Abrangencia { get; set; }
        
        //[InverseProperty("Documento")]
        //public virtual ICollection<DocumentoCategoria> DocumentoCategoria { get; set; }
        
        //[InverseProperty("Documento")]
        //public virtual ICollection<DocumentoRepresentante> DocumentoRepresentante { get; set; }
        
        //[InverseProperty("Documento")]
        //public virtual ICollection<DocumentoRepresentanteLegal> DocumentoRepresentanteLegal { get; set; }
    }
}