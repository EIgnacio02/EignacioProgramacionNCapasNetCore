using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {

        public static ML.Result GetByIdPais(int IdPais)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioProgramacionNcapasContext context = new DL.EignacioProgramacionNcapasContext())
                {
                    var query = context.Estados.FromSqlRaw($"EstadoGetByIdPais {IdPais}").AsEnumerable().ToList(); 
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var row in query)
                        {
                            ML.Estado estado = new ML.Estado();
                            estado.IdEstado = row.IdEstado;
                            estado.Nombre = row.Nombre;


                            estado.Pais = new ML.Pais();
                            //ML.Pais pais = new ML.Pais();
                            estado.Pais.IdPais = row.IdPais.Value;//idPais

                            result.Objects.Add(estado);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                throw;
            }
            return result;
        }

    }
}
