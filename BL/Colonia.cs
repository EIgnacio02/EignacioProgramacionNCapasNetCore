using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public static ML.Result GetByIdMunicipio(int IdMunicipio)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioProgramacionNcapasContext context = new DL.EignacioProgramacionNcapasContext())
                {
                    var query = context.Colonia.FromSqlRaw($"ColoniaGetByIdMunicipio {IdMunicipio}").AsEnumerable().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var row in query)
                        {
                            ML.Colonia colonia = new ML.Colonia();
                            colonia.IdColonia = row.IdColonia;
                            colonia.Nombre = row.Nombre;
                            colonia.CodigoPostal = row.CodigoPostal;

                            colonia.Municipio = new ML.Municipio();
                            colonia.Municipio.IdMunicipio = row.IdMunicipio.Value;

                            result.Objects.Add(colonia);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error";
                throw;
            }
            return result;
        }

    }
}
