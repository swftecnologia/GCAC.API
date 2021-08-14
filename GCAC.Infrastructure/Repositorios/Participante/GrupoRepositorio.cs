using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.Core.Entidades.Participante;
using GCAC.Core.Interfaces.Repositorios.Participante;
using GCAC.Infrastructure.Contextos;

namespace GCAC.Infrastructure.Repositorios.Participante
{
    /// <summary>
    /// Repositório para a entidade Grupo
    /// </summary>
    public class GrupoRepositorio : IGrupoRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public GrupoRepositorio(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Seleciona todos os grupos do participante
        /// </summary>
        /// <returns>Lista de grupos do participante</returns>
        public async Task<IEnumerable<Grupo>> SelecionarTodos()
        {
            return await _context.Grupo.ToListAsync();
        }

        /// <summary>
        /// Seleciona um grupo do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do grupo do participante</param>
        /// <returns>Registro do grupo do participante solicitado</returns>
        public async Task<Grupo> SelecionarPorId(long id)
        {
            return await _context.Grupo.FindAsync(id);
        }

        /// <summary>
        /// Cria um novo grupo do participante
        /// </summary>
        /// <param name="item">Novo grupo do participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Grupo item)
        {
            _context.ChangeTracker.Clear();
            _context.Grupo.Add(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza um grupo do participante
        /// </summary>
        /// <param name="item">Grupo do participante a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Grupo item)
        {
            _context.ChangeTracker.Clear();
            _context.Grupo.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Exclui um grupo do participante
        /// </summary>
        /// <param name="item">Grupo do participante a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Grupo item)
        {
            _context.ChangeTracker.Clear();
            _context.Grupo.Remove(item);
            return await _context.SaveChangesAsync();
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