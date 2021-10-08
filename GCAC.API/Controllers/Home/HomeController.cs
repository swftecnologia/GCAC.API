using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace GCAC.API.Controllers.Localidade
{
    /// <summary>
    /// Controlador para home
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/home/home")]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// Construtor do controlador
        /// </summary>
        public HomeController()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("verificar-se-esta-logado")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public ActionResult VerificarSeEstaLogado()
        {
            if (HttpContext.Session.GetString("IDUsuario") == null)
            {
                return BadRequest();// ("Você foi desconectado. Entre novamente para acessar o GCAC.");
            }

            return Ok();
        }
    }
}