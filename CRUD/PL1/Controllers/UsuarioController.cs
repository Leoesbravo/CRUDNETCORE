using Microsoft.AspNetCore.Mvc;
using ML;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly LEscogidoNETCOREContext context;
        public ActionResult GetAll()
        {
            ML.Result result = BL.Usuario.GetAll();
            ML.Usuario usuario = new ML.Usuario();

            usuario.Usuarios = result.Objects;

            return View(usuario);
        }
    }
}
