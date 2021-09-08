using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.Core.Entidades.Participante;
using GCAC.Core.Interfaces.Repositorios.Participante;
using GCAC.Infrastructure.Contextos;

namespace GCAC.Infrastructure.Repositorios.Participante
{
    /// <summary>
    /// Repositório para a entidade Contato
    /// </summary>
    public class ContatoRepositorio : BaseRepositorio<Contato>, IContatoRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public ContatoRepositorio(Context context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Seleciona todos os contatos pertencentes a um participante
        /// </summary>
        /// <param name="id">Identificador único do participante</param>
        /// <returns>Lista de contatos pertencentes a um participante</returns>
        public async Task<IEnumerable<Contato>> SelecionarPorParticipante(long id)
        {
            return await _context.Contato.Include(x => x.Participante).Include(x => x.TipoContato).Where(x => x.ParticipanteId == id).ToListAsync();
        }

        /// <summary>
        /// Verifica se o contato do participante existe
        /// </summary>
        /// <param name="idParticipante">Identificador único do participante</param>
        /// <param name="idTipoContato">Identificador único do tipo de contato do participante</param>
        /// <param name="contatoParticipante">Contato do participante</param>
        /// <returns>Valor indicando se o contato do participante existe ou não</returns>
        public async Task<bool> ExistePorContatoParticipante(long idParticipante, long idTipoContato, string contatoParticipante)
        {
            return await _context.Contato.AnyAsync(contato => contato.ParticipanteId == idParticipante && contato.TipoContatoId == idTipoContato && contato.ContatoParticipante == contatoParticipante);
        }

        /// <summary>
        /// Verifica se o contato do participante existe para um identificador diferente do contato do participante a ser alterado
        /// </summary>
        /// <param name="idParticipante">Identificador único do participante</param>
        /// <param name="idTipoContato">Identificador único do tipo de contato do participante</param>
        /// <param name="contatoParticipante">Contato do participante</param>
        /// /// <param name="id">Identificador único do contato do participante</param>
        /// <returns>Valor indicando se o contato do participante existe ou não</returns>
        public async Task<bool> ExistePorContatoParticipante(long idParticipante, long idTipoContato, string contatoParticipante, long id)
        {
            return await _context.Contato.AnyAsync(contato => contato.ParticipanteId == idParticipante && contato.TipoContatoId == idTipoContato && contato.ContatoParticipante == contatoParticipante && contato.Id != id);
        }
    }
}