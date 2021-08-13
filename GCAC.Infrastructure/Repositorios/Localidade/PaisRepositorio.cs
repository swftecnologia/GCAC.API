using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.Core.Entidades.Localidade;
using GCAC.Core.Interfaces.Repositorios.Localidade;
using GCAC.Infrastructure.Contextos;

namespace GCAC.Infrastructure.Repositorios.Localidade
{
    /// <summary>
    /// Repositório para a entidade Pais
    /// </summary>
    public class PaisRepositorio : IPaisRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public PaisRepositorio(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Seleciona todos os registros
        /// </summary>
        /// <returns>Lista de países</returns>
        public async Task<IEnumerable<Pais>> SelecionarTodos()
        {
            return await _context.Pais.ToListAsync();
        }

        /// <summary>
        /// Seleciona um país pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do país</param>
        /// <returns>Registro do país solicitado</returns>
        public async Task<Pais> SelecionarPorId(long id)
        {
            return await _context.Pais.FindAsync(id);
        }

        /// <summary>
        /// Cria um novo país
        /// </summary>
        /// <param name="item">Novo país a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Pais item)
        {
            _context.ChangeTracker.Clear();
            _context.Pais.Add(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza um país
        /// </summary>
        /// <param name="item">País a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Pais item)
        {
            _context.ChangeTracker.Clear();
            _context.Pais.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Exclui um país
        /// </summary>
        /// <param name="item">País a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Pais item)
        {
            _context.ChangeTracker.Clear();
            _context.Pais.Remove(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Verifica se o país existe por nome
        /// </summary>
        /// <param name="nome">Nome do país</param>
        /// <returns>Valor indicando se o país existe ou não</returns>
        public async Task<bool> ExistePorNome(string nome)
        {
            return await _context.Pais.AnyAsync(pais => pais.Nome == nome);
        }

        /// <summary>
        /// Verifica se o país existe por nome para um identificador diferente do país a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do país</param>
        /// <param name="nome">Nome do país</param>
        /// <returns>Valor indicando se o país existe ou não</returns>
        public async Task<bool> ExistePorNome(string nome, long id)
        {
            return await _context.Pais.AnyAsync(pais => pais.Nome == nome && pais.Id != id);
        }
    }
}