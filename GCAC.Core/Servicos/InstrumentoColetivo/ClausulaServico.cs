using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.Interfaces.Repositorios.InstrumentoColetivo;
using GCAC.Core.Interfaces.Servicos.InstrumentoColetivo;

namespace GCAC.Core.Servicos.InstrumentoColetivo
{
    /// <summary>
    /// Serviços para a entidade Clausula
    /// </summary>
    public class ClausulaServico : IClausulaServico
    {
        /// <summary>
        /// Repositório da entidade Clausula
        /// </summary>
        private readonly IClausulaRepositorio _clausulaRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="clausulaRepositorio">Repositório da entidade Clausula</param>
        public ClausulaServico(IClausulaRepositorio clausulaRepositorio)
        {
            _clausulaRepositorio = clausulaRepositorio;
        }

        /// <summary>
        /// Seleciona todas as cláusulas
        /// </summary>
        /// <returns>Lista de cláusulas</returns>
        public async Task<IEnumerable<Clausula>> SelecionarTodos()
        {
            return await _clausulaRepositorio.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona uma cláusula pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da cláusula</param>
        /// <returns>Registro da cláusula solicitada</returns>
        public async Task<Clausula> SelecionarPorId(long id)
        {
            return await _clausulaRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// Seleciona todos as cláusulas pertencentes a um sub-grupo da cláusula
        /// </summary>
        /// <param name="id">Identificador único do sub-grupo da cláusula</param>
        /// <returns>Lista de cláusulas pertencentes a um sub-grupo da cláusula</returns>
        public async Task<IEnumerable<Clausula>> SelecionarPorClausulaSubGrupo(long id)
        {
            return await _clausulaRepositorio.SelecionarPorClausulaSubGrupo(id);
        }

        /// <summary>
        /// Cria uma nova cláusula
        /// </summary>
        /// <param name="item">Nova cláusula a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Clausula item)
        {
            return await _clausulaRepositorio.Inserir(item);
        }

        /// <summary>
        /// Atualiza uma cláusula
        /// </summary>
        /// <param name="item">Cláusula a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Clausula item)
        {
            return await _clausulaRepositorio.Atualizar(item);
        }

        /// <summary>
        /// Exclui uma cláusula
        /// </summary>
        /// <param name="item">Cláusula a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Clausula item)
        {
            return await _clausulaRepositorio.Excluir(item);
        }

        /// <summary>
        /// Verifica se a cláusula existe por título
        /// </summary>
        /// <param name="titulo">Título da cláusula</param>
        /// <returns>Valor indicando se a cláusula existe ou não</returns>
        public async Task<bool> ExistePorTitulo(string titulo)
        {
            return await _clausulaRepositorio.ExistePorTitulo(titulo);
        }

        /// <summary>
        /// Verifica se a cláusula existe por título para um identificador diferente da cláusula a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da cláusula</param>
        /// <param name="titulo">Título da cláusula</param>
        /// <returns>Valor indicando se a cláusula existe ou não</returns>
        public async Task<bool> ExistePorTitulo(string titulo, long id)
        {
            return await _clausulaRepositorio.ExistePorTitulo(titulo, id);
        }
    }
}