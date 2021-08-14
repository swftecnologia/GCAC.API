using System.Collections.Generic;
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
    public class TipoContatoRepositorio : ITipoContatoRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public TipoContatoRepositorio(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Seleciona todos os tipos de contato do participante
        /// </summary>
        /// <returns>Lista de tipos de contato do participante</returns>
        public async Task<IEnumerable<TipoContato>> SelecionarTodos()
        {
            return await _context.TipoContato.ToListAsync();
        }

        /// <summary>
        /// Seleciona um tipo de contato do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do tipo de contato do participante</param>
        /// <returns>Registro do tipo de contato do participante solicitado</returns>
        public async Task<TipoContato> SelecionarPorId(long id)
        {
            return await _context.TipoContato.FindAsync(id);
        }

        /// <summary>
        /// Cria um novo tipo de contato do participante
        /// </summary>
        /// <param name="item">Novo tipo de contato do participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(TipoContato item)
        {
            _context.ChangeTracker.Clear();
            _context.TipoContato.Add(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza um tipo de contato do participante
        /// </summary>
        /// <param name="item">Tipo de contato do participante a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(TipoContato item)
        {
            _context.ChangeTracker.Clear();
            _context.TipoContato.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Exclui um tipo de contato do participante
        /// </summary>
        /// <param name="item">Tipo de contato do participante a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(TipoContato item)
        {
            _context.ChangeTracker.Clear();
            _context.TipoContato.Remove(item);
            return await _context.SaveChangesAsync();
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