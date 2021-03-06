using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.Interfaces.Repositorios.InstrumentoColetivo;
using GCAC.Core.Interfaces.Servicos.InstrumentoColetivo;

namespace GCAC.Core.Servicos.InstrumentoColetivo
{
    /// <summary>
    /// Serviços para a entidade ClausulaGrupo
    /// </summary>
    public class ClausulaGrupoServico : IClausulaGrupoServico
    {
        /// <summary>
        /// Repositório da entidade ClausulaGrupo
        /// </summary>
        private readonly IClausulaGrupoRepositorio _clausulaGrupoRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="clausulaGrupoRepositorio">Repositório da entidade ClausulaGrupo</param>
        public ClausulaGrupoServico(IClausulaGrupoRepositorio clausulaGrupoRepositorio)
        {
            _clausulaGrupoRepositorio = clausulaGrupoRepositorio;
        }

        /// <summary>
        /// Seleciona todos os grupos da cláusula
        /// </summary>
        /// <returns>Lista de grupos da cláusula</returns>
        public async Task<IEnumerable<ClausulaGrupo>> SelecionarTodos()
        {
            return await _clausulaGrupoRepositorio.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um grupo da cláusula pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do grupo da cláusula</param>
        /// <returns>Registro do grupo da cláusula solicitada</returns>
        public async Task<ClausulaGrupo> SelecionarPorId(long id)
        {
            return await _clausulaGrupoRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// Cria um novo grupo da cláusula
        /// </summary>
        /// <param name="item">Novo grupo da cláusula a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(ClausulaGrupo item)
        {
            return await _clausulaGrupoRepositorio.Inserir(item);
        }

        /// <summary>
        /// Atualiza um grupo da cláusula
        /// </summary>
        /// <param name="item">Grupo da cláusula a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(ClausulaGrupo item)
        {
            return await _clausulaGrupoRepositorio.Atualizar(item);
        }

        /// <summary>
        /// Exclui um grupo da cláusula
        /// </summary>
        /// <param name="item">Grupo da cláusula a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(ClausulaGrupo item)
        {
            return await _clausulaGrupoRepositorio.Excluir(item);
        }

        /// <summary>
        /// Verifica se o grupo da cláusula existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do grupo da cláusula</param>
        /// <returns>Valor indicando se o grupo da cláusula existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _clausulaGrupoRepositorio.ExistePorDescricao(descricao);
        }

        /// <summary>
        /// Verifica se o grupo da cláusula existe por descrição para um identificador diferente do grupo da cláusula a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do grupo da cláusula</param>
        /// <param name="descricao">Descrição do grupo da cláusula</param>
        /// <returns>Valor indicando se o grupo da cláusula existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _clausulaGrupoRepositorio.ExistePorDescricao(descricao, id);
        }
    }
}