using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.Interfaces.Repositorios.InstrumentoColetivo;
using GCAC.Infrastructure.Contextos;

namespace GCAC.Infrastructure.Repositorios.InstrumentoColetivo
{
    /// <summary>
    /// Repositório para a entidade Abrangencia
    /// </summary>
    public class AbrangenciaRepositorio : IAbrangenciaRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public AbrangenciaRepositorio(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Seleciona todos as abrangências
        /// </summary>
        /// <returns>Lista de abrangências</returns>
        public async Task<IEnumerable<Abrangencia>> SelecionarTodos()
        {
            return await _context.Abrangencia.ToListAsync();
        }

        /// <summary>
        /// Seleciona uma abrangência pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da abrangência</param>
        /// <returns>Registro da abrangência solicitada</returns>
        public async Task<Abrangencia> SelecionarPorId(long id)
        {
            return await _context.Abrangencia.FindAsync(id);
        }

        /// <summary>
        /// Cria uma nova abrangência
        /// </summary>
        /// <param name="item">Nova abrangência a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Abrangencia item)
        {
            _context.ChangeTracker.Clear();
            _context.Abrangencia.Add(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza uma abrangência
        /// </summary>
        /// <param name="item">Abrangência a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Abrangencia item)
        {
            _context.ChangeTracker.Clear();
            _context.Abrangencia.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Exclui uma abrangência
        /// </summary>
        /// <param name="item">Abrangência a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Abrangencia item)
        {
            _context.ChangeTracker.Clear();
            _context.Abrangencia.Remove(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Verifica se a abrangência existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição da abrangência</param>
        /// <returns>Valor indicando se a abrangência existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _context.Abrangencia.AnyAsync(abrangencia => abrangencia.Descricao == descricao);
        }

        /// <summary>
        /// Verifica se a abrangência existe por descrição para um identificador diferente da abrangência a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da abrangência</param>
        /// <param name="descricao">Descrição da abrangência</param>
        /// <returns>Valor indicando se a abrangência existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _context.Abrangencia.AnyAsync(abrangencia => abrangencia.Descricao == descricao && abrangencia.Id != id);
        }
    }
}