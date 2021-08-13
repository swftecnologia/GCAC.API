using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.Core.Entidades.Localidade;
using GCAC.Core.Interfaces.Repositorios.Localidade;
using GCAC.Infrastructure.Contextos;

namespace GCAC.Infrastructure.Repositorios.Localidade
{
    /// <summary>
    /// Repositório para a entidade Estado
    /// </summary>
    public class EstadoRepositorio : IEstadoRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public EstadoRepositorio(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Seleciona todos os registros
        /// </summary>
        /// <returns>Lista de estados</returns>
        public async Task<IEnumerable<Estado>> SelecionarTodos()
        {
            return await _context.Estado.ToListAsync();
        }

        /// <summary>
        /// Seleciona um estado pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do estado</param>
        /// <returns>Registro do estado solicitado</returns>
        public async Task<Estado> SelecionarPorId(long id)
        {
            return await _context.Estado.FindAsync(id);
        }

        /// <summary>
        /// Seleciona todos os estados pertencentes a um país
        /// </summary>
        /// <param name="id">Identificador único do país</param>
        /// <returns>Lista de estados pertencentes a um país</returns>
        public async Task<IEnumerable<Estado>> SelecionarPorPais(long id)
        {
            return await _context.Estado.Where(x => x.PaisId == id).ToListAsync();
        }

        /// <summary>
        /// Cria um novo estado
        /// </summary>
        /// <param name="item">Novo estado a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Estado item)
        {
            _context.ChangeTracker.Clear();
            _context.Estado.Add(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza um estado
        /// </summary>
        /// <param name="item">Estado a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Estado item)
        {
            _context.ChangeTracker.Clear();
            _context.Estado.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Exclui um estado
        /// </summary>
        /// <param name="item">Estado a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Estado item)
        {
            _context.ChangeTracker.Clear();
            _context.Estado.Remove(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Verifica se o estado existe por nome
        /// </summary>
        /// <param name="nome">Nome do estado</param>
        /// <returns>Valor indicando se o estado existe ou não</returns>
        public async Task<bool> ExistePorNome(string nome)
        {
            return await _context.Estado.AnyAsync(estado => estado.Nome == nome);
        }

        /// <summary>
        /// Verifica se o estado existe por nome para um identificador diferente do estado a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do estado</param>
        /// <param name="nome">Nome do estado</param>
        /// <returns>Valor indicando se o estado existe ou não</returns>
        public async Task<bool> ExistePorNome(string nome, long id)
        {
            return await _context.Estado.AnyAsync(estado => estado.Nome == nome && estado.Id != id);
        }
    }
}