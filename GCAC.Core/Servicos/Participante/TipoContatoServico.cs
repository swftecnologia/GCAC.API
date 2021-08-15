using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Participante;
using GCAC.Core.Interfaces.Repositorios.Participante;
using GCAC.Core.Interfaces.Servicos.Participante;

namespace GCAC.Core.Servicos.Participante
{
    /// <summary>
    /// Serviços para a entidade TipoContato
    /// </summary>
    public class TipoContatoServico : ITipoContatoServico
    {
        /// <summary>
        /// Repositório da entidade TipoContato
        /// </summary>
        private readonly ITipoContatoRepositorio _tipoContatoRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="tipoContatoRepositorio">Repositório da entidade TipoContato</param>
        public TipoContatoServico(ITipoContatoRepositorio tipoContatoRepositorio)
        {
            _tipoContatoRepositorio = tipoContatoRepositorio;
        }

        /// <summary>
        /// Seleciona todos os tipos de contato do participante
        /// </summary>
        /// <returns>Lista de tipos de contato do participante</returns>
        public async Task<IEnumerable<TipoContato>> SelecionarTodos()
        {
            return await _tipoContatoRepositorio.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um tipo de contato do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do tipo de contato do participante</param>
        /// <returns>Registro do tipo de contato do participante solicitado</returns>
        public async Task<TipoContato> SelecionarPorId(long id)
        {
            return await _tipoContatoRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// Cria um novo tipo de contato do participante
        /// </summary>
        /// <param name="item">Novo tipo de contato do participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(TipoContato item)
        {
            return await _tipoContatoRepositorio.Inserir(item);
        }

        /// <summary>
        /// Atualiza um tipo de contato do participante
        /// </summary>
        /// <param name="item">Tipo de contato do participante a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(TipoContato item)
        {
            return await _tipoContatoRepositorio.Atualizar(item);
        }

        /// <summary>
        /// Exclui um tipo de contato do participante
        /// </summary>
        /// <param name="item">Tipo de contato do participante a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(TipoContato item)
        {
            return await _tipoContatoRepositorio.Excluir(item);
        }

        /// <summary>
        /// Verifica se o tipo de contato do participante existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do tipo de contato do participante</param>
        /// <returns>Valor indicando se o tipo de contato do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _tipoContatoRepositorio.ExistePorDescricao(descricao);
        }

        /// <summary>
        /// Verifica se o tipo de contato do participante existe por descrição para um identificador diferente do tipo de contato do participante a ser alterada
        /// </summary>
        /// <param name="id">Identificador único do tipo de contato do participante</param>
        /// <param name="descricao">Descrição do tipo de contato do participante</param>
        /// <returns>Valor indicando se o tipo de contato do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _tipoContatoRepositorio.ExistePorDescricao(descricao, id);
        }
    }
}