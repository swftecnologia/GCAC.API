using GCAC.Core.Entidades.Participante;
using GCAC.Core.Contratos.Repositorios.Participante;
using GCAC.Infrastructure.Contextos;

namespace GCAC.Infrastructure.Repositorios.Participante
{
    /// <summary>
    /// Repositório para a entidade AreaGeoeconomica
    /// </summary>
    public class AreaGeoeconomicaRepositorio : BaseRepositorio<AreaGeoeconomica>, IAreaGeoeconomicaRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public AreaGeoeconomicaRepositorio(Context context) : base(context)
        {
            _context = context;
        }
    }
}