namespace GCAC.Core.Enums.Integracao
{
    /// <summary>
    /// Enumerador para representar ações do webdriver
    /// </summary>
    public enum EnumActionWebDriver
    {
        /// <summary>
        /// Ação do web driver para mover para um elemendo
        /// </summary>
        MoveToElement,
        /// <summary>
        /// Ação do web driver para enviar um comando do teclado
        /// </summary>
        SendKeys,
        /// <summary>
        /// Ação do web driver para enviar o comando seta abaixo do teclado
        /// </summary>
        KeyDown,
        /// <summary>
        /// Ação do web driver para enviar o comando seta acima do teclado
        /// </summary>
        KeyUp,
        /// <summary>
        /// Ação do web driver para clicar com o botão direito do mouse
        /// </summary>
        ContextClick
    }
}
