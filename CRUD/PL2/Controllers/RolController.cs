using Microsoft.AspNetCore.Mvc;

namespace PL2.Controllers
{
    public class RolController : Controller
    {
        public ActionResult GetAll()
        {
            ML.Result result = BL.Rol.GetAll();
            ML.Rol rol = new ML.Rol();


            rol.Roles = result.Objects;

            return View(rol);
        }


        [HttpGet]
        public ActionResult Form()
        {
            ML.Rol rol = new ML.Rol();

            return View(rol);
        }
        [HttpPost]
        public ActionResult Form(ML.Rol rol)
        {
            ML.Result result = new ML.Result();

            result = BL.Rol.Add(rol);
            if (result.Correct)
            {
                ViewBag.Message = "El usuario se ha registrado correctamente";
            }
            else
            {
                ViewBag.Message = "El usuario no se ha registrado correctamente " + result.ErrorMessage;
            }

            return View();
        }

    }
}
