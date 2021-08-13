using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.Core.Entidades.Localidade;
using GCAC.Core.Interfaces.Repositorios.Localidade;
using GCAC.Infrastructure.Contextos;

namespace GCAC.Infrastructure.Repositorios.Localidade
{
    /// <summary>
    /// Repositório para a entidade Regiao
    /// </summary>
    public class RegiaoRepositorio : IRegiaoRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public RegiaoRepositorio(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Seleciona todos as regiões
        /// </summary>
        /// <returns>Lista de regiões</returns>
        public async Task<IEnumerable<Regiao>> SelecionarTodos()
        {
            return await _context.Regiao.ToListAsync();
        }

        /// <summary>
        /// Seleciona uma região pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da região</param>
        /// <returns>Registro da região solicitada</returns>
        public async Task<Regiao> SelecionarPorId(long id)
        {
            return await _context.Regiao.FindAsync(id);
        }

        /// <summary>
        /// Cria uma nova região
        /// </summary>
        /// <param name="item">Nova região a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Regiao item)
        {
            _context.ChangeTracker.Clear();
            _context.Regiao.Add(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza uma região
        /// </summary>
        /// <param name="item">Região a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Regiao item)
        {
            _context.ChangeTracker.Clear();
            _context.Regiao.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Exclui uma região
        /// </summary>
        /// <param name="item">Região a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Regiao item)
        {
            _context.ChangeTracker.Clear();
            _context.Regiao.Remove(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Verifica se a região existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição da região</param>
        /// <returns>Valor indicando se a região existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _context.Regiao.AnyAsync(regiao => regiao.Descricao == descricao);
        }

        /// <summary>
        /// Verifica se a região existe por descrição para um identificador diferente da região a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da região</param>
        /// <param name="descricao">Descrição da região</param>
        /// <returns>Valor indicando se a região existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _context.Regiao.AnyAsync(regiao => regiao.Descricao == descricao && regiao.Id != id);
        }
    }
}