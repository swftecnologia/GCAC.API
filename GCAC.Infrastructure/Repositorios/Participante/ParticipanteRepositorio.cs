using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.Core.Entidades.Participante;
using GCAC.Core.Interfaces.Repositorios.Participante;
using GCAC.Infrastructure.Contextos;

namespace GCAC.Infrastructure.Repositorios.Participante
{
    /// <summary>
    /// Repositório para a entidade Participante
    /// </summary>
    public class ParticipanteRepositorio : IParticipanteRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public ParticipanteRepositorio(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Seleciona todos os participantes
        /// </summary>
        /// <returns>Lista de participantes</returns>
        public async Task<IEnumerable<Core.Entidades.Participante.Participante>> SelecionarTodos()
        {
            return await _context.Participante.ToListAsync();
        }

        /// <summary>
        /// Seleciona um participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do participante</param>
        /// <returns>Registro do participante solicitado</returns>
        public async Task<Core.Entidades.Participante.Participante> SelecionarPorId(long id)
        {
            return await _context.Participante.FindAsync(id);
        }

        /// <summary>
        /// Cria um novo participante do participante
        /// </summary>
        /// <param name="item">Novo participante do participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Core.Entidades.Participante.Participante item)
        {
            _context.ChangeTracker.Clear();
            _context.Participante.Add(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza um participante do participante
        /// </summary>
        /// <param name="item">Participante do participante a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Core.Entidades.Participante.Participante item)
        {
            _context.ChangeTracker.Clear();
            _context.Participante.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Exclui um participante do participante
        /// </summary>
        /// <param name="item">Participante do participante a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Core.Entidades.Participante.Participante item)
        {
            _context.ChangeTracker.Clear();
            _context.Participante.Remove(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Verifica se o participante existe por CNPJ
        /// </summary>
        /// <param name="cnpj">CNPJ do participante</param>
        /// <returns>Valor indicando se o participante existe ou não</returns>
        public async Task<bool> ExistePorCNPJ(string cnpj)
        {
            return await _context.Participante.AnyAsync(participante => participante.CNPJ == cnpj);
        }

        /// <summary>
        /// Verifica se o participante existe por CNPJ para um identificador diferente do participante a ser alterado
        /// </summary>
        /// <param name="id">Identificador único da participante</param>
        /// <param name="cnpj">CNPJ do participante</param>
        /// <returns>Valor indicando se o participante existe ou não</returns>
        public async Task<bool> ExistePorCNPJ(string cnpj, long id)
        {
            return await _context.Participante.AnyAsync(participante => participante.CNPJ == cnpj && participante.Id != id);
        }

        /// <summary>
        /// Verifica se o participante existe por CPF
        /// </summary>
        /// <param name="cpf">CPF do participante</param>
        /// <returns>Valor indicando se o participante existe ou não</returns>
        public async Task<bool> ExistePorCPF(string cpf)
        {
            return await _context.Participante.AnyAsync(participante => participante.CPF == cpf);
        }

        /// <summary>
        /// Verifica se o participante existe por CPF para um identificador diferente do participante a ser alterado
        /// </summary>
        /// <param name="id">Identificador único da participante</param>
        /// <param name="cpf">CPF do participante</param>
        /// <returns>Valor indicando se o participante existe ou não</returns>
        public async Task<bool> ExistePorCPF(string cpf, long id)
        {
            return await _context.Participante.AnyAsync(participante => participante.CPF == cpf && participante.Id != id);
        }
    }
}