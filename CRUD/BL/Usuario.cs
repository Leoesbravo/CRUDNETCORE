using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new Result();
            try
            {

                using (DLAzure.lbravoContext  context = new DLAzure.lbravoContext())
                {
                    var query = context.Usuarios.FromSqlRaw("UsuarioGetAll").ToList();

                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.UserName = obj.UserName;
                            usuario.Nombre = obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;


                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = obj.IdRol.Value;

                            usuario.FechaNacimiento = obj.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                            usuario.Password = obj.Password;
                            usuario.Email = obj.Email;
                            usuario.Sexo = obj.Sexo;
                            usuario.Telefono = obj.Telefono;
                            usuario.Celular = obj.Celular;
                            usuario.Estatus = obj.Estatus;
                            usuario.CURP = obj.Curp;
                            usuario.Imagen = obj.Imagen;

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar la consulta";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLAzure.lbravoContext context = new DLAzure.lbravoContext())
                {
                    var query = context.Usuarios.FromSqlRaw($"UsuarioGetById {IdUsuario}").ToList();
                    result.Object = new List<object>();

                    if (query != null)
                    {
                        foreach(var obj in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.UserName = obj.UserName;
                            usuario.Nombre = obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = obj.IdRol.Value;

                            usuario.FechaNacimiento = obj.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                            usuario.Password = obj.Password;
                            usuario.Email = obj.Email;
                            usuario.Sexo = obj.Sexo;
                            usuario.Telefono = obj.Telefono;
                            usuario.Celular = obj.Celular;
                            usuario.Estatus = obj.Estatus;
                            usuario.CURP = obj.Curp;
                            usuario.Imagen = obj.Imagen;

                            result.Object = usuario;
                            result.Correct = true;
                        }
                    }
                } 
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
        public static ML.Result Add(ML.Usuario usuario)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL.LEscogidoNETCOREContext context = new DL.LEscogidoNETCOREContext())
                {

                    var query = context.Database.ExecuteSqlRaw($"UsuarioAdd {usuario.Nombre},  {usuario.ApellidoPaterno}, {usuario.ApellidoMaterno}, {usuario.UserName},  {usuario.Rol.IdRol}, {usuario.FechaNacimiento}, {usuario.Password},  {usuario.Email}, {usuario.Telefono}, {usuario.Celular},  {usuario.Sexo},  {usuario.Estatus}, {usuario.CURP}, {usuario.Imagen}");


                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar el insert";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LEscogidoNETCOREContext context = new DL.LEscogidoNETCOREContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UsuarioUpdate {usuario.IdUsuario},{usuario.Nombre},{usuario.ApellidoPaterno}, {usuario.ApellidoMaterno}, {usuario.UserName}, {usuario.Rol.IdRol}");


                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar el insert";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Delete(int IdUsuario)
        {
            ML.Result result = new Result();
            try
            {

                using (DL.LEscogidoNETCOREContext context = new DL.LEscogidoNETCOREContext())
                {

                    var query = context.Database.ExecuteSqlRaw($"UsuarioDelete {IdUsuario}");

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido eliminar el registro";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}
