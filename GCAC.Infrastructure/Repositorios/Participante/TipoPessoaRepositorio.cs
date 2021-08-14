using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.Core.Entidades.Participante;
using GCAC.Core.Interfaces.Repositorios.Participante;
using GCAC.Infrastructure.Contextos;

namespace GCAC.Infrastructure.Repositorios.Participante
{
    /// <summary>
    /// Repositório para a entidade TipoPessoa
    /// </summary>
    public class TipoPessoaRepositorio : ITipoPessoaRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public TipoPessoaRepositorio(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Seleciona todos os tipos de pessoa do participante
        /// </summary>
        /// <returns>Lista de tipos de pessoa do participante</returns>
        public async Task<IEnumerable<TipoPessoa>> SelecionarTodos()
        {
            return await _context.TipoPessoa.ToListAsync();
        }

        /// <summary>
        /// Seleciona um tipo de pessoa do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do tipo de pessoa do participante</param>
        /// <returns>Registro do tipo de pessoa do participante solicitado</returns>
        public async Task<TipoPessoa> SelecionarPorId(long id)
        {
            return await _context.TipoPessoa.FindAsync(id);
        }

        /// <summary>
        /// Cria um novo tipo de pessoa do participante
        /// </summary>
        /// <param name="item">Novo tipo de pessoa do participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(TipoPessoa item)
        {
            _context.ChangeTracker.Clear();
            _context.TipoPessoa.Add(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza um tipo de pessoa do participante
        /// </summary>
        /// <param name="item">Tipo de pessoa do participante a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(TipoPessoa item)
        {
            _context.ChangeTracker.Clear();
            _context.TipoPessoa.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Exclui um tipo de pessoa do participante
        /// </summary>
        /// <param name="item">Tipo de pessoa do participante a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(TipoPessoa item)
        {
            _context.ChangeTracker.Clear();
            _context.TipoPessoa.Remove(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Verifica se o tipo de pessoa do participante existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do tipo de pessoa do participante</param>
        /// <returns>Valor indicando se o tipo de pessoa do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _context.TipoPessoa.AnyAsync(tipoPessoa => tipoPessoa.Descricao == descricao);
        }

        /// <summary>
        /// Verifica se o tipo de pessoa do participante existe por descrição para um identificador diferente do tipo de pessoa do participante a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do tipo de pessoa do participante</param>
        /// <param name="descricao">Descrição do tipo de pessoa do participante</param>
        /// <returns>Valor indicando se o tipo de pessoa do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _context.TipoPessoa.AnyAsync(tipoPessoa => tipoPessoa.Descricao == descricao && tipoPessoa.Id != id);
        }
    }
}