using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.Interfaces.Repositorios.InstrumentoColetivo;
using GCAC.Core.Interfaces.Servicos.InstrumentoColetivo;

namespace GCAC.Core.Servicos.InstrumentoColetivo
{
    /// <summary>
    /// Serviços para a entidade Classificacao
    /// </summary>
    public class ClassificacaoServico : IClassificacaoServico
    {
        /// <summary>
        /// Repositório da entidade Classificacao
        /// </summary>
        private readonly IClassificacaoRepositorio _classificacaoRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="classificacaoRepositorio">Repositório da entidade Classificacao</param>
        public ClassificacaoServico(IClassificacaoRepositorio classificacaoRepositorio)
        {
            _classificacaoRepositorio = classificacaoRepositorio;
        }

        /// <summary>
        /// Seleciona todos as classificações
        /// </summary>
        /// <returns>Lista de classificações</returns>
        public async Task<IEnumerable<Classificacao>> SelecionarTodos()
        {
            return await _classificacaoRepositorio.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona uma classificação pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da classificação</param>
        /// <returns>Registro da classificação solicitada</returns>
        public async Task<Classificacao> SelecionarPorId(long id)
        {
            return await _classificacaoRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// Cria uma nova classificação
        /// </summary>
        /// <param name="item">Nova classificação a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Classificacao item)
        {
            return await _classificacaoRepositorio.Inserir(item);
        }

        /// <summary>
        /// Atualiza uma classificação
        /// </summary>
        /// <param name="item">Classificação a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Classificacao item)
        {
            return await _classificacaoRepositorio.Atualizar(item);
        }

        /// <summary>
        /// Exclui uma classificação
        /// </summary>
        /// <param name="item">Classificação a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Classificacao item)
        {
            return await _classificacaoRepositorio.Excluir(item);
        }

        /// <summary>
        /// Verifica se a classificação existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição da classificação</param>
        /// <returns>Valor indicando se a classificação existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _classificacaoRepositorio.ExistePorDescricao(descricao);
        }

        /// <summary>
        /// Verifica se a classificação existe por descrição para um identificador diferente da classificação a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da classificação</param>
        /// <param name="descricao">Descrição da classificação</param>
        /// <returns>Valor indicando se a classificação existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _classificacaoRepositorio.ExistePorDescricao(descricao, id);
        }
    }
}