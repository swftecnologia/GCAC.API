using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.Interfaces.Repositorios.InstrumentoColetivo;
using GCAC.Core.Interfaces.Servicos.InstrumentoColetivo;

namespace GCAC.Core.Servicos.InstrumentoColetivo
{
    /// <summary>
    /// Serviços para a entidade Abrangencia
    /// </summary>
    public class AbrangenciaServico : IAbrangenciaServico
    {
        /// <summary>
        /// Repositório da entidade Abrangencia
        /// </summary>
        private readonly IAbrangenciaRepositorio _abrangenciaRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="abrangenciaRepositorio">Repositório da entidade Abrangencia</param>
        public AbrangenciaServico(IAbrangenciaRepositorio abrangenciaRepositorio)
        {
            _abrangenciaRepositorio = abrangenciaRepositorio;
        }

        /// <summary>
        /// Seleciona todos as abrangências
        /// </summary>
        /// <returns>Lista de abrangências</returns>
        public async Task<IEnumerable<Abrangencia>> SelecionarTodos()
        {
            return await _abrangenciaRepositorio.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona uma abrangência pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da abrangência</param>
        /// <returns>Registro da abrangência solicitada</returns>
        public async Task<Abrangencia> SelecionarPorId(long id)
        {
            return await _abrangenciaRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// Cria uma nova abrangência
        /// </summary>
        /// <param name="item">Nova abrangência a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Abrangencia item)
        {
            return await _abrangenciaRepositorio.Inserir(item);
        }

        /// <summary>
        /// Atualiza uma abrangência
        /// </summary>
        /// <param name="item">Abrangência a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Abrangencia item)
        {
            return await _abrangenciaRepositorio.Atualizar(item);
        }

        /// <summary>
        /// Exclui uma abrangência
        /// </summary>
        /// <param name="item">Abrangência a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Abrangencia item)
        {
            return await _abrangenciaRepositorio.Excluir(item);
        }

        /// <summary>
        /// Verifica se a abrangência existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição da abrangência</param>
        /// <returns>Valor indicando se a abrangência existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _abrangenciaRepositorio.ExistePorDescricao(descricao);
        }

        /// <summary>
        /// Verifica se a abrangência existe por descrição para um identificador diferente da abrangência a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da abrangência</param>
        /// <param name="descricao">Descrição da abrangência</param>
        /// <returns>Valor indicando se a abrangência existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _abrangenciaRepositorio.ExistePorDescricao(descricao, id);
        }
    }
}