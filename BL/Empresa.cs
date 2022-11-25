using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empresa
    {
        //public static ML.Result GetAll()
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (DL.EignacioProgramacionNcapasContext context = new DL.EignacioProgramacionNcapasContext())
        //        {
        //            var query = context.Empresas.FromSqlRaw("EmpresaGetAll").ToList();
        //            result.Objects = new List<object>();
        //            if (query != null)
        //            {
        //                foreach (var row in query)
        //                {
        //                    ML.Empresa empresa = new ML.Empresa();
        //                    empresa.IdEmpresa = row.IdEmpresa;
        //                    empresa.Nombre = row.Nombre;
        //                    empresa.Telefono = row.Telefono;
        //                    empresa.Email = row.Email;
        //                    empresa.DireccionWeb = row.DireccionWeb;

        //                    result.Objects.Add(empresa);
        //                }
        //                result.Message = ("Todos tus datos");
        //            }

        //        }
        //        result.Correct = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.Ex = ex;
        //        result.Message = "Ocurrio un problema";
        //        throw;
        //    }

        //    return result;
        //}
        public static ML.Result GetAll(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioProgramacionNcapasContext context = new DL.EignacioProgramacionNcapasContext())
                {
                    var query = context.Empresas.FromSqlRaw($"EmpresaGetAll '{empresa.Nombre}'").ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var row in query)
                        {
                            ML.Empresa empresaBuscar = new ML.Empresa();
                            empresaBuscar.IdEmpresa = row.IdEmpresa;
                            empresaBuscar.Nombre = row.Nombre;
                            empresaBuscar.Telefono = row.Telefono;
                            empresaBuscar.Email = row.Email;
                            empresaBuscar.DireccionWeb = row.DireccionWeb;

                            result.Objects.Add(empresaBuscar);
                        }
                        result.Message = ("Todos tus datos");
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un problema";
                throw;
            }

            return result;
        }
        public static ML.Result GetById(int IdEmpresa)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioProgramacionNcapasContext context = new DL.EignacioProgramacionNcapasContext())
                {
                    var query = context.Empresas.FromSqlRaw($"EmpresaGetById {IdEmpresa}").AsEnumerable().SingleOrDefault();

                    if (query != null)
                    {
                        ML.Empresa empresa = new ML.Empresa();

                        empresa.IdEmpresa = query.IdEmpresa;
                        empresa.Nombre = query.Nombre;
                        empresa.Telefono = query.Telefono;
                        empresa.Email = query.Email;
                        empresa.DireccionWeb = query.DireccionWeb;

                        result.Object = empresa;
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "Ocurrio un problema";
                result.Ex = ex;
                throw;
            }
            return result;

        }


        public static ML.Result Add(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioProgramacionNcapasContext context = new DL.EignacioProgramacionNcapasContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"EmpresaAdd '{empresa.Nombre}','{empresa.Telefono}','{empresa.Email}','{empresa.DireccionWeb}'");
                    if (query > 0)
                    {
                        result.Message = "Se ingresaron los datos correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "Ocurrio un error";
                result.Ex = ex;
                throw;
            }

            return result;
        }


        public static ML.Result Update(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioProgramacionNcapasContext context = new DL.EignacioProgramacionNcapasContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"EmpresaUpdate {empresa.IdEmpresa}, '{empresa.Nombre}','{empresa.Telefono}','{empresa.Email}','{empresa.DireccionWeb}'");

                    if (query > 0)
                    {
                        result.Message = "Se actualizaron los datos correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "Ocurrio un error";
                result.Ex = ex;
                throw;
            }

            return result;
        }

        public static ML.Result Delete(int IdEmpresa)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioProgramacionNcapasContext context = new DL.EignacioProgramacionNcapasContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"EmpresaDelete {IdEmpresa}");

                    if (query > 0)
                    {
                        result.Message = "Se elimino correctamente";
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
    }
}
