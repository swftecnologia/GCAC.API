using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.Interfaces.Repositorios.InstrumentoColetivo;
using GCAC.Core.Interfaces.Servicos.InstrumentoColetivo;

namespace GCAC.Core.Servicos.InstrumentoColetivo
{
    /// <summary>
    /// Serviços para a entidade EntidadeSindical
    /// </summary>
    public class EntidadeSindicalServico : IEntidadeSindicalServico
    {
        /// <summary>
        /// Repositório da entidade EntidadeSindical
        /// </summary>
        private readonly IEntidadeSindicalRepositorio _entidadeSindicalRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="entidadeSindicalRepositorio">Repositório da entidade EntidadeSindical</param>
        public EntidadeSindicalServico(IEntidadeSindicalRepositorio entidadeSindicalRepositorio)
        {
            _entidadeSindicalRepositorio = entidadeSindicalRepositorio;
        }

        /// <summary>
        /// Seleciona todas as entidades sindicais
        /// </summary>
        /// <returns>Lista de entidades sindicais</returns>
        public async Task<IEnumerable<EntidadeSindical>> SelecionarTodos()
        {
            return await _entidadeSindicalRepositorio.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona uma entidade sindical pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da entidade sindical</param>
        /// <returns>Registro da entidade sindical solicitada</returns>
        public async Task<EntidadeSindical> SelecionarPorId(long id)
        {
            return await _entidadeSindicalRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// Cria uma nova entidade sindical
        /// </summary>
        /// <param name="item">Nova entidade sindical a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(EntidadeSindical item)
        {
            return await _entidadeSindicalRepositorio.Inserir(item);
        }

        /// <summary>
        /// Atualiza uma entidade sindical
        /// </summary>
        /// <param name="item">Entidade sindical a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(EntidadeSindical item)
        {
            return await _entidadeSindicalRepositorio.Atualizar(item);
        }

        /// <summary>
        /// Exclui uma entidade sindical
        /// </summary>
        /// <param name="item">Entidade sindical a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(EntidadeSindical item)
        {
            return await _entidadeSindicalRepositorio.Excluir(item);
        }

        /// <summary>
        /// Verifica se a entidade sindical existe por título
        /// </summary>
        /// <param name="cnpj">CNPJ da entidade sindical</param>
        /// <returns>Valor indicando se a entidade sindical existe ou não</returns>
        public async Task<bool> ExistePorCNPJ(string cnpj)
        {
            return await _entidadeSindicalRepositorio.ExistePorCNPJ(cnpj);
        }

        /// <summary>
        /// Verifica se a entidade sindical existe por título para um identificador diferente da entidade sindical a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da entidade sindical</param>
        /// <param name="cnpj">CNPJ da entidade sindical</param>
        /// <returns>Valor indicando se a entidade sindical existe ou não</returns>
        public async Task<bool> ExistePorCNPJ(string cnpj, long id)
        {
            return await _entidadeSindicalRepositorio.ExistePorCNPJ(cnpj, id);
        }
    }
}