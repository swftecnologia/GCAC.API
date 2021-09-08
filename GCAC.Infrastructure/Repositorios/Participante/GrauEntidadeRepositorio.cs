using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.Core.Entidades.Participante;
using GCAC.Core.Interfaces.Repositorios.Participante;
using GCAC.Infrastructure.Contextos;

namespace GCAC.Infrastructure.Repositorios.Participante
{
    /// <summary>
    /// Repositório para a entidade GrauEntidade
    /// </summary>
    public class GrauEntidadeRepositorio : BaseRepositorio<GrauEntidade>, IGrauEntidadeRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public GrauEntidadeRepositorio(Context context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Verifica se o grau da entidade do participante existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do grau da entidade do participante</param>
        /// <returns>Valor indicando se o grau da entidade do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _context.GrauEntidade.AnyAsync(grauEntidade => grauEntidade.Descricao == descricao);
        }

        /// <summary>
        /// Verifica se o grau da entidade do participante existe por descrição para um identificador diferente do grau da entidade do participante a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do grau da entidade do participante</param>
        /// <param name="descricao">Descrição do grau da entidade do participante</param>
        /// <returns>Valor indicando se o grau da entidade do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _context.GrauEntidade.AnyAsync(grauEntidade => grauEntidade.Descricao == descricao && grauEntidade.Id != id);
        }
    }
}