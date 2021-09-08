using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.Core.Entidades.Participante;
using GCAC.Core.Interfaces.Repositorios.Participante;
using GCAC.Infrastructure.Contextos;

namespace GCAC.Infrastructure.Repositorios.Participante
{
    /// <summary>
    /// Repositório para a entidade TipoContato
    /// </summary>
    public class TipoContatoRepositorio : BaseRepositorio<TipoContato>, ITipoContatoRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public TipoContatoRepositorio(Context context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Verifica se o tipo de contato do participante existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do tipo de contato do participante</param>
        /// <returns>Valor indicando se o tipo de contato do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _context.TipoContato.AnyAsync(tipoContato => tipoContato.Descricao == descricao);
        }

        /// <summary>
        /// Verifica se o tipo de contato do participante existe por descrição para um identificador diferente do tipo de contato do participante a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do tipo de contato do participante</param>
        /// <param name="descricao">Descrição do tipo de contato do participante</param>
        /// <returns>Valor indicando se o tipo de contato do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _context.TipoContato.AnyAsync(tipoContato => tipoContato.Descricao == descricao && tipoContato.Id != id);
        }
    }
}