using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Interfaces.Repositorios.Participante;
using GCAC.Core.Interfaces.Servicos.Participante;

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
        /// Seleciona todas os participantes
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
        /// Cria um nova participante
        /// </summary>
        /// <param name="item">Nova participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Entidades.Participante.Participante item)
        {
            return await _participanteRepositorio.Inserir(item);
        }

        /// <summary>
        /// Atualiza uma participante do participante
        /// </summary>
        /// <param name="item">Participante do participante a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Entidades.Participante.Participante item)
        {
            return await _participanteRepositorio.Atualizar(item);
        }

        /// <summary>
        /// Exclui uma participante
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