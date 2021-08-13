using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Localidade;
using GCAC.Core.Interfaces.Repositorios.Localidade;
using GCAC.Core.Interfaces.Servicos.Localidade;

namespace GCAC.Core.Servicos.Localidade
{
    /// <summary>
    /// Serviços para a entidade Municipio
    /// </summary>
    public class MunicipioServico : IMunicipioServico
    {
        /// <summary>
        /// Repositório da entidade Municipio
        /// </summary>
        private readonly IMunicipioRepositorio _municipioRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="municipioRepositorio">Repositório da entidade Municipio</param>
        public MunicipioServico(IMunicipioRepositorio municipioRepositorio)
        {
            _municipioRepositorio = municipioRepositorio;
        }

        /// <summary>
        /// Seleciona todos os registros
        /// </summary>
        /// <returns>Lista de municípioes</returns>
        public async Task<IEnumerable<Municipio>> SelecionarTodos()
        {
            return await _municipioRepositorio.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um município pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do município</param>
        /// <returns>Registro do município solicitado</returns>
        public async Task<Municipio> SelecionarPorId(long id)
        {
            return await _municipioRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// Seleciona todos os municípios pertencentes a um estado
        /// </summary>
        /// <param name="id">Identificador único do estado</param>
        /// <returns>Lista de municípios pertencentes a um estado</returns>
        public async Task<IEnumerable<Municipio>> SelecionarPorEstado(long id)
        {
            return await _municipioRepositorio.SelecionarPorEstado(id);
        }

        /// <summary>
        /// Cria um novo município
        /// </summary>
        /// <param name="item">Novo município a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Municipio item)
        {
            return await _municipioRepositorio.Inserir(item);
        }

        /// <summary>
        /// Atualiza um município
        /// </summary>
        /// <param name="item">Município a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Municipio item)
        {
            return await _municipioRepositorio.Atualizar(item);
        }

        /// <summary>
        /// Exclui um município
        /// </summary>
        /// <param name="item">Município a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Municipio item)
        {
            return await _municipioRepositorio.Excluir(item);
        }

        /// <summary>
        /// Verifica se o município existe por nome
        /// </summary>
        /// <param name="nome">Nome do município</param>
        /// <returns>Valor indicando se o município existe ou não</returns>
        public async Task<bool> ExistePorNome(string nome)
        {
            return await _municipioRepositorio.ExistePorNome(nome);
        }

        /// <summary>
        /// Verifica se o município existe por nome para um identificador diferente do município a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do município</param>
        /// <param name="nome">Nome do município</param>
        /// <returns>Valor indicando se o município existe ou não</returns>
        public async Task<bool> ExistePorNome(string nome, long id)
        {
            return await _municipioRepositorio.ExistePorNome(nome, id);
        }
    }
}