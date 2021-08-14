using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.Core.Entidades.Participante;
using GCAC.Core.Interfaces.Repositorios.Participante;
using GCAC.Infrastructure.Contextos;

namespace GCAC.Infrastructure.Repositorios.Participante
{
    /// <summary>
    /// Repositório para a entidade Funcao
    /// </summary>
    public class FuncaoRepositorio : IFuncaoRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public FuncaoRepositorio(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Seleciona todos as funções do participante
        /// </summary>
        /// <returns>Lista de funções do participante</returns>
        public async Task<IEnumerable<Funcao>> SelecionarTodos()
        {
            return await _context.Funcao.ToListAsync();
        }

        /// <summary>
        /// Seleciona uma função do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da função do participante</param>
        /// <returns>Registro da função do participante solicitada</returns>
        public async Task<Funcao> SelecionarPorId(long id)
        {
            return await _context.Funcao.FindAsync(id);
        }

        /// <summary>
        /// Cria uma nova função do participante
        /// </summary>
        /// <param name="item">Nova função do participante a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Funcao item)
        {
            _context.ChangeTracker.Clear();
            _context.Funcao.Add(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza uma função do participante
        /// </summary>
        /// <param name="item">Funcao do participante a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Funcao item)
        {
            _context.ChangeTracker.Clear();
            _context.Funcao.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Exclui uma função do participante
        /// </summary>
        /// <param name="item">Funcao do participante a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Funcao item)
        {
            _context.ChangeTracker.Clear();
            _context.Funcao.Remove(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Verifica se a função do participante existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição da função do participante</param>
        /// <returns>Valor indicando se a função do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _context.Funcao.AnyAsync(função => função.Descricao == descricao);
        }

        /// <summary>
        /// Verifica se a função do participante existe por descrição para um identificador diferente da função do participante a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da função do participante</param>
        /// <param name="descricao">Descrição do função da participante</param>
        /// <returns>Valor indicando se a função do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _context.Funcao.AnyAsync(função => função.Descricao == descricao && função.Id != id);
        }
    }
}