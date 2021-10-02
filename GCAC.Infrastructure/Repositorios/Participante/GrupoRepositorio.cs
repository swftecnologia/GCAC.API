using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.Core.Entidades.Participante;
using GCAC.Core.Contratos.Repositorios.Participante;
using GCAC.Infrastructure.Contextos;

namespace GCAC.Infrastructure.Repositorios.Participante
{
    /// <summary>
    /// Repositório para a entidade Grupo
    /// </summary>
    public class GrupoRepositorio : BaseRepositorio<Grupo>, IGrupoRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public GrupoRepositorio(Context context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Verifica se o grupo do participante existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do grupo do participante</param>
        /// <returns>Valor indicando se o grupo do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _context.Grupo.AnyAsync(grupo => grupo.Descricao == descricao);
        }

        /// <summary>
        /// Verifica se o grupo do participante existe por descrição para um identificador diferente do grupo do participante a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do grupo do participante</param>
        /// <param name="descricao">Descrição do grupo do participante</param>
        /// <returns>Valor indicando se o grupo do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _context.Grupo.AnyAsync(grupo => grupo.Descricao == descricao && grupo.Id != id);
        }
    }
}