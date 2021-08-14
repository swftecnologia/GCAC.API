using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Participante;
using GCAC.Core.Interfaces.Repositorios.Participante;
using GCAC.Core.Interfaces.Servicos.Participante;

namespace GCAC.Core.Servicos.Participante
{
    /// <summary>
    /// Serviços para a entidade GrauEntidade
    /// </summary>
    public class GrauEntidadeServico : IGrauEntidadeServico
    {
        /// <summary>
        /// Repositório da entidade GrauEntidade
        /// </summary>
        private readonly IGrauEntidadeRepositorio _grauEntidadeRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="grauEntidadeRepositorio">Repositório da entidade GrauEntidade</param>
        public GrauEntidadeServico(IGrauEntidadeRepositorio grauEntidadeRepositorio)
        {
            _grauEntidadeRepositorio = grauEntidadeRepositorio;
        }

        /// <summary>
        /// Seleciona todos os graus da entidade do participante
        /// </summary>
        /// <returns>Lista de graus da entidade do participante</returns>
        public async Task<IEnumerable<GrauEntidade>> SelecionarTodos()
        {
            return await _grauEntidadeRepositorio.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um grau da entidade do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da grau da entidade do participante</param>
        /// <returns>Registro da grau da entidade do participante solicitada</returns>
        public async Task<GrauEntidade> SelecionarPorId(long id)
        {
            return await _grauEntidadeRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// Cria um novo grau da entidade do participante
        /// </summary>
        /// <param name="item">Novo grau da entidade do participante a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(GrauEntidade item)
        {
            return await _grauEntidadeRepositorio.Inserir(item);
        }

        /// <summary>
        /// Atualiza um grau da entidade do participante
        /// </summary>
        /// <param name="item">Grau da entidade do participante a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(GrauEntidade item)
        {
            return await _grauEntidadeRepositorio.Atualizar(item);
        }

        /// <summary>
        /// Exclui um grau da entidade do participante
        /// </summary>
        /// <param name="item">Grau da entidade do participante a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(GrauEntidade item)
        {
            return await _grauEntidadeRepositorio.Excluir(item);
        }

        /// <summary>
        /// Verifica se o grau da entidade do participante existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do grau da entidade do participante</param>
        /// <returns>Valor indicando se o grau da entidade do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _grauEntidadeRepositorio.ExistePorDescricao(descricao);
        }

        /// <summary>
        /// Verifica se o grau da entidade do participante existe por descrição para um identificador diferente do grau da entidade do participante a ser alterada
        /// </summary>
        /// <param name="id">Identificador único do grau da entidade do participante</param>
        /// <param name="descricao">Descrição do grau da entidade do participante</param>
        /// <returns>Valor indicando se o grau da entidade do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _grauEntidadeRepositorio.ExistePorDescricao(descricao, id);
        }
    }
}