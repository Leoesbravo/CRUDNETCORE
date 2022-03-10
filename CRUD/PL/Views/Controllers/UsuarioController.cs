using Microsoft.AspNetCore.Mvc;
using PL.Models;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly LEscogidoNETCOREContext context;
        public IActionResult GetAll()
        {
            return View();
        }
    }
}
