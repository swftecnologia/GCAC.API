namespace GCAC.Core.Enums.Integracao
{
    /// <summary>
    /// Enumerador para representar pesquisas de elementos do webdriver
    /// </summary>
    public enum EnumFindByWebDriver
    {
        /// <summary>
        /// Pesquisa de elemento do web driver por XPath
        /// </summary>
        XPath,
        /// <summary>
        /// Pesquisa de elemento do web driver por Css
        /// </summary>
        CssSelector,
        /// <summary>
        /// Pesquisa de elemento pelo texto do link
        /// </summary>
        LinkText
    }
}
