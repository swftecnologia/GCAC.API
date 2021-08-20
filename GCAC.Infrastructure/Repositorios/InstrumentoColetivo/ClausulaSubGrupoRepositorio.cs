using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.Interfaces.Repositorios.InstrumentoColetivo;
using GCAC.Infrastructure.Contextos;

namespace GCAC.Infrastructure.Repositorios.InstrumentoColetivo
{
    /// <summary>
    /// Repositório para a entidade ClausulaSubGrupo
    /// </summary>
    public class ClausulaSubGrupoRepositorio : IClausulaSubGrupoRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public ClausulaSubGrupoRepositorio(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Seleciona todos os sub-grupos do grupo da claúsula
        /// </summary>
        /// <returns>Lista de sub-grupos do grupo da claúsula</returns>
        public async Task<IEnumerable<ClausulaSubGrupo>> SelecionarTodos()
        {
            return await _context.ClausulaSubGrupo.ToListAsync();
        }

        /// <summary>
        /// Seleciona um sub-grupo do grupo da claúsula pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do sub-grupo do grupo da claúsula</param>
        /// <returns>Registro do sub-grupo do grupo da claúsula solicitada</returns>
        public async Task<ClausulaSubGrupo> SelecionarPorId(long id)
        {
            return await _context.ClausulaSubGrupo.FindAsync(id);
        }

        /// <summary>
        /// Seleciona todos os sub-grupos da clásula pertencentes a um grupo da cláusula
        /// </summary>
        /// <param name="id">Identificador único do grupo da cláusula</param>
        /// <returns>Lista de sub-grupos da cláusula pertencentes a um grupo da cláusula</returns>
        public async Task<IEnumerable<ClausulaSubGrupo>> SelecionarPorClausulaGrupo(long id)
        {
            return await _context.ClausulaSubGrupo.Where(x => x.ClausulaGrupoId == id).ToListAsync();
        }

        /// <summary>
        /// Cria um novo sub-grupo do grupo da claúsula
        /// </summary>
        /// <param name="item">Novo sub-grupo do grupo da claúsula a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(ClausulaSubGrupo item)
        {
            _context.ChangeTracker.Clear();
            _context.ClausulaSubGrupo.Add(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza um sub-grupo do grupo da claúsula
        /// </summary>
        /// <param name="item">Sub-Grupo do grupo da claúsula a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(ClausulaSubGrupo item)
        {
            _context.ChangeTracker.Clear();
            _context.ClausulaSubGrupo.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Exclui um sub-grupo do grupo da claúsula
        /// </summary>
        /// <param name="item">Sub-Grupo do grupo da claúsula a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(ClausulaSubGrupo item)
        {
            _context.ChangeTracker.Clear();
            _context.ClausulaSubGrupo.Remove(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Verifica se o sub-grupo do grupo da claúsula existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do sub-grupo do grupo da claúsula</param>
        /// <returns>Valor indicando se o sub-grupo do grupo da claúsula existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _context.ClausulaSubGrupo.AnyAsync(clausulaSubGrupo => clausulaSubGrupo.Descricao == descricao);
        }

        /// <summary>
        /// Verifica se o sub-grupo do grupo da claúsula existe por descrição para um identificador diferente do sub-grupo do grupo da claúsula a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do sub-grupo do grupo da claúsula</param>
        /// <param name="descricao">Descrição do sub-grupo do grupo da claúsula</param>
        /// <returns>Valor indicando se o sub-grupo do grupo da claúsula existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _context.ClausulaSubGrupo.AnyAsync(clausulaSubGrupo => clausulaSubGrupo.Descricao == descricao && clausulaSubGrupo.Id != id);
        }
    }
}