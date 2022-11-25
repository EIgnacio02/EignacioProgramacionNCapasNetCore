using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Aseguradora
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioProgramacionNcapasContext context=new DL.EignacioProgramacionNcapasContext())
                {
                    var query = context.Aseguradoras.FromSqlRaw("AseguradoraGetAll").ToList();
                    result.Objects = new List<object>();

                    if (query!=null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Aseguradora aseguradora = new ML.Aseguradora();

                            aseguradora.IdAseguradora = obj.IdAseguradora;
                            aseguradora.Nombre = obj.Nombre;
                            aseguradora.FechaCreacion = obj.FechaCreacion.Value;
                            aseguradora.FechaModificacion = obj.FechaModificacion.Value;

                            aseguradora.Usuario = new ML.Usuario();
                            aseguradora.Usuario.IdUsuario = obj.IdUsuario.Value;
                            aseguradora.Usuario.Nombre = obj.NombreUsuario;

                            result.Objects.Add(aseguradora);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un erro";
                throw;
            }
            return result;
        }

        public static ML.Result Delte(int? IdAseguradora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioProgramacionNcapasContext context=new DL.EignacioProgramacionNcapasContext())
                {
                    
                }
            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.Correct = false;
                throw;
            }
            return result;
        }
    }
}
