using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using GCAC.Core.Entidades.Integracao;
using GCAC.Core.Enums.Integracao;
using GCAC.Core.Interfaces.Repositorios.Integracao;
using GCAC.Core.Interfaces.Servicos.Integracao;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;

namespace GCAC.Core.Servicos.InstrumentoColetivo
{
    /// <summary>
    /// Serviços para a entidade Documento
    /// </summary>
    public class EntidadeSindicalCNESServico : IEntidadeSindicalCNESServico
    {
        /// <summary>
        /// Repositório da entidade Documento
        /// </summary>
        private readonly IEntidadeSindicalCNESRepositorio _entidadeSindicalCNESRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="entidadeSindicalCNESRepositorio">Repositório da entidade EntidadeSindicalCNES</param>
        public EntidadeSindicalCNESServico(IEntidadeSindicalCNESRepositorio entidadeSindicalCNESRepositorio)
        {
            _entidadeSindicalCNESRepositorio = entidadeSindicalCNESRepositorio;
        }

        /// <summary>
        /// Obtém as entidades sindicais do CNES (Cadastro Nacional de Entidades Sindicais)
        /// </summary>
        /// <param name="caminhoChromeDriver">Local do arquivo chromedriver.exe</param>
        /// <param name="url">Endereço da página web a ser iniciada pelo web driver</param>
        /// <param name="quantidadeLinhasParaPercorrer">Quantidades de linhas a serem percorridas na tabela, onde 0 indica percorrer todas as linhas</param>
        public Tuple<DateTime, DateTime, int, string> CarregarEntidadeSindicalListaGeralCNES(string caminhoChromeDriver, string url, int quantidadeLinhasParaPercorrer)
        {
            DateTime dataInicio = DateTime.Now;
            DateTime dataTermino = DateTime.Now;
            int quantidadeLinhasPercorridasNaTabela = 0;
            int quantidadeLinhasSelecionadasPorIteracao = 0;
            string messagemErro = "";

            try
            {
                int quantidadeLinhasParaGravarPorIteracao = 25;
                bool selecionar = true;
                List<EntidadeSindicalListaGeralCNES> lstEntidadeSindicalListaGeralCNES = new List<EntidadeSindicalListaGeralCNES>();
                Dictionary<string, object> clipboardException = new Dictionary<string, object> { { "[*.]powerbi.com,*", new Dictionary<string, object> { { "last_modified", DateTimeOffset.Now.ToUnixTimeMilliseconds() }, { "setting", 1 } } } };
                ChromeOptions options = new ChromeOptions();

                options.AddUserProfilePreference("profile.content_settings.exceptions.clipboard", clipboardException);
                options.AddArgument("start-maximized");

                IWebDriver driver = new ChromeDriver(caminhoChromeDriver, options);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                driver.Navigate().GoToUrl(url);
                driver.Navigate().GoToUrl(ObterElementoWebDriver(driver, wait, null, "//a[@title='Lista Geral de Entidades']", EnumFindByWebDriver.XPath).GetAttribute("href"));

                IWebElement tabelaEntidadesSindicais = ObterElementoWebDriver(driver, wait, null, "//div[contains(@class,'rowHeaders')]", EnumFindByWebDriver.XPath);
                ExecutarAcaoWebDriver(driver, tabelaEntidadesSindicais, null, EnumActionWebDriver.MoveToElement);
                ExecutarAcaoWebDriver(driver, null, Keys.ArrowUp, EnumActionWebDriver.SendKeys);
                ExecutarAcaoWebDriver(driver, null, Keys.ArrowUp, EnumActionWebDriver.SendKeys);
                ExecutarAcaoWebDriver(driver, null, Keys.ArrowRight, EnumActionWebDriver.SendKeys);

                while (selecionar)
                {
                    Thread.Sleep(100);
                    ExecutarAcaoWebDriver(driver, null, Keys.ArrowDown, EnumActionWebDriver.SendKeys);
                    ExecutarAcaoWebDriver(driver, null, Keys.Control, EnumActionWebDriver.KeyDown);
                    ExecutarAcaoWebDriver(driver, null, Keys.Space, EnumActionWebDriver.SendKeys);
                    ExecutarAcaoWebDriver(driver, null, Keys.Control, EnumActionWebDriver.KeyUp);

                    IWebElement cabecalhoCNPJ = ObterElementoWebDriver(driver, wait, null, "//div[contains(@title,'CNPJ')]", EnumFindByWebDriver.XPath);
                    IWebElement cabecalhoCNPJOrdenacao = ObterElementoWebDriver(driver, wait, cabecalhoCNPJ, ".future", EnumFindByWebDriver.CssSelector);

                    if (cabecalhoCNPJOrdenacao == null)
                    {
                        selecionar = false;
                    }

                    quantidadeLinhasPercorridasNaTabela += 1;
                    quantidadeLinhasSelecionadasPorIteracao += 1;

                    if (quantidadeLinhasParaGravarPorIteracao == quantidadeLinhasSelecionadasPorIteracao || !selecionar)
                    {
                        IWebElement bodyCells = ObterElementoWebDriver(driver, wait, null, "//div[contains(@class,'bodyCells')]", EnumFindByWebDriver.XPath);
                        ExecutarAcaoWebDriver(driver, bodyCells, null, EnumActionWebDriver.ContextClick);

                        IWebElement copiar = ObterElementoWebDriver(driver, wait, null, "//div[contains(@title,'Copiar')]", EnumFindByWebDriver.XPath);
                        ExecutarAcaoWebDriver(driver, copiar, null, EnumActionWebDriver.MoveToElement);

                        IWebElement copiarSelecao = ObterElementoWebDriver(driver, wait, null, "//div[contains(@title,'Copiar seleção')]", EnumFindByWebDriver.XPath);
                        ExecutarAcaoWebDriver(driver, copiarSelecao, null, EnumActionWebDriver.MoveToElement);

                        string dados = driver.ExecuteJavaScript<string>("return await navigator.clipboard.readText();");

                        using (StringReader reader = new StringReader(dados))
                        {
                            reader.ReadLine();
                            string line = reader.ReadLine();

                            while (line != null)
                            {
                                string[] items = line.Split('\t');

                                if (items != null && items.Length > 0)
                                {
                                    EntidadeSindicalListaGeralCNES entidadeSindicalListaGeralCNES = new EntidadeSindicalListaGeralCNES();

                                    entidadeSindicalListaGeralCNES.RazaoSocial = items[0];
                                    entidadeSindicalListaGeralCNES.CNPJ = items[1];
                                    entidadeSindicalListaGeralCNES.Grau = items[2];
                                    entidadeSindicalListaGeralCNES.Grupo = items[3];
                                    entidadeSindicalListaGeralCNES.AreaGeoeconomica = items[4];
                                    entidadeSindicalListaGeralCNES.Abrangencia = items[5];
                                    entidadeSindicalListaGeralCNES.UFSede = items[6];
                                    entidadeSindicalListaGeralCNES.LocalidadeSede = items[7];
                                    entidadeSindicalListaGeralCNES.Bairro = items[8];
                                    entidadeSindicalListaGeralCNES.Logradouro = items[9];
                                    entidadeSindicalListaGeralCNES.Numero = items[10];

                                    if (!String.IsNullOrEmpty(entidadeSindicalListaGeralCNES.CNPJ))
                                    {
                                        lstEntidadeSindicalListaGeralCNES.Add(entidadeSindicalListaGeralCNES);
                                    }
                                }

                                line = reader.ReadLine();
                            }
                        }

                        if (lstEntidadeSindicalListaGeralCNES.Count > 0)
                        {
                            _entidadeSindicalCNESRepositorio.InserirOuAtualizar(lstEntidadeSindicalListaGeralCNES);
                            lstEntidadeSindicalListaGeralCNES = new List<EntidadeSindicalListaGeralCNES>();
                        }

                        if (selecionar)
                        {
                            tabelaEntidadesSindicais = ObterElementoWebDriver(driver, wait, null, "//div[contains(@class,'rowHeaders')]", EnumFindByWebDriver.XPath);
                            ExecutarAcaoWebDriver(driver, tabelaEntidadesSindicais, null, EnumActionWebDriver.MoveToElement);
                            ExecutarAcaoWebDriver(driver, null, Keys.ArrowDown, EnumActionWebDriver.SendKeys);
                            ExecutarAcaoWebDriver(driver, null, Keys.Space, EnumActionWebDriver.SendKeys);
                            ExecutarAcaoWebDriver(driver, null, Keys.Space, EnumActionWebDriver.SendKeys);

                            quantidadeLinhasSelecionadasPorIteracao = 0;
                        }
                    }

                    if (quantidadeLinhasParaPercorrer == quantidadeLinhasPercorridasNaTabela)
                    {
                        break;
                    }
                }

                driver.Close();
                driver.Quit();
            }
            catch (Exception ex)
            {
                messagemErro = ex.Message + ex.InnerException != null ? " - " + ex.InnerException.Message : "";
            }
            finally
            {
                dataTermino = DateTime.Now;
            }

            return new Tuple<DateTime, DateTime, int, string>(dataInicio, dataTermino, quantidadeLinhasPercorridasNaTabela, messagemErro);
        }

        /// <summary>
        /// Obtém as entidades sindicais do CNES (Cadastro Nacional de Entidades Sindicais)
        /// </summary>
        /// <param name="caminhoChromeDriver">Local do arquivo chromedriver.exe</param>
        /// <param name="url">Endereço da página web a ser iniciada pelo web driver</param>
        /// <param name="quantidadeLinhasParaPercorrer">Quantidades de linhas a serem percorridas na tabela, onde 0 indica percorrer todas as linhas</param>
        public Tuple<DateTime, DateTime, int, string> CarregarEntidadeSindicalListaBaseTerritorialCNES(string caminhoChromeDriver, string url, int quantidadeLinhasParaPercorrer)
        {
            DateTime dataInicio = DateTime.Now;
            DateTime dataTermino = DateTime.Now;
            int quantidadeLinhasPercorridasNaTabela = 0;
            int quantidadeLinhasSelecionadasPorIteracao = 0;
            string messagemErro = "";

            try
            {
                int quantidadeLinhasParaGravarPorIteracao = 25;
                bool selecionar = true;
                List<EntidadeSindicalListaBaseTerritorialCNES> lstEntidadeSindicalListaBaseTerritorialCNES = new List<EntidadeSindicalListaBaseTerritorialCNES>();
                Dictionary<string, object> clipboardException = new Dictionary<string, object> { { "[*.]powerbi.com,*", new Dictionary<string, object> { { "last_modified", DateTimeOffset.Now.ToUnixTimeMilliseconds() }, { "setting", 1 } } } };
                ChromeOptions options = new ChromeOptions();

                options.AddUserProfilePreference("profile.content_settings.exceptions.clipboard", clipboardException);
                options.AddArgument("start-maximized");

                IWebDriver driver = new ChromeDriver(caminhoChromeDriver, options);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                driver.Navigate().GoToUrl(url);
                //driver.Navigate().GoToUrl(ObterElementoWebDriver(driver, wait, null, "Sindicatos - Base Territorial", EnumFindByWebDriver.LinkText).GetAttribute("href"));

                IWebElement tabelaEntidadesSindicais = ObterElementoWebDriver(driver, wait, null, "//div[contains(@class,'rowHeaders')]", EnumFindByWebDriver.XPath);
                ExecutarAcaoWebDriver(driver, tabelaEntidadesSindicais, null, EnumActionWebDriver.MoveToElement);
                ExecutarAcaoWebDriver(driver, null, Keys.ArrowUp, EnumActionWebDriver.SendKeys);
                ExecutarAcaoWebDriver(driver, null, Keys.ArrowUp, EnumActionWebDriver.SendKeys);

                while (selecionar)
                {
                    Thread.Sleep(100);
                    ExecutarAcaoWebDriver(driver, null, Keys.ArrowDown, EnumActionWebDriver.SendKeys);
                    ExecutarAcaoWebDriver(driver, null, Keys.Control, EnumActionWebDriver.KeyDown);
                    ExecutarAcaoWebDriver(driver, null, Keys.Space, EnumActionWebDriver.SendKeys);
                    ExecutarAcaoWebDriver(driver, null, Keys.Control, EnumActionWebDriver.KeyUp);

                    IWebElement cabecalhoCNPJ = ObterElementoWebDriver(driver, wait, null, "//div[contains(@title,'CNPJ')]", EnumFindByWebDriver.XPath);
                    IWebElement cabecalhoCNPJOrdenacao = ObterElementoWebDriver(driver, wait, cabecalhoCNPJ, ".future", EnumFindByWebDriver.CssSelector);

                    if (cabecalhoCNPJOrdenacao == null)
                    {
                        selecionar = false;
                    }

                    quantidadeLinhasPercorridasNaTabela += 1;
                    quantidadeLinhasSelecionadasPorIteracao += 1;

                    if (quantidadeLinhasParaGravarPorIteracao == quantidadeLinhasSelecionadasPorIteracao || !selecionar)
                    {
                        IWebElement bodyCells = ObterElementoWebDriver(driver, wait, null, "//div[contains(@class,'bodyCells')]", EnumFindByWebDriver.XPath);
                        ExecutarAcaoWebDriver(driver, bodyCells, null, EnumActionWebDriver.ContextClick);

                        IWebElement copiar = ObterElementoWebDriver(driver, wait, null, "//div[contains(@title,'Copiar')]", EnumFindByWebDriver.XPath);
                        ExecutarAcaoWebDriver(driver, copiar, null, EnumActionWebDriver.MoveToElement);

                        IWebElement copiarSelecao = ObterElementoWebDriver(driver, wait, null, "//div[contains(@title,'Copiar seleção')]", EnumFindByWebDriver.XPath);
                        ExecutarAcaoWebDriver(driver, copiarSelecao, null, EnumActionWebDriver.MoveToElement);

                        string dados = driver.ExecuteJavaScript<string>("return await navigator.clipboard.readText();");

                        using (StringReader reader = new StringReader(dados))
                        {
                            reader.ReadLine();
                            string line = reader.ReadLine();

                            while (line != null)
                            {
                                string[] items = line.Split('\t');

                                if (items != null && items.Length > 0)
                                {
                                    EntidadeSindicalListaBaseTerritorialCNES entidadeSindicalListaBaseTerritorialCNES = new EntidadeSindicalListaBaseTerritorialCNES();

                                    entidadeSindicalListaBaseTerritorialCNES.CNPJ = items[0];
                                    entidadeSindicalListaBaseTerritorialCNES.BaseTerritorial = items[2];

                                    if (!String.IsNullOrEmpty(entidadeSindicalListaBaseTerritorialCNES.CNPJ))
                                    {
                                        lstEntidadeSindicalListaBaseTerritorialCNES.Add(entidadeSindicalListaBaseTerritorialCNES);
                                    }
                                }

                                line = reader.ReadLine();
                            }
                        }

                        if (lstEntidadeSindicalListaBaseTerritorialCNES.Count > 0)
                        {
                            _entidadeSindicalCNESRepositorio.InserirOuAtualizar(lstEntidadeSindicalListaBaseTerritorialCNES);
                            lstEntidadeSindicalListaBaseTerritorialCNES = new List<EntidadeSindicalListaBaseTerritorialCNES>();
                        }

                        if (selecionar)
                        {
                            tabelaEntidadesSindicais = ObterElementoWebDriver(driver, wait, null, "//div[contains(@class,'rowHeaders')]", EnumFindByWebDriver.XPath);
                            ExecutarAcaoWebDriver(driver, tabelaEntidadesSindicais, null, EnumActionWebDriver.MoveToElement);
                            ExecutarAcaoWebDriver(driver, null, Keys.ArrowDown, EnumActionWebDriver.SendKeys);
                            ExecutarAcaoWebDriver(driver, null, Keys.Space, EnumActionWebDriver.SendKeys);
                            ExecutarAcaoWebDriver(driver, null, Keys.Space, EnumActionWebDriver.SendKeys);

                            quantidadeLinhasSelecionadasPorIteracao = 0;
                        }
                    }

                    if (quantidadeLinhasParaPercorrer == quantidadeLinhasPercorridasNaTabela)
                    {
                        break;
                    }
                }

                driver.Close();
                driver.Quit();
            }
            catch (Exception ex)
            {
                messagemErro = ex.Message + ex.InnerException != null ? " - " + ex.InnerException.Message : "";
            }
            finally
            {
                dataTermino = DateTime.Now;
            }

            return new Tuple<DateTime, DateTime, int, string>(dataInicio, dataTermino, quantidadeLinhasPercorridasNaTabela, messagemErro);
        }

        /// <summary>
        /// Obtém as entidades sindicais do CNES (Cadastro Nacional de Entidades Sindicais)
        /// </summary>
        /// <param name="caminhoChromeDriver">Local do arquivo chromedriver.exe</param>
        /// <param name="url">Endereço da página web a ser iniciada pelo web driver</param>
        /// <param name="quantidadeLinhasParaPercorrer">Quantidades de linhas a serem percorridas na tabela, onde 0 indica percorrer todas as linhas</param>
        public Tuple<DateTime, DateTime, int, string> CarregarEntidadeSindicalListaCategoriaCNES(string caminhoChromeDriver, string url, int quantidadeLinhasParaPercorrer)
        {
            DateTime dataInicio = DateTime.Now;
            DateTime dataTermino = DateTime.Now;
            int quantidadeLinhasPercorridasNaTabela = 0;
            int quantidadeLinhasSelecionadasPorIteracao = 0;
            string messagemErro = "";

            try
            {
                int quantidadeLinhasParaGravarPorIteracao = 25;
                bool selecionar = true;
                List<EntidadeSindicalListaCategoriaCNES> lstEntidadeSindicalListaCategoriaCNES = new List<EntidadeSindicalListaCategoriaCNES>();
                Dictionary<string, object> clipboardException = new Dictionary<string, object> { { "[*.]powerbi.com,*", new Dictionary<string, object> { { "last_modified", DateTimeOffset.Now.ToUnixTimeMilliseconds() }, { "setting", 1 } } } };
                ChromeOptions options = new ChromeOptions();

                options.AddUserProfilePreference("profile.content_settings.exceptions.clipboard", clipboardException);
                options.AddArgument("start-maximized");

                IWebDriver driver = new ChromeDriver(caminhoChromeDriver, options);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                driver.Navigate().GoToUrl(url);
                driver.Navigate().GoToUrl(ObterElementoWebDriver(driver, wait, null, "Sindicatos - Categorias", EnumFindByWebDriver.LinkText).GetAttribute("href"));

                IWebElement tabelaEntidadesSindicais = ObterElementoWebDriver(driver, wait, null, "//div[contains(@class,'rowHeaders')]", EnumFindByWebDriver.XPath);
                ExecutarAcaoWebDriver(driver, tabelaEntidadesSindicais, null, EnumActionWebDriver.MoveToElement);
                ExecutarAcaoWebDriver(driver, null, Keys.ArrowUp, EnumActionWebDriver.SendKeys);
                ExecutarAcaoWebDriver(driver, null, Keys.ArrowUp, EnumActionWebDriver.SendKeys);
                ExecutarAcaoWebDriver(driver, null, Keys.ArrowRight, EnumActionWebDriver.SendKeys);

                while (selecionar)
                {
                    Thread.Sleep(100);
                    ExecutarAcaoWebDriver(driver, null, Keys.ArrowDown, EnumActionWebDriver.SendKeys);
                    ExecutarAcaoWebDriver(driver, null, Keys.Control, EnumActionWebDriver.KeyDown);
                    ExecutarAcaoWebDriver(driver, null, Keys.Space, EnumActionWebDriver.SendKeys);
                    ExecutarAcaoWebDriver(driver, null, Keys.Control, EnumActionWebDriver.KeyUp);

                    IWebElement cabecalhoCNPJ = ObterElementoWebDriver(driver, wait, null, "//div[contains(@title,'Razão social')]", EnumFindByWebDriver.XPath);
                    IWebElement cabecalhoCNPJOrdenacao = ObterElementoWebDriver(driver, wait, cabecalhoCNPJ, ".future", EnumFindByWebDriver.CssSelector);

                    if (cabecalhoCNPJOrdenacao == null)
                    {
                        selecionar = false;
                    }

                    quantidadeLinhasPercorridasNaTabela += 1;
                    quantidadeLinhasSelecionadasPorIteracao += 1;

                    if (quantidadeLinhasParaGravarPorIteracao == quantidadeLinhasSelecionadasPorIteracao || !selecionar)
                    {
                        IWebElement bodyCells = ObterElementoWebDriver(driver, wait, null, "//div[contains(@class,'bodyCells')]", EnumFindByWebDriver.XPath);
                        ExecutarAcaoWebDriver(driver, bodyCells, null, EnumActionWebDriver.ContextClick);

                        IWebElement copiar = ObterElementoWebDriver(driver, wait, null, "//div[contains(@title,'Copiar')]", EnumFindByWebDriver.XPath);
                        ExecutarAcaoWebDriver(driver, copiar, null, EnumActionWebDriver.MoveToElement);

                        IWebElement copiarSelecao = ObterElementoWebDriver(driver, wait, null, "//div[contains(@title,'Copiar seleção')]", EnumFindByWebDriver.XPath);
                        ExecutarAcaoWebDriver(driver, copiarSelecao, null, EnumActionWebDriver.MoveToElement);

                        string dados = driver.ExecuteJavaScript<string>("return await navigator.clipboard.readText();");

                        using (StringReader reader = new StringReader(dados))
                        {
                            reader.ReadLine();
                            string line = reader.ReadLine();

                            while (line != null)
                            {
                                string[] items = line.Split('\t');

                                if (items != null && items.Length > 0)
                                {
                                    EntidadeSindicalListaCategoriaCNES entidadeSindicalListaCategoriaCNES = new EntidadeSindicalListaCategoriaCNES();

                                    entidadeSindicalListaCategoriaCNES.CNPJ = items[0];
                                    entidadeSindicalListaCategoriaCNES.Categoria = items[2];

                                    if (!String.IsNullOrEmpty(entidadeSindicalListaCategoriaCNES.CNPJ))
                                    {
                                        lstEntidadeSindicalListaCategoriaCNES.Add(entidadeSindicalListaCategoriaCNES);
                                    }
                                }

                                line = reader.ReadLine();
                            }
                        }

                        if (lstEntidadeSindicalListaCategoriaCNES.Count > 0)
                        {
                            _entidadeSindicalCNESRepositorio.InserirOuAtualizar(lstEntidadeSindicalListaCategoriaCNES);
                            lstEntidadeSindicalListaCategoriaCNES = new List<EntidadeSindicalListaCategoriaCNES>();
                        }

                        if (selecionar)
                        {
                            tabelaEntidadesSindicais = ObterElementoWebDriver(driver, wait, null, "//div[contains(@class,'rowHeaders')]", EnumFindByWebDriver.XPath);
                            ExecutarAcaoWebDriver(driver, tabelaEntidadesSindicais, null, EnumActionWebDriver.MoveToElement);
                            ExecutarAcaoWebDriver(driver, null, Keys.ArrowDown, EnumActionWebDriver.SendKeys);
                            ExecutarAcaoWebDriver(driver, null, Keys.Space, EnumActionWebDriver.SendKeys);
                            ExecutarAcaoWebDriver(driver, null, Keys.Space, EnumActionWebDriver.SendKeys);

                            quantidadeLinhasSelecionadasPorIteracao = 0;
                        }
                    }

                    if (quantidadeLinhasParaPercorrer == quantidadeLinhasPercorridasNaTabela)
                    {
                        break;
                    }
                }

                driver.Close();
                driver.Quit();
            }
            catch (Exception ex)
            {
                messagemErro = ex.Message + ex.InnerException != null ? " - " + ex.InnerException.Message : "";
            }
            finally
            {
                dataTermino = DateTime.Now;
            }

            return new Tuple<DateTime, DateTime, int, string>(dataInicio, dataTermino, quantidadeLinhasPercorridasNaTabela, messagemErro);
        }

        private static IWebElement ObterElementoWebDriver(IWebDriver driver, WebDriverWait wait, IWebElement elemento, string criterioPesquisa, EnumFindByWebDriver tipoPesquisa)
        {
            IWebElement elementoEncontrado = null;

            try
            {
                switch (tipoPesquisa)
                {
                    case EnumFindByWebDriver.XPath:
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(criterioPesquisa)));
                        elementoEncontrado = elemento != null ? elemento.FindElement(By.XPath(criterioPesquisa)) : driver.FindElement(By.XPath(criterioPesquisa));
                        break;
                    case EnumFindByWebDriver.CssSelector:
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(criterioPesquisa)));
                        elementoEncontrado = elemento != null ? elemento.FindElement(By.CssSelector(criterioPesquisa)) : driver.FindElement(By.CssSelector(criterioPesquisa));
                        break;
                    case EnumFindByWebDriver.LinkText:
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.LinkText(criterioPesquisa)));
                        elementoEncontrado = elemento != null ? elemento.FindElement(By.LinkText(criterioPesquisa)) : driver.FindElement(By.LinkText(criterioPesquisa));
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                elementoEncontrado = null;
            }

            return elementoEncontrado;
        }

        private static void ExecutarAcaoWebDriver(IWebDriver driver, IWebElement elemento, string key, EnumActionWebDriver acao)
        {
            Actions action = new Actions(driver);

            switch (acao)
            {
                case EnumActionWebDriver.MoveToElement:
                    action.MoveToElement(elemento).Perform();
                    action.Click().Perform();
                    break;
                case EnumActionWebDriver.SendKeys:
                    action.SendKeys(key);
                    action.Build().Perform();
                    break;
                case EnumActionWebDriver.KeyDown:
                    action.KeyDown(key);
                    action.Build().Perform();
                    break;
                case EnumActionWebDriver.KeyUp:
                    action.KeyUp(key);
                    action.Build().Perform();
                    break;
                case EnumActionWebDriver.ContextClick:
                    action.ContextClick(elemento).Perform();
                    break;
                default:
                    break;
            }
        }
    }
}