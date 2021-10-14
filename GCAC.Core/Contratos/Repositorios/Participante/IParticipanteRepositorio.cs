using System.Collections.Generic;
using System.Threading.Tasks;

namespace GCAC.Core.Contratos.Repositorios.Participante
{
    /// <summary>
    /// Interface de repositório para a entidade Participante
    /// </summary>
    public interface IParticipanteRepositorio : IBaseRepositorio<Entidades.Participante.Participante>
    {
        /// <summary>
        /// Seleciona todos os particpantes pertencentes a um tipo de pessoa
        /// </summary>
        /// <param name="id">Identificador único do tipo de pessoa</param>
        /// <returns>Lista de particpantes pertencentes a um tipo de pessoa</returns>
        Task<IEnumerable<Entidades.Participante.Participante>> SelecionarPorTipoPessoa(long id);

        /// <summary>
        /// Lista todos os particpantes que são ou que não são entidades sindicais
        /// </summary>
        /// <param name="entidadeSindical">Indica se deve considerar apenas entidades sindicais</param>
        /// <returns>Lista de participantes que são ou que não são entidades sindicais</returns>
        Task<IEnumerable<Entidades.Participante.Participante>> SelecionarPorEntidadeSindical(bool entidadeSindical);

        /// <summary>
        /// Lista todos os particpantes para o(s) grupo(s) informado(s)
        /// </summary>
        /// <param name="ids">Identificador(es) único(s) do(s) grupo(s)</param>
        /// <returns>Lista de particpantes para o(s) grupo(s) informado(s)</returns>
        Task<IEnumerable<Entidades.Participante.Participante>> SelecionarPorGrupo(long?[] ids);

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