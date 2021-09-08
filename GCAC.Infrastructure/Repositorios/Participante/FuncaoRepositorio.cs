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
    public class FuncaoRepositorio : BaseRepositorio<Funcao>, IFuncaoRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public FuncaoRepositorio(Context context) : base(context)
        {
            _context = context;
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