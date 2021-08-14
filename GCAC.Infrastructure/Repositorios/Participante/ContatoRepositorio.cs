using System.Collections.Generic;
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
    public class ContatoRepositorio : IContatoRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public ContatoRepositorio(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Seleciona todos os contatos do participante
        /// </summary>
        /// <returns>Lista de contatos do participante</returns>
        public async Task<IEnumerable<Contato>> SelecionarTodos()
        {
            return await _context.Contato.ToListAsync();
        }

        /// <summary>
        /// Seleciona um contato do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do contato do participante</param>
        /// <returns>Registro do contato do participante solicitado</returns>
        public async Task<Contato> SelecionarPorId(long id)
        {
            return await _context.Contato.FindAsync(id);
        }

        /// <summary>
        /// Cria um novo contato do participante
        /// </summary>
        /// <param name="item">Novo contato do participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Contato item)
        {
            _context.ChangeTracker.Clear();
            _context.Contato.Add(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza um contato do participante
        /// </summary>
        /// <param name="item">Contato do participante a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Contato item)
        {
            _context.ChangeTracker.Clear();
            _context.Contato.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Exclui um contato do participante
        /// </summary>
        /// <param name="item">Contato do participante a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Contato item)
        {
            _context.ChangeTracker.Clear();
            _context.Contato.Remove(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Verifica se o contato do participante existe
        /// </summary>
        /// <param name="contatoParticipante">Contato do participante</param>
        /// <returns>Valor indicando se o contato do participante existe ou não</returns>
        public async Task<bool> ExistePorContatoParticipante(string contatoParticipante)
        {
            return await _context.Contato.AnyAsync(contato => contato.ContatoParticipante == contatoParticipante);
        }

        /// <summary>
        /// Verifica se o contato do participante existe para um identificador diferente do contato do participante a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do contato do participante</param>
        /// <param name="contatoParticipante">Contato do participante</param>
        /// <returns>Valor indicando se o contato do participante existe ou não</returns>
        public async Task<bool> ExistePorContatoParticipante(string contatoParticipante, long id)
        {
            return await _context.Contato.AnyAsync(contato => contato.ContatoParticipante == contatoParticipante && contato.TipoContatoId != id);
        }
    }
}