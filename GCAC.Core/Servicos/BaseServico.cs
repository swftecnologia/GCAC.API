using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Contratos.Repositorios;
using GCAC.Core.Contratos.Servicos;

namespace GCAC.Core.Servicos.Participante
{
    /// <summary>
    /// Implementação de serviço base
    /// </summary>
    public class BaseServico<T> : IBaseServico<T> where T : class
    {
        /// <summary>
        /// Repositório base
        /// </summary>
        private readonly IBaseRepositorio<T> _baseRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="baseRepositorio">Repositório base</param>
        public BaseServico(IBaseRepositorio<T> baseRepositorio)
        {
            _baseRepositorio = baseRepositorio;
        }

        /// <summary>
        /// Seleciona todos os registros
        /// </summary>
        /// <returns>Lista de registros</returns>
        public async Task<IEnumerable<T>> SelecionarTodos()
        {
            return await _baseRepositorio.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um registro pelo seu identificador único
        /// </summary>
        /// <param name="id">Identificador único</param>
        /// <returns>Registro solicitado</returns>
        public async Task<T> SelecionarPorId(long id)
        {
            return await _baseRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// Insere um novo registro
        /// </summary>
        /// <param name="item">Novo registro a ser inserido</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(T item)
        {
            return await _baseRepositorio.Inserir(item);
        }

        /// <summary>
        /// Atualiza um registro existente
        /// </summary>
        /// <param name="item">Registro a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(T item)
        {
            return await _baseRepositorio.Atualizar(item);
        }

        /// <summary>
        /// Exclui um registro existente
        /// </summary>
        /// <param name="item">Registro a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(T item)
        {
            return await _baseRepositorio.Excluir(item);
        }
    }
}