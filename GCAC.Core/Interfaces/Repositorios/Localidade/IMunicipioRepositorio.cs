using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Localidade;

namespace GCAC.Core.Interfaces.Repositorios.Localidade
{
    /// <summary>
    /// Interface de repositório para a entidade Municipio
    /// </summary>
    public interface IMunicipioRepositorio
    {
        /// <summary>
        /// Seleciona todos os municípios
        /// </summary>
        /// <returns>Lista de municípios</returns>
        Task<IEnumerable<Municipio>> SelecionarTodos();

        /// <summary>
        /// Seleciona um município pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do município</param>
        /// <returns>Registro do município solicitado</returns>
        Task<Municipio> SelecionarPorId(long id);

        /// <summary>
        /// Seleciona todos os municípios pertencentes a um estado
        /// </summary>
        /// <param name="id">Identificador único do estado</param>
        /// <returns>Lista de municípios pertencentes a um estado</returns>
        Task<IEnumerable<Municipio>> SelecionarPorEstado(long id);

        /// <summary>
        /// Cria um novo município
        /// </summary>
        /// <param name="item">Novo município a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Inserir(Municipio item);

        /// <summary>
        /// Atualiza um município
        /// </summary>
        /// <param name="item">Município a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Atualizar(Municipio item);

        /// <summary>
        /// Exclui um município
        /// </summary>
        /// <param name="item">Município a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Excluir(Municipio item);

        /// <summary>
        /// Verifica se o município existe por nome
        /// </summary>
        /// <param name="nome">Nome do município</param>
        /// <returns>Valor indicando se o município existe ou não</returns>
        Task<bool> ExistePorNome(string nome);

        /// <summary>
        /// Verifica se o município existe por nome para um identificador diferente do município a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do município</param>
        /// <param name="nome">Nome do município</param>
        /// <returns>Valor indicando se o município existe ou não</returns>
        Task<bool> ExistePorNome(string nome, long id);
    }
}