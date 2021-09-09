using System.Collections.Generic;
using System.Threading.Tasks;

namespace GCAC.Core.Contratos.Servicos.Participante
{
    /// <summary>
    /// Interface de serviço para a entidade Participante
    /// </summary>
    public interface IParticipanteServico
    {
        /// <summary>
        /// Seleciona todos os participantes
        /// </summary>
        /// <returns>Lista de participantes</returns>
        Task<IEnumerable<Entidades.Participante.Participante>> SelecionarTodos();

        /// <summary>
        /// Seleciona um participante pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do participante</param>
        /// <returns>Registro do participante solicitado</returns>
        Task<Entidades.Participante.Participante> SelecionarPorId(long id);

        /// <summary>
        /// Seleciona todos os particpantes pertencentes a um tipo de pessoa
        /// </summary>
        /// <param name="id">Identificador único do tipo de pessoa</param>
        /// <returns>Lista de particpantes pertencentes a um tipo de pessoa</returns>
        Task<IEnumerable<Entidades.Participante.Participante>> SelecionarPorTipoPessoa(long id);

        /// <summary>
        /// Cria um novo participante
        /// </summary>
        /// <param name="item">Novo participante a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Inserir(Entidades.Participante.Participante item);

        /// <summary>
        /// Atualiza um participante
        /// </summary>
        /// <param name="item">Participante a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Atualizar(Entidades.Participante.Participante item);

        /// <summary>
        /// Exclui um participante
        /// </summary>
        /// <param name="item">Participante a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        Task<int> Excluir(Entidades.Participante.Participante item);

        /// <summary>
        /// Verifica se o participante existe por CNPJ
        /// </summary>
        /// <param name="cnpj">CNPJ do participante</param>
        /// <returns>Valor indicando se o participante existe ou não</returns>
        Task<bool> ExistePorCNPJ(string cnpj);

        /// <summary>
        /// Verifica se o participante existe por CNPJ para um identificador diferente do participante a ser alterado
        /// </summary>
        /// <param name="id">Identificador único da participante</param>
        /// <param name="cnpj">CNPJ do participante</param>
        /// <returns>Valor indicando se o participante existe ou não</returns>
        Task<bool> ExistePorCNPJ(string cnpj, long id);

        /// <summary>
        /// Verifica se o participante existe por CPF
        /// </summary>
        /// <param name="cpf">CPF do participante</param>
        /// <returns>Valor indicando se o participante existe ou não</returns>
        Task<bool> ExistePorCPF(string cpf);

        /// <summary>
        /// Verifica se o participante existe por CPF para um identificador diferente do participante a ser alterado
        /// </summary>
        /// <param name="id">Identificador único da participante</param>
        /// <param name="cpf">CPF do participante</param>
        /// <returns>Valor indicando se o participante existe ou não</returns>
        Task<bool> ExistePorCPF(string cpf, long id);
    }
}