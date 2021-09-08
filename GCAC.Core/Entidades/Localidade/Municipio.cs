using GCAC.Core.Entidades.Participante;
using System.Collections.Generic;

namespace GCAC.Core.Entidades.Localidade
{
    /// <summary>
    /// Entidade para representar um município
    /// </summary>
    public record Municipio
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public Municipio()
        {
        }

        /// <summary>
        /// Identificador único do município (PK)
        /// </summary>
        public long Id { get; init; }
        
        /// <summary>
        /// Nome do município
        /// </summary>
        public string Nome { get; init; }

        /// <summary>
        /// Identificador único do estado ao qual o município pertence
        /// </summary>
        public long EstadoId { get; init; }

        // <summary>
        /// Relacionamento entre município do participante e participante
        // </summary>
        public virtual ICollection<Endereco> Endererecos { get; set; }
    }
}