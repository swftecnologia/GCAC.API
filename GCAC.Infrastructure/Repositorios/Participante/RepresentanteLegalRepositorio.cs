using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.Core.Entidades.Participante;
using GCAC.Core.Interfaces.Repositorios.Participante;
using GCAC.Infrastructure.Contextos;

namespace GCAC.Infrastructure.Repositorios.Participante
{
    /// <summary>
    /// Repositório para a entidade RepresentanteLegal
    /// </summary>
    public class RepresentanteLegalRepositorio : IRepresentanteLegalRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public RepresentanteLegalRepositorio(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Seleciona todos os representantes legais do participante
        /// </summary>
        /// <returns>Lista de representantes legais do participante</returns>
        public async Task<IEnumerable<RepresentanteLegal>> SelecionarTodos()
        {
            return await _context.RepresentanteLegal.ToListAsync();
        }

        /// <summary>
        /// Seleciona um representante legal do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do representante legal do participante</param>
        /// <returns>Registro do representante legal do participante solicitado</returns>
        public async Task<RepresentanteLegal> SelecionarPorId(long id)
        {
            return await _context.RepresentanteLegal.FindAsync(id);
        }

        /// <summary>
        /// Cria um novo representante legal do participante
        /// </summary>
        /// <param name="item">Novo representante legal do participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(RepresentanteLegal item)
        {
            _context.ChangeTracker.Clear();
            _context.RepresentanteLegal.Add(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza um representante legal do participante
        /// </summary>
        /// <param name="item">Representante legal do participante a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(RepresentanteLegal item)
        {
            _context.ChangeTracker.Clear();
            _context.RepresentanteLegal.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Exclui um representante legal do participante
        /// </summary>
        /// <param name="item">Representante legal do participante a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(RepresentanteLegal item)
        {
            _context.ChangeTracker.Clear();
            _context.RepresentanteLegal.Remove(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Verifica se o representante legal do participante existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do representante legal do participante</param>
        /// <returns>Valor indicando se o representante legal do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _context.RepresentanteLegal.AnyAsync(representanteLegal => representanteLegal.Descricao == descricao);
        }

        /// <summary>
        /// Verifica se o representante legal do participante existe por descrição para um identificador diferente do representante legal do participante a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do representante legal do participante</param>
        /// <param name="descricao">Descrição do representante legal do participante</param>
        /// <returns>Valor indicando se o representante legal do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _context.RepresentanteLegal.AnyAsync(representanteLegal => representanteLegal.Descricao == descricao && representanteLegal.Id != id);
        }
    }
}