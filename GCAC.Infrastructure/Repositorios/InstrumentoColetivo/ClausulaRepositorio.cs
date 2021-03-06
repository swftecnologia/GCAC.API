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
    /// Repositório para a entidade Clausula
    /// </summary>
    public class ClausulaRepositorio : IClausulaRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public ClausulaRepositorio(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Seleciona todas as cláusulas
        /// </summary>
        /// <returns>Lista de cláusulas</returns>
        public async Task<IEnumerable<Clausula>> SelecionarTodos()
        {
            return await _context.Clausula.ToListAsync();
        }

        /// <summary>
        /// Seleciona uma cláusula pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da cláusula</param>
        /// <returns>Registro da cláusula solicitada</returns>
        public async Task<Clausula> SelecionarPorId(long id)
        {
            return await _context.Clausula.FindAsync(id);
        }

        /// <summary>
        /// Seleciona todos as cláusulas pertencentes a um sub-grupo da cláusula
        /// </summary>
        /// <param name="id">Identificador único do sub-grupo da cláusula</param>
        /// <returns>Lista de cláusulas pertencentes a um sub-grupo da cláusula</returns>
        public async Task<IEnumerable<Clausula>> SelecionarPorClausulaSubGrupo(long id)
        {
            return await _context.Clausula.Where(x => x.ClausulaSubGrupoId == id).ToListAsync();
        }

        /// <summary>
        /// Cria uma nova cláusula
        /// </summary>
        /// <param name="item">Nova cláusula a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Clausula item)
        {
            _context.ChangeTracker.Clear();
            _context.Clausula.Add(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza uma cláusula
        /// </summary>
        /// <param name="item">Cláusula a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Clausula item)
        {
            _context.ChangeTracker.Clear();
            _context.Clausula.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Exclui uma cláusula
        /// </summary>
        /// <param name="item">Cláusula a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Clausula item)
        {
            _context.ChangeTracker.Clear();
            _context.Clausula.Remove(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Verifica se a cláusula existe por título
        /// </summary>
        /// <param name="titulo">Título da cláusula</param>
        /// <returns>Valor indicando se a cláusula existe ou não</returns>
        public async Task<bool> ExistePorTitulo(string titulo)
        {
            return await _context.Clausula.AnyAsync(clausula => clausula.Titulo == titulo);
        }

        /// <summary>
        /// Verifica se a cláusula existe por título para um identificador diferente da cláusula a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da cláusula</param>
        /// <param name="titulo">Título da cláusula</param>
        /// <returns>Valor indicando se a cláusula existe ou não</returns>
        public async Task<bool> ExistePorTitulo(string titulo, long id)
        {
            return await _context.Clausula.AnyAsync(clausula => clausula.Titulo == titulo && clausula.Id != id);
        }
    }
}