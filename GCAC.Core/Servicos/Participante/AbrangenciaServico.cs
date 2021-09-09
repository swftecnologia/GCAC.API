using System.Threading.Tasks;
using GCAC.Core.Entidades.Participante;
using GCAC.Core.Contratos.Repositorios.Participante;
using GCAC.Core.Contratos.Servicos.Participante;

namespace GCAC.Core.Servicos.Participante
{
    /// <summary>
    /// Serviços para a entidade Abrangencia
    /// </summary>
    public class AbrangenciaServico : BaseServico<Abrangencia>, IAbrangenciaServico
    {
        /// <summary>
        /// Repositório da entidade Abrangencia
        /// </summary>
        private readonly IAbrangenciaRepositorio _abrangenciaRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="abrangenciaRepositorio">Repositório da entidade Abrangencia</param>
        public AbrangenciaServico(IAbrangenciaRepositorio abrangenciaRepositorio) : base(abrangenciaRepositorio)
        {
            _abrangenciaRepositorio = abrangenciaRepositorio;
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