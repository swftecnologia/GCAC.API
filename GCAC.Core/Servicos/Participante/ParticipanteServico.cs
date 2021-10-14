using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Contratos.Repositorios.Participante;
using GCAC.Core.Contratos.Servicos.Participante;

namespace GCAC.Core.Servicos.Participante
{
    /// <summary>
    /// Serviços para a entidade Participante
    /// </summary>
    public class ParticipanteServico : IParticipanteServico
    {
        /// <summary>
        /// Repositório da entidade Participante
        /// </summary>
        private readonly IParticipanteRepositorio _participanteRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="participanteRepositorio">Repositório da entidade Participante</param>
        public ParticipanteServico(IParticipanteRepositorio participanteRepositorio)
        {
            _participanteRepositorio = participanteRepositorio;
        }

        /// <summary>
        /// Seleciona todos os participantes
        /// </summary>
        /// <returns>Lista de participantes</returns>
        public async Task<IEnumerable<Entidades.Participante.Participante>> SelecionarTodos()
        {
            return await _participanteRepositorio.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do participante</param>
        /// <returns>Registro do participante solicitado</returns>
        public async Task<Entidades.Participante.Participante> SelecionarPorId(long id)
        {
            return await _participanteRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// Seleciona todos os particpantes pertencentes a um tipo de pessoa
        /// </summary>
        /// <param name="id">Identificador único do tipo de pessoa</param>
        /// <returns>Lista de particpantes pertencentes a um tipo de pessoa</returns>
        public async Task<IEnumerable<Entidades.Participante.Participante>> SelecionarPorTipoPessoa(long id)
        {
            return await _participanteRepositorio.SelecionarPorTipoPessoa(id);
        }

        /// <summary>
        /// Lista todos os particpantes que são ou que não são entidades sindicais
        /// </summary>
        /// <param name="entidadeSindical">Indica se deve considerar apenas entidades sindicais</param>
        /// <returns>Lista de participantes que são ou que não são entidades sindicais</returns>
        public async Task<IEnumerable<Entidades.Participante.Participante>> SelecionarPorEntidadeSindical(bool entidadeSindical)
        {
            return await _participanteRepositorio.SelecionarPorEntidadeSindical(entidadeSindical);
        }

        /// <summary>
        /// Lista todos os particpantes para o(s) grupo(s) informado(s)
        /// </summary>
        /// <param name="ids">Identificador(es) único(s) do(s) grupo(s)</param>
        /// <returns>Lista de particpantes para o(s) grupo(s) informado(s)</returns>
        public async Task<IEnumerable<Entidades.Participante.Participante>> SelecionarPorGrupo(long?[] ids)
        {
            return await _participanteRepositorio.SelecionarPorGrupo(ids);
        }

        /// <summary>
        /// Cria um novo participante
        /// </summary>
        /// <param name="item">Novo participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Entidades.Participante.Participante item)
        {
            return await _participanteRepositorio.Inserir(item);
        }

        /// <summary>
        /// Atualiza um participante
        /// </summary>
        /// <param name="item">Participante a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Entidades.Participante.Participante item)
        {
            return await _participanteRepositorio.Atualizar(item);
        }

        /// <summary>
        /// Exclui um participante
        /// </summary>
        /// <param name="item">Participante a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Entidades.Participante.Participante item)
        {
            return await _participanteRepositorio.Excluir(item);
        }

        /// <summary>
        /// Verifica se o participante existe por CNPJ
        /// </summary>
        /// <param name="cnpj">CNPJ do participante</param>
        /// <returns>Valor indicando se o participante existe ou não</returns>
        public async Task<bool> ExistePorCNPJ(string cnpj)
        {
            return await _participanteRepositorio.ExistePorCNPJ(cnpj);
        }

        /// <summary>
        /// Verifica se o participante existe por CNPJ para um identificador diferente do participante a ser alterado
        /// </summary>
        /// <param name="id">Identificador único da participante</param>
        /// <param name="cnpj">CNPJ do participante</param>
        /// <returns>Valor indicando se o participante existe ou não</returns>
        public async Task<bool> ExistePorCNPJ(string cnpj, long id)
        {
            return await _participanteRepositorio.ExistePorCNPJ(cnpj, id);
        }

        /// <summary>
        /// Verifica se o participante existe por CPF
        /// </summary>
        /// <param name="cpf">CPF do participante</param>
        /// <returns>Valor indicando se o participante existe ou não</returns>
        public async Task<bool> ExistePorCPF(string cpf)
        {
            return await _participanteRepositorio.ExistePorCPF(cpf);
        }

        /// <summary>
        /// Verifica se o participante existe por CPF para um identificador diferente do participante a ser alterado
        /// </summary>
        /// <param name="id">Identificador único da participante</param>
        /// <param name="cpf">CPF do participante</param>
        /// <returns>Valor indicando se o participante existe ou não</returns>
        public async Task<bool> ExistePorCPF(string cpf, long id)
        {
            return await _participanteRepositorio.ExistePorCPF(cpf, id);
        }
    }
}