using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Localidade;
using GCAC.Core.Interfaces.Repositorios.Localidade;
using GCAC.Core.Interfaces.Servicos.Localidade;

namespace GCAC.Core.Servicos.Localidade
{
    /// <summary>
    /// Serviços para a entidade Estado
    /// </summary>
    public class EstadoServico : IEstadoServico
    {
        /// <summary>
        /// Repositório da entidade Estado
        /// </summary>
        private readonly IEstadoRepositorio _estadoRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="estadoRepositorio">Repositório da entidade Estado</param>
        public EstadoServico(IEstadoRepositorio estadoRepositorio)
        {
            _estadoRepositorio = estadoRepositorio;
        }

        /// <summary>
        /// Seleciona todos os estados
        /// </summary>
        /// <returns>Lista de estado</returns>
        public async Task<IEnumerable<Estado>> SelecionarTodos()
        {
            return await _estadoRepositorio.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um estado pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do estado</param>
        /// <returns>Registro do estado solicitado</returns>
        public async Task<Estado> SelecionarPorId(long id)
        {
            return await _estadoRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// Seleciona todos os estados pertencentes a um país
        /// </summary>
        /// <param name="id">Identificador único do país</param>
        /// <returns>Lista de estados pertencentes a um país</returns>
        public async Task<IEnumerable<Estado>> SelecionarPorPais(long id)
        {
            return await _estadoRepositorio.SelecionarPorPais(id);
        }

        /// <summary>
        /// Cria um novo estado
        /// </summary>
        /// <param name="item">Novo estado a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Estado item)
        {
            return await _estadoRepositorio.Inserir(item);
        }

        /// <summary>
        /// Atualiza um estado
        /// </summary>
        /// <param name="item">Estado a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Estado item)
        {
            return await _estadoRepositorio.Atualizar(item);
        }

        /// <summary>
        /// Exclui um estado
        /// </summary>
        /// <param name="item">Estado a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Estado item)
        {
            return await _estadoRepositorio.Excluir(item);
        }

        /// <summary>
        /// Verifica se o estado existe por nome
        /// </summary>
        /// <param name="nome">Nome do estado</param>
        /// <returns>Valor indicando se o estado existe ou não</returns>
        public async Task<bool> ExistePorNome(string nome)
        {
            return await _estadoRepositorio.ExistePorNome(nome);
        }

        /// <summary>
        /// Verifica se o estado existe por nome para um identificador diferente do estado a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do estado</param>
        /// <param name="nome">Nome do estado</param>
        /// <returns>Valor indicando se o estado existe ou não</returns>
        public async Task<bool> ExistePorNome(string nome, long id)
        {
            return await _estadoRepositorio.ExistePorNome(nome, id);
        }
    }
}