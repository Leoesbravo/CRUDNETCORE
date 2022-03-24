using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLAzure.lbravoContext context = new DLAzure.lbravoContext())
                {
                    var query = context.Pais.FromSqlRaw("PaisGetAll").ToList();

                    result.Objects = new List<object>();
                    if(query != null)
                    {
                        foreach (var item in query)
                        {
                            ML.Pais pais = new ML.Pais();
                            pais.IdPais = item.IdPais;
                            pais.Nombre = item.Nombre;

                            result.Objects.Add(pais);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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
    }
}
