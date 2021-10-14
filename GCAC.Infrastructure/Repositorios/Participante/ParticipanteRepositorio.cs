using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GCAC.Core.Contratos.Repositorios.Participante;
using GCAC.Infrastructure.Contextos;
using GCAC.Core.Contratos.Repositorios.Pesquisa;
using GCAC.Core.DTOs.Pesquisa;
using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Infrastructure.Contextos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCAC.Infrastructure.Repositorios.Participante
{
    /// <summary>
    /// Repositório para a entidade Participante
    /// </summary>
    public class ParticipanteRepositorio : BaseRepositorio<Core.Entidades.Participante.Participante>, IParticipanteRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public ParticipanteRepositorio(Context context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Seleciona um participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do participante</param>
        /// <returns>Registro do participante solicitado</returns>
        public new async Task<Core.Entidades.Participante.Participante> SelecionarPorId(long id)
        {
            return await _context.Participante
                .Include(x => x.Enderecos)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Seleciona todos os particpantes pertencentes a um tipo de pessoa
        /// </summary>
        /// <param name="id">Identificador único do tipo de pessoa</param>
        /// <returns>Lista de particpantes pertencentes a um tipo de pessoa</returns>
        public async Task<IEnumerable<Core.Entidades.Participante.Participante>> SelecionarPorTipoPessoa(long id)
        {
            return await _context.Participante
                .Include(x => x.Grupo)
                .Include(x => x.Funcao)
                .Include(x => x.RepresentanteLegal)
                .Include(x => x.GrauEntidade)
                .Include(x => x.ParticipanteMatriz)
                .Where(x => x.TipoPessoaId == id).ToListAsync();
        }

        /// <summary>
        /// Lista todos os particpantes que são ou que não são entidades sindicais
        /// </summary>
        /// <param name="entidadeSindical">Indica se deve considerar apenas entidades sindicais</param>
        /// <returns>Lista de participantes que são ou que não são entidades sindicais</returns>
        public async Task<IEnumerable<Core.Entidades.Participante.Participante>> SelecionarPorEntidadeSindical(bool entidadeSindical)
        {
            return await _context.Participante
                .Include(x => x.Grupo)
                .Include(x => x.Funcao)
                .Include(x => x.RepresentanteLegal)
                .Include(x => x.GrauEntidade)
                .Include(x => x.ParticipanteMatriz)
                .Where(x => x.EntidadeSindical == entidadeSindical).ToListAsync();
        }

        /// <summary>
        /// Lista todos os particpantes para o(s) grupo(s) informado(s)
        /// </summary>
        /// <param name="ids">Identificador(es) único(s) do(s) grupo(s)</param>
        /// <returns>Lista de particpantes para o(s) grupo(s) informado(s)</returns>
        public async Task<IEnumerable<Core.Entidades.Participante.Participante>> SelecionarPorGrupo(long?[] ids)
        {
            return await _context.Participante
                .Include(x => x.Abrangencia)
                .Include(x => x.Grupo)
                .Include(x => x.Funcao)
                .Include(x => x.RepresentanteLegal)
                .Include(x => x.GrauEntidade)
                .Include(x => x.ParticipanteMatriz)
                .Where(x => ids.Contains(x.GrupoId)).ToListAsync();
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