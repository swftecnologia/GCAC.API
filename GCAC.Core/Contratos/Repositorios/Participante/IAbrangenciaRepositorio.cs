using System.Threading.Tasks;
using GCAC.Core.Entidades.Participante;

namespace GCAC.Core.Contratos.Repositorios.Participante
{
    /// <summary>
    /// Interface de repositório para a entidade Abrangencia
    /// </summary>
    public interface IAbrangenciaRepositorio : IBaseRepositorio<Abrangencia>
    {
        /// <summary>
        /// Verifica se a abrangência existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição da abrangência</param>
        /// <returns>Valor indicando se a abrangência existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao);

        /// <summary>
        /// Verifica se a abrangência existe por descrição para um identificador diferente da abrangência a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da abrangência</param>
        /// <param name="descricao">Descrição da abrangência</param>
        /// <returns>Valor indicando se a abrangência existe ou não</returns>
        Task<bool> ExistePorDescricao(string descricao, long id);
    }
}