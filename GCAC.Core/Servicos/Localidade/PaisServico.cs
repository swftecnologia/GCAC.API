using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Localidade;
using GCAC.Core.Interfaces.Repositorios.Localidade;
using GCAC.Core.Interfaces.Servicos.Localidade;

namespace GCAC.Core.Servicos.Localidade
{
    /// <summary>
    /// Serviços para a entidade Pais
    /// </summary>
    public class PaisServico : IPaisServico
    {
        /// <summary>
        /// Repositório da entidade Pais
        /// </summary>
        private readonly IPaisRepositorio _paisRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="paisRepositorio">Repositório da entidade Pais</param>
        public PaisServico(IPaisRepositorio paisRepositorio)
        {
            _paisRepositorio = paisRepositorio;
        }

        /// <summary>
        /// Seleciona todos os registros
        /// </summary>
        /// <returns>Lista de países</returns>
        public async Task<IEnumerable<Pais>> SelecionarTodos()
        {
            return await _paisRepositorio.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um país pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do país</param>
        /// <returns>Registro do país solicitado</returns>
        public async Task<Pais> SelecionarPorId(long id)
        {
            return await _paisRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// Cria um novo país
        /// </summary>
        /// <param name="item">Novo país a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Pais item)
        {
            return await _paisRepositorio.Inserir(item);
        }

        /// <summary>
        /// Atualiza um país
        /// </summary>
        /// <param name="item">País a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Pais item)
        {
            return await _paisRepositorio.Atualizar(item);
        }

        /// <summary>
        /// Exclui um país
        /// </summary>
        /// <param name="item">País a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Pais item)
        {
            return await _paisRepositorio.Excluir(item);
        }

        /// <summary>
        /// Verifica se o país existe por nome
        /// </summary>
        /// <param name="nome">Nome do país</param>
        /// <returns>Valor indicando se o país existe ou não</returns>
        public async Task<bool> ExistePorNome(string nome)
        {
            return await _paisRepositorio.ExistePorNome(nome);
        }

        /// <summary>
        /// Verifica se o país existe por nome para um identificador diferente do país a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do país</param>
        /// <param name="nome">Nome do país</param>
        /// <returns>Valor indicando se o país existe ou não</returns>
        public async Task<bool> ExistePorNome(string nome, long id)
        {
            return await _paisRepositorio.ExistePorNome(nome, id);
        }
    }
}