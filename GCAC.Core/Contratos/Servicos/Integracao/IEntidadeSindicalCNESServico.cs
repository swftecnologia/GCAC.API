using System;

namespace GCAC.Core.Interfaces.Servicos.Integracao
{
    /// <summary>
    /// Serviço para uma entidade sindical do CNES
    /// </summary>
    public interface IEntidadeSindicalCNESServico
    {
        /// <summary>
        /// Obtém as entidades sindicais do CNES (Cadastro Nacional de Entidades Sindicais)
        /// </summary>
        /// <param name="caminhoChromeDriver">Local do arquivo chromedriver.exe</param>
        /// <param name="url">Endereço da página web a ser iniciada pelo web driver</param>
        /// <param name="quantidadeLinhasParaPercorrer">Quantidades de linhas a serem percorridas na tabela, onde 0 indica percorrer todas as linhas</param>
        Tuple<DateTime, DateTime, int, string> CarregarEntidadeSindicalListaGeralCNES(string caminhoChromeDriver, string url, int quantidadeLinhasParaPercorrer);

        /// <summary>
        /// Obtém as entidades sindicais do CNES (Cadastro Nacional de Entidades Sindicais)
        /// </summary>
        /// <param name="caminhoChromeDriver">Local do arquivo chromedriver.exe</param>
        /// <param name="url">Endereço da página web a ser iniciada pelo web driver</param>
        /// <param name="quantidadeLinhasParaPercorrer">Quantidades de linhas a serem percorridas na tabela, onde 0 indica percorrer todas as linhas</param>
        Tuple<DateTime, DateTime, int, string> CarregarEntidadeSindicalListaBaseTerritorialCNES(string caminhoChromeDriver, string url, int quantidadeLinhasParaPercorrer);

        /// <summary>
        /// Obtém as entidades sindicais do CNES (Cadastro Nacional de Entidades Sindicais)
        /// </summary>
        /// <param name="caminhoChromeDriver">Local do arquivo chromedriver.exe</param>
        /// <param name="url">Endereço da página web a ser iniciada pelo web driver</param>
        /// <param name="quantidadeLinhasParaPercorrer">Quantidades de linhas a serem percorridas na tabela, onde 0 indica percorrer todas as linhas</param>
        Tuple<DateTime, DateTime, int, string> CarregarEntidadeSindicalListaCategoriaCNES(string caminhoChromeDriver, string url, int quantidadeLinhasParaPercorrer);
    }
}