using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Localidade;
using GCAC.Core.Interfaces.Repositorios.Localidade;
using GCAC.Core.Interfaces.Servicos.Localidade;

namespace GCAC.Core.Servicos.Localidade
{
    /// <summary>
    /// Serviços para a entidade Regiao
    /// </summary>
    public class RegiaoServico : IRegiaoServico
    {
        /// <summary>
        /// Repositório da entidade Regiao
        /// </summary>
        private readonly IRegiaoRepositorio _regiaoRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="regiaoRepositorio">Repositório da entidade Regiao</param>
        public RegiaoServico(IRegiaoRepositorio regiaoRepositorio)
        {
            _regiaoRepositorio = regiaoRepositorio;
        }

        /// <summary>
        /// Seleciona todos as regiões
        /// </summary>
        /// <returns>Lista de regiões</returns>
        public async Task<IEnumerable<Regiao>> SelecionarTodos()
        {
            return await _regiaoRepositorio.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona uma região pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da região</param>
        /// <returns>Registro da região solicitada</returns>
        public async Task<Regiao> SelecionarPorId(long id)
        {
            return await _regiaoRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// Cria uma nova região
        /// </summary>
        /// <param name="item">Nova região a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Regiao item)
        {
            return await _regiaoRepositorio.Inserir(item);
        }

        /// <summary>
        /// Atualiza uma região
        /// </summary>
        /// <param name="item">Região a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Regiao item)
        {
            return await _regiaoRepositorio.Atualizar(item);
        }

        /// <summary>
        /// Exclui uma região
        /// </summary>
        /// <param name="item">Região a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Regiao item)
        {
            return await _regiaoRepositorio.Excluir(item);
        }

        /// <summary>
        /// Verifica se a região existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição da região</param>
        /// <returns>Valor indicando se a região existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _regiaoRepositorio.ExistePorDescricao(descricao);
        }

        /// <summary>
        /// Verifica se a região existe por descrição para um identificador diferente da região a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da região</param>
        /// <param name="descricao">Descrição da região</param>
        /// <returns>Valor indicando se a região existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _regiaoRepositorio.ExistePorDescricao(descricao, id);
        }
    }
}