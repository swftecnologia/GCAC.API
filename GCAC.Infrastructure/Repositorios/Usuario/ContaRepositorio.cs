using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.Core.Contratos.Repositorios.Usuario;
using GCAC.Core.Entidades.Usuario;
using GCAC.Infrastructure.Contextos;

namespace GCAC.Infrastructure.Repositorios.Usuario
{
    /// <summary>
    /// Repositório para a entidade Conta
    /// </summary>
    public class ContaRepositorio : BaseRepositorio<Conta>, IContaRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public ContaRepositorio(Context context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="tokenAtivacao"></param>
        /// <returns></returns>
        public async Task<Conta> SelecionarPorEmailETokenAtivacao(string email, string tokenAtivacao)
        {
            return await _context.Conta.Where(t => t.Email.ToLower() == email.ToLower() && t.TokenAtivacao.ToString() == tokenAtivacao).SingleOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public async Task<Conta> SelecionarParaLogin(string email, string senha)
        {
            return await _context.Conta.Where(t => t.Email.ToLower() == email.ToLower() && t.Senha == senha).SingleOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<Conta> SelecionarPorEmail(string email)
        {
            return await _context.Conta.Where(t => t.Email.ToLower() == email.ToLower()).SingleOrDefaultAsync();
        }
    }
}
