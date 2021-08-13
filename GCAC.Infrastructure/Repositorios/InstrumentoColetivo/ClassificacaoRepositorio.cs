using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.Interfaces.Repositorios.InstrumentoColetivo;
using GCAC.Infrastructure.Contextos;

namespace GCAC.Infrastructure.Repositorios.InstrumentoColetivo
{
    /// <summary>
    /// Repositório para a entidade Classificacao
    /// </summary>
    public class ClassificacaoRepositorio : IClassificacaoRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public ClassificacaoRepositorio(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Seleciona todos as classificações
        /// </summary>
        /// <returns>Lista de classificações</returns>
        public async Task<IEnumerable<Classificacao>> SelecionarTodos()
        {
            return await _context.Classificacao.ToListAsync();
        }

        /// <summary>
        /// Seleciona uma classificação pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da classificação</param>
        /// <returns>Registro da classificação solicitada</returns>
        public async Task<Classificacao> SelecionarPorId(long id)
        {
            return await _context.Classificacao.FindAsync(id);
        }

        /// <summary>
        /// Cria uma nova classificação
        /// </summary>
        /// <param name="item">Nova classificação a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Classificacao item)
        {
            _context.ChangeTracker.Clear();
            _context.Classificacao.Add(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza uma classificação
        /// </summary>
        /// <param name="item">Classificação a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Classificacao item)
        {
            _context.ChangeTracker.Clear();
            _context.Classificacao.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Exclui uma classificação
        /// </summary>
        /// <param name="item">Classificação a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Classificacao item)
        {
            _context.ChangeTracker.Clear();
            _context.Classificacao.Remove(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Verifica se a classificação existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição da classificação</param>
        /// <returns>Valor indicando se a classificação existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _context.Classificacao.AnyAsync(classificacao => classificacao.Descricao == descricao);
        }

        /// <summary>
        /// Verifica se a classificação existe por descrição para um identificador diferente da classificação a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da classificação</param>
        /// <param name="descricao">Descrição da classificação</param>
        /// <returns>Valor indicando se a classificação existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _context.Classificacao.AnyAsync(classificacao => classificacao.Descricao == descricao && classificacao.Id != id);
        }
    }
}