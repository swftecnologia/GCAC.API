using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.Core.Entidades.Participante;
using GCAC.Core.Interfaces.Repositorios.Participante;
using GCAC.Infrastructure.Contextos;

namespace GCAC.Infrastructure.Repositorios.Participante
{
    /// <summary>
    /// Repositório para a entidade GrauEntidade
    /// </summary>
    public class GrauEntidadeRepositorio : IGrauEntidadeRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public GrauEntidadeRepositorio(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Seleciona todos os graus da entidade do participante
        /// </summary>
        /// <returns>Lista de graus da entidade do participante</returns>
        public async Task<IEnumerable<GrauEntidade>> SelecionarTodos()
        {
            return await _context.GrauEntidade.ToListAsync();
        }

        /// <summary>
        /// Seleciona um grau da entidade do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do grau da entidade do participante</param>
        /// <returns>Registro do grau da entidade do participante solicitado</returns>
        public async Task<GrauEntidade> SelecionarPorId(long id)
        {
            return await _context.GrauEntidade.FindAsync(id);
        }

        /// <summary>
        /// Cria um novo grau da entidade do participante
        /// </summary>
        /// <param name="item">Novo grau da entidade do participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(GrauEntidade item)
        {
            _context.ChangeTracker.Clear();
            _context.GrauEntidade.Add(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza um grau da entidade do participante
        /// </summary>
        /// <param name="item">Grau da entidade do participante a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(GrauEntidade item)
        {
            _context.ChangeTracker.Clear();
            _context.GrauEntidade.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Exclui um grau da entidade do participante
        /// </summary>
        /// <param name="item">Grau da entidade do participante a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(GrauEntidade item)
        {
            _context.ChangeTracker.Clear();
            _context.GrauEntidade.Remove(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Verifica se o grau da entidade do participante existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do grau da entidade do participante</param>
        /// <returns>Valor indicando se o grau da entidade do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _context.GrauEntidade.AnyAsync(grauEntidade => grauEntidade.Descricao == descricao);
        }

        /// <summary>
        /// Verifica se o grau da entidade do participante existe por descrição para um identificador diferente do grau da entidade do participante a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do grau da entidade do participante</param>
        /// <param name="descricao">Descrição do grau da entidade do participante</param>
        /// <returns>Valor indicando se o grau da entidade do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _context.GrauEntidade.AnyAsync(grauEntidade => grauEntidade.Descricao == descricao && grauEntidade.Id != id);
        }
    }
}