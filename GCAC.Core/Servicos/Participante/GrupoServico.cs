using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Participante;
using GCAC.Core.Interfaces.Repositorios.Participante;
using GCAC.Core.Interfaces.Servicos.Participante;

namespace GCAC.Core.Servicos.Participante
{
    /// <summary>
    /// Serviços para a entidade Grupo
    /// </summary>
    public class GrupoServico : IGrupoServico
    {
        /// <summary>
        /// Repositório da entidade Grupo
        /// </summary>
        private readonly IGrupoRepositorio _grupoRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="grupoRepositorio">Repositório da entidade Grupo</param>
        public GrupoServico(IGrupoRepositorio grupoRepositorio)
        {
            _grupoRepositorio = grupoRepositorio;
        }

        /// <summary>
        /// Seleciona todos os registros
        /// </summary>
        /// <returns>Lista de grupos</returns>
        public async Task<IEnumerable<Grupo>> SelecionarTodos()
        {
            return await _grupoRepositorio.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um grupo pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do grupo</param>
        /// <returns>Registro do grupo solicitado</returns>
        public async Task<Grupo> SelecionarPorId(long id)
        {
            return await _grupoRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// Cria um novo grupo
        /// </summary>
        /// <param name="item">Novo grupo a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Grupo item)
        {
            return await _grupoRepositorio.Inserir(item);
        }

        /// <summary>
        /// Atualiza um grupo
        /// </summary>
        /// <param name="item">Grupo a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Grupo item)
        {
            return await _grupoRepositorio.Atualizar(item);
        }

        /// <summary>
        /// Exclui um grupo
        /// </summary>
        /// <param name="item">Grupo a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Grupo item)
        {
            return await _grupoRepositorio.Excluir(item);
        }

        /// <summary>
        /// Verifica se o grupo existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do grupo</param>
        /// <returns>Valor indicando se o grupo existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _grupoRepositorio.ExistePorDescricao(descricao);
        }

        /// <summary>
        /// Verifica se o grupo existe por nome para um identificador diferente do grupo a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do grupo</param>
        /// <param name="descricao">Descrição do grupo</param>
        /// <returns>Valor indicando se o grupo existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _grupoRepositorio.ExistePorDescricao(descricao, id);
        }
    }
}