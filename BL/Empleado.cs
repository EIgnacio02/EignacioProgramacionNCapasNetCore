using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioProgramacionNcapasContext context=new DL.EignacioProgramacionNcapasContext())
                {
                    var query = context.Empleados.FromSqlRaw("EmpleadoGetAll").ToList();
                    
                    result.Objects=new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();

                            empleado.NumeroEmpleado = obj.NumeroEmpleado;
                            empleado.Rfc = obj.Rfc;
                            empleado.Nombre=obj.Nombre;
                            empleado.ApellidoPaterno = obj.ApellidoPaterno;
                            empleado.ApellidoMaterno = obj.ApellidoMaterno;
                            empleado.Email = obj.Email;
                            empleado.Telefono = obj.Telefono;
                            empleado.FechaNacimiento = obj.FechaNacimiento.ToString("dd/MM/yyyy");
                            empleado.Nss = obj.Nss;
                            empleado.FechaIngreso = obj.FechaIngreso.ToString("dd/MM/yyyy");
                            empleado.Imagen = obj.Foto;

                            empleado.Empresa = new ML.Empresa();
                            empleado.Empresa.IdEmpresa = obj.IdEmpresa.Value;
                            empleado.Empresa.Nombre = obj.NombreEmpresa;

                            result.Objects.Add(empleado);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {

            }
             return result;
        }

        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioProgramacionNcapasContext context=new DL.EignacioProgramacionNcapasContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"EmpleadoAdd '{empleado.NumeroEmpleado}','{empleado.Rfc}','{empleado.Nombre}','{empleado.ApellidoPaterno}', '{empleado.ApellidoMaterno}','{empleado.Email}','{empleado.Telefono}','{empleado.FechaNacimiento}','{empleado.Nss}','{empleado.FechaIngreso}','{empleado.Imagen}',{empleado.Empresa.IdEmpresa}");

                    if (query>=1)
                    {
                        result.Message = "Se ingresaron los datos correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un problema";
            }
            return result;
        }
    }
}
