using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.Interfaces.Repositorios.InstrumentoColetivo;
using GCAC.Infrastructure.Contextos;

namespace GCAC.Infrastructure.Repositorios.InstrumentoColetivo
{
    /// <summary>
    /// Repositório para a entidade ClausulaGrupo
    /// </summary>
    public class ClausulaGrupoRepositorio : IClausulaGrupoRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public ClausulaGrupoRepositorio(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Seleciona todos os grupos da cláusula
        /// </summary>
        /// <returns>Lista de grupos da cláusula</returns>
        public async Task<IEnumerable<ClausulaGrupo>> SelecionarTodos()
        {
            return await _context.ClausulaGrupo.ToListAsync();
        }

        /// <summary>
        /// Seleciona um grupo do cláusula pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do grupo da cláusula</param>
        /// <returns>Registro do grupo da cláusula solicitada</returns>
        public async Task<ClausulaGrupo> SelecionarPorId(long id)
        {
            return await _context.ClausulaGrupo.FindAsync(id);
        }

        /// <summary>
        /// Cria um novo grupo do cláusula
        /// </summary>
        /// <param name="item">Novo grupo da cláusula a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(ClausulaGrupo item)
        {
            _context.ChangeTracker.Clear();
            _context.ClausulaGrupo.Add(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza um grupo da cláusula
        /// </summary>
        /// <param name="item">Grupo da cláusula a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(ClausulaGrupo item)
        {
            _context.ChangeTracker.Clear();
            _context.ClausulaGrupo.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Exclui um grupo da cláusula
        /// </summary>
        /// <param name="item">Grupo da cláusula a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(ClausulaGrupo item)
        {
            _context.ChangeTracker.Clear();
            _context.ClausulaGrupo.Remove(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Verifica se o grupo da cláusula existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do grupo da cláusula</param>
        /// <returns>Valor indicando se o grupo da cláusula existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _context.ClausulaGrupo.AnyAsync(clausulaGrupo => clausulaGrupo.Descricao == descricao);
        }

        /// <summary>
        /// Verifica se o grupo da cláusula existe por descrição para um identificador diferente do grupo da cláusula a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do grupo da cláusula</param>
        /// <param name="descricao">Descrição do grupo da cláusula</param>
        /// <returns>Valor indicando se o grupo da cláusula existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _context.ClausulaGrupo.AnyAsync(clausulaGrupo => clausulaGrupo.Descricao == descricao && clausulaGrupo.Id != id);
        }
    }
}