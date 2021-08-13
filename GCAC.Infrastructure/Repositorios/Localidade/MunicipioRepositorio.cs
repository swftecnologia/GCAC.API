using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.Core.Entidades.Localidade;
using GCAC.Core.Interfaces.Repositorios.Localidade;
using GCAC.Infrastructure.Contextos;

namespace GCAC.Infrastructure.Repositorios.Localidade
{
    /// <summary>
    /// Repositório para a entidade Municipio
    /// </summary>
    public class MunicipioRepositorio : IMunicipioRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public MunicipioRepositorio(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Seleciona todos os registros
        /// </summary>
        /// <returns>Lista de municípios</returns>
        public async Task<IEnumerable<Municipio>> SelecionarTodos()
        {
            return await _context.Municipio.ToListAsync();
        }

        /// <summary>
        /// Seleciona um município pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do município</param>
        /// <returns>Registro do município solicitado</returns>
        public async Task<Municipio> SelecionarPorId(long id)
        {
            return await _context.Municipio.FindAsync(id);
        }

        /// <summary>
        /// Seleciona todos os municípios pertencentes a um estado
        /// </summary>
        /// <param name="id">Identificador único do estado</param>
        /// <returns>Lista de municípios pertencentes a um estado</returns>
        public async Task<IEnumerable<Municipio>> SelecionarPorEstado(long id)
        {
            return await _context.Municipio.Where(x => x.EstadoId == id).ToListAsync();
        }

        /// <summary>
        /// Cria um novo município
        /// </summary>
        /// <param name="item">Novo município a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Municipio item)
        {
            _context.ChangeTracker.Clear();
            _context.Municipio.Add(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza um município
        /// </summary>
        /// <param name="item">Município a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Municipio item)
        {
            _context.ChangeTracker.Clear();
            _context.Municipio.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Exclui um município
        /// </summary>
        /// <param name="item">Município a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Municipio item)
        {
            _context.ChangeTracker.Clear();
            _context.Municipio.Remove(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Verifica se o município existe por nome
        /// </summary>
        /// <param name="nome">Nome do município</param>
        /// <returns>Valor indicando se o município existe ou não</returns>
        public async Task<bool> ExistePorNome(string nome)
        {
            return await _context.Municipio.AnyAsync(municipio => municipio.Nome == nome);
        }

        /// <summary>
        /// Verifica se o município existe por nome para um identificador diferente do município a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do município</param>
        /// <param name="nome">Nome do município</param>
        /// <returns>Valor indicando se o município existe ou não</returns>
        public async Task<bool> ExistePorNome(string nome, long id)
        {
            return await _context.Municipio.AnyAsync(municipio => municipio.Nome == nome && municipio.Id != id);
        }
    }
}