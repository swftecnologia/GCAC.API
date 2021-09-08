using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Participante;
using GCAC.Core.Interfaces.Repositorios.Participante;
using GCAC.Core.Interfaces.Servicos.Participante;

namespace GCAC.Core.Servicos.Participante
{
    /// <summary>
    /// Serviços para a entidade Contato
    /// </summary>
    public class ContatoServico : IContatoServico
    {
        /// <summary>
        /// Repositório da entidade Contato
        /// </summary>
        private readonly IContatoRepositorio _contatoRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="contatoRepositorio">Repositório da entidade Contato</param>
        public ContatoServico(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        /// <summary>
        /// Seleciona todas os contatos do participante
        /// </summary>
        /// <returns>Lista de contatos do participante</returns>
        public async Task<IEnumerable<Contato>> SelecionarTodos()
        {
            return await _contatoRepositorio.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um contato do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do contato do participante</param>
        /// <returns>Registro do contato do participante solicitado</returns>
        public async Task<Contato> SelecionarPorId(long id)
        {
            return await _contatoRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// Seleciona todos os contatos pertencentes a um participante
        /// </summary>
        /// <param name="id">Identificador único do participante</param>
        /// <returns>Lista de contatos pertencentes a um participante</returns>
        public async Task<IEnumerable<Contato>> SelecionarPorParticipante(long id)
        {
            return await _contatoRepositorio.SelecionarPorParticipante(id);
        }

        /// <summary>
        /// Cria um novo contato do participante
        /// </summary>
        /// <param name="item">Novo contato do participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Contato item)
        {
            return await _contatoRepositorio.Inserir(item);
        }

        /// <summary>
        /// Atualiza um contato do participante
        /// </summary>
        /// <param name="item">Contato do participante a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Contato item)
        {
            return await _contatoRepositorio.Atualizar(item);
        }

        /// <summary>
        /// Exclui um contato do participante
        /// </summary>
        /// <param name="item">Contato do participante a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Contato item)
        {
            return await _contatoRepositorio.Excluir(item);
        }

        /// <summary>
        /// Verifica se o contato do participante existe
        /// </summary>
        /// <param name="idParticipante">Identificador único do participante</param>
        /// <param name="idTipoContato">Identificador único do tipo de contato do participante</param>
        /// <param name="contatoParticipante">Contato do participante</param>
        /// <returns>Valor indicando se o contato do participante existe ou não</returns>
        public async Task<bool> ExistePorContatoParticipante(long idParticipante, long idTipoContato, string contatoParticipante)
        {
            return await _contatoRepositorio.ExistePorContatoParticipante(idParticipante, idTipoContato, contatoParticipante);
        }

        /// <summary>
        /// Verifica se o contato do participante existe para um identificador diferente do contato do participante a ser alterado
        /// </summary>
        /// <param name="idParticipante">Identificador único do participante</param>
        /// <param name="idTipoContato">Identificador único do tipo de contato do participante</param>
        /// <param name="id">Identificador único do contato do participante</param>
        /// <param name="contatoParticipante">Contato do participante</param>
        /// <returns>Valor indicando se o contato do participante existe ou não</returns>
        public async Task<bool> ExistePorContatoParticipante(long idParticipante, long idTipoContato, string contatoParticipante, long id)
        {
            return await _contatoRepositorio.ExistePorContatoParticipante(idParticipante, idTipoContato, contatoParticipante, id);
        }
    }
}