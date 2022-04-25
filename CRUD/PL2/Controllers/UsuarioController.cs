using DL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult GetAll()
        {
            ML.Result result = BL.Usuario.GetAll();
            ML.Usuario usuario = new ML.Usuario();


            usuario.Usuarios = result.Objects;

            return View(usuario);
        }
        public byte[] ConvertToBytes(IFormFile Imagen)
        {
            using (var ms = new MemoryStream())
            {
                Imagen.CopyTo(ms);
                var fileBytes = ms.ToArray();
                string s = Convert.ToBase64String(fileBytes);

                return fileBytes;
            }
        }

        [HttpGet]
        public ActionResult Form(int Idusuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result resultPaises = BL.Pais.GetAll();
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

            usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects;

            ML.Result resultUsuario = BL.Rol.GetAll();
            usuario.Rol = new ML.Rol();
            usuario.Rol.Roles = resultUsuario.Objects;

            //prueba
            if (Idusuario == 0) //Add
            {
                return View(usuario);
            }
            else //Update
            {

                ML.Result result = new ML.Result();
                result = BL.Usuario.GetById(Idusuario);


                if (result.Correct)
                {
                    usuario = ((ML.Usuario)result.Object);
                    usuario.Rol.Roles = resultUsuario.Objects;
                    return View(usuario);
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            IFormFile file = Request.Form.Files["ImagenData"];

            if (file != null)
            {
                usuario.Imagen = ConvertToBytes(file);
            }
            if (usuario.IdUsuario == 0)
            {
                result = BL.Usuario.Add(usuario);
                if (result.Correct)
                {
                    ViewBag.Message = "El usuario se ha registrado correctamente";
                }
                else
                {
                    ViewBag.Message = "El usuario no se ha registrado correctamente " + result.ErrorMessage;
                }
            }
            else
            {
                result = BL.Usuario.Update(usuario);

                if (result.Correct)
                {
                    ViewBag.Message = "El registro se ha actualizado correctamente";
                }
                else
                {
                    ViewBag.Message = "El registro no se ha actualizado correctamente " + result.ErrorMessage;
                }


            }

            return PartialView("Modal");
        }
    
        public ActionResult Delete(int IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            
            usuario.IdUsuario = IdUsuario;

            ML.Result result = BL.Usuario.Delete(IdUsuario);

            if (result.Correct)
            {
                ViewBag.Message = "Se ha eliminado exitosamente el registro";
            }
            else
            {
                ViewBag.Message = "ocurrió un error al eliminar el registro " + result.ErrorMessage;

            }
            return PartialView("Modal");

        }

        public JsonResult GetEstado(int IdPais)
        {
            var result = BL.Estado.GetByIdPais(IdPais);

            return Json(result.Objects);
        }
        public JsonResult GetMunicipio(int IdEstado)
        {
            var result = BL.Municipio.MunicipioGetByIdEstado(IdEstado);

            return Json(result.Objects);
        }
        public JsonResult GetColonia(int IdMunicipio)
        {
            var result = BL.Colonia.ColoniaGetByIdMunicipio(IdMunicipio);

            return Json(result.Objects);
        }
    }
}
