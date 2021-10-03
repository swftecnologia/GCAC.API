using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.Core.Entidades.Participante;
using GCAC.Core.Contratos.Repositorios.Participante;
using GCAC.Infrastructure.Contextos;

namespace GCAC.Infrastructure.Repositorios.Participante
{
    /// <summary>
    /// Repositório para a entidade RepresentanteLegal
    /// </summary>
    public class RepresentanteLegalRepositorio : BaseRepositorio<RepresentanteLegal>, IRepresentanteLegalRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public RepresentanteLegalRepositorio(Context context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Verifica se o representante legal do participante existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do representante legal do participante</param>
        /// <returns>Valor indicando se o representante legal do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _context.RepresentanteLegal.AnyAsync(representanteLegal => representanteLegal.Descricao == descricao);
        }

        /// <summary>
        /// Verifica se o representante legal do participante existe por descrição para um identificador diferente do representante legal do participante a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do representante legal do participante</param>
        /// <param name="descricao">Descrição do representante legal do participante</param>
        /// <returns>Valor indicando se o representante legal do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _context.RepresentanteLegal.AnyAsync(representanteLegal => representanteLegal.Descricao == descricao && representanteLegal.Id != id);
        }
    }
}