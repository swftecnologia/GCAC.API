using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Participante;
using GCAC.Core.Interfaces.Repositorios.Participante;
using GCAC.Core.Interfaces.Servicos.Participante;

namespace GCAC.Core.Servicos.Participante
{
    /// <summary>
    /// Serviços para a entidade Funcao
    /// </summary>
    public class FuncaoServico : IFuncaoServico
    {
        /// <summary>
        /// Repositório da entidade Funcao
        /// </summary>
        private readonly IFuncaoRepositorio _funcaoRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="funcaoRepositorio">Repositório da entidade Funcao</param>
        public FuncaoServico(IFuncaoRepositorio funcaoRepositorio)
        {
            _funcaoRepositorio = funcaoRepositorio;
        }

        /// <summary>
        /// Seleciona todas as funções do participante
        /// </summary>
        /// <returns>Lista de funções do participante</returns>
        public async Task<IEnumerable<Funcao>> SelecionarTodos()
        {
            return await _funcaoRepositorio.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona uma função do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da função do participante</param>
        /// <returns>Registro da função do participante solicitada</returns>
        public async Task<Funcao> SelecionarPorId(long id)
        {
            return await _funcaoRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// Cria uma nova função do participante
        /// </summary>
        /// <param name="item">Nova função do participante a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Funcao item)
        {
            return await _funcaoRepositorio.Inserir(item);
        }

        /// <summary>
        /// Atualiza uma função do participante
        /// </summary>
        /// <param name="item">Função do participante a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Funcao item)
        {
            return await _funcaoRepositorio.Atualizar(item);
        }

        /// <summary>
        /// Exclui uma função do participante
        /// </summary>
        /// <param name="item">Função do participante a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Funcao item)
        {
            return await _funcaoRepositorio.Excluir(item);
        }

        /// <summary>
        /// Verifica se a função do participante existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição da função do participante</param>
        /// <returns>Valor indicando se a função do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _funcaoRepositorio.ExistePorDescricao(descricao);
        }

        /// <summary>
        /// Verifica se a função do participante existe por descrição para um identificador diferente da função do participante a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da função do participante</param>
        /// <param name="descricao">Descrição da função do participante</param>
        /// <returns>Valor indicando se a função do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _funcaoRepositorio.ExistePorDescricao(descricao, id);
        }
    }
}