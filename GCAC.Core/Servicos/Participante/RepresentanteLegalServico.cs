using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.Participante;
using GCAC.Core.Contratos.Repositorios.Participante;
using GCAC.Core.Contratos.Servicos.Participante;

namespace GCAC.Core.Servicos.Participante
{
    /// <summary>
    /// Serviços para a entidade RepresentanteLegal
    /// </summary>
    public class RepresentanteLegalServico : IRepresentanteLegalServico
    {
        /// <summary>
        /// Repositório da entidade RepresentanteLegal
        /// </summary>
        private readonly IRepresentanteLegalRepositorio _representanteLegalRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="representanteLegalRepositorio">Repositório da entidade RepresentanteLegal</param>
        public RepresentanteLegalServico(IRepresentanteLegalRepositorio representanteLegalRepositorio)
        {
            _representanteLegalRepositorio = representanteLegalRepositorio;
        }

        /// <summary>
        /// Seleciona todos os representantes legais do participante
        /// </summary>
        /// <returns>Lista de representantes legais do participante</returns>
        public async Task<IEnumerable<RepresentanteLegal>> SelecionarTodos()
        {
            return await _representanteLegalRepositorio.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um representante legal do participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do representante legal do participante</param>
        /// <returns>Registro do representante legal do participante solicitado</returns>
        public async Task<RepresentanteLegal> SelecionarPorId(long id)
        {
            return await _representanteLegalRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// Cria um novo representante legal do participante
        /// </summary>
        /// <param name="item">Novo representante legal do participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(RepresentanteLegal item)
        {
            return await _representanteLegalRepositorio.Inserir(item);
        }

        /// <summary>
        /// Atualiza um representante legal do participante
        /// </summary>
        /// <param name="item">Representante legal do participante a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(RepresentanteLegal item)
        {
            return await _representanteLegalRepositorio.Atualizar(item);
        }

        /// <summary>
        /// Exclui um representante legal do participante
        /// </summary>
        /// <param name="item">Representante legal do participante a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(RepresentanteLegal item)
        {
            return await _representanteLegalRepositorio.Excluir(item);
        }

        /// <summary>
        /// Verifica se o representante legal do participante existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do representante legal do participante</param>
        /// <returns>Valor indicando se o representante legal do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _representanteLegalRepositorio.ExistePorDescricao(descricao);
        }

        /// <summary>
        /// Verifica se o representante legal do participante existe por descrição para um identificador diferente do representante legal do participante a ser alterada
        /// </summary>
        /// <param name="id">Identificador único do representante legal do participante</param>
        /// <param name="descricao">Descrição do representante legal do participante</param>
        /// <returns>Valor indicando se o representante legal do participante existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _representanteLegalRepositorio.ExistePorDescricao(descricao, id);
        }
    }
}