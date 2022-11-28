using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        //public static ML.Result GetAll()
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {

        //        using (DL.EignacioProgramacionNcapasContext context=new DL.EignacioProgramacionNcapasContext())
        //        {
        //            var query = context.Usuarios.FromSqlRaw("UsuarioGetAll ").ToList();
        //            result.Objects = new List<object>();

        //            if (query!=null)
        //            {
        //                foreach (var obj in query)
        //                {
        //                    ML.Usuario usuario = new ML.Usuario();

        //                    usuario.IdUsuario = obj.IdUsuario;
        //                    usuario.UserName = obj.UserName;
        //                    usuario.Nombre = obj.Nombre;
        //                    usuario.ApellidoPaterno = obj.ApellidoPaterno;
        //                    usuario.ApellidoMaterno = obj.ApellidoMaterno;
        //                    usuario.Email = obj.Email;
        //                    usuario.Password = obj.Password;
        //                    usuario.FechaNacimiento = obj.FechaNacimiento.ToString("dd/MM/yyyy");
        //                    usuario.Sexo = obj.Sexo;
        //                    usuario.Telefono = obj.Telefono;
        //                    usuario.Celular = obj.Celular;
        //                    usuario.Curp = obj.Curp;

        //                    //ROL   
        //                    usuario.Rol = new ML.Rol(); //Inicializamos para pador acceder a las prop de rol
        //                    usuario.Rol.IdRol = (byte)obj.IdRol;
        //                    usuario.Rol.Nombre = obj.NombreRol;

        //                    //Imagen
        //                    usuario.Imagen = obj.Imagen;

        //                    //DIRECIONES
        //                    usuario.Direccion=new ML.Direccion();
        //                    usuario.Direccion.IdDireccion = obj.IdDireccion;
        //                    usuario.Direccion.Calle = obj.NombreDireccion;
        //                    usuario.Direccion.NumeroInterior = obj.NumeroInterior;
        //                    usuario.Direccion.NumeroExterior = obj.NumeroExterior;
                            
        //                    usuario.Direccion.Colonia=new ML.Colonia();
        //                    usuario.Direccion.Colonia.IdColonia = obj.IdColonia;
        //                    usuario.Direccion.Colonia.Nombre = obj.NombreColonia;
        //                    usuario.Direccion.Colonia.CodigoPostal = obj.CodigoPostal;
                            
        //                    usuario.Direccion.Colonia.Municipio=new ML.Municipio();
        //                    usuario.Direccion.Colonia.Municipio.IdMunicipio = obj.IdMunicipio;
        //                    usuario.Direccion.Colonia.Municipio.Nombre = obj.NombreMunicipio;

        //                    usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
        //                    usuario.Direccion.Colonia.Municipio.Estado.IdEstado = (int)obj.IdEstado;
        //                    usuario.Direccion.Colonia.Municipio.Estado.Nombre = obj.NombreEstado;

        //                    usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
        //                    usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais=(int)obj.IdPais;
        //                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre=obj.NombrePais;

        //                    result.Objects.Add(usuario);
        //                }
        //            }
        //        }
        //        result.Correct = true;
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return result;
        //}

        public static ML.Result GetAll(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {

                using (DL.EignacioProgramacionNcapasContext context = new DL.EignacioProgramacionNcapasContext())
                {
                    var query = context.Usuarios.FromSqlRaw($"UsuarioGetAll '{usuario.Nombre}','{usuario.ApellidoPaterno}',{usuario.Rol.IdRol}").ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Usuario usuarioBuscar = new ML.Usuario();
                            usuarioBuscar.IdUsuario = obj.IdUsuario;
                            usuarioBuscar.UserName = obj.UserName;
                            usuarioBuscar.Nombre = obj.Nombre;
                            usuarioBuscar.ApellidoPaterno = obj.ApellidoPaterno;
                            usuarioBuscar.ApellidoMaterno = obj.ApellidoMaterno;
                            usuarioBuscar.Email = obj.Email;
                            usuarioBuscar.Password = obj.Password;
                            usuarioBuscar.FechaNacimiento = obj.FechaNacimiento.ToString("dd/MM/yyyy");
                            usuarioBuscar.Sexo = obj.Sexo;
                            usuarioBuscar.Telefono = obj.Telefono;
                            usuarioBuscar.Celular = obj.Celular;
                            usuarioBuscar.Curp = obj.Curp;

                            //ROL   
                            usuarioBuscar.Rol = new ML.Rol(); //Inicializamos para pador acceder a las prop de rol
                            usuarioBuscar.Rol.IdRol = (byte)obj.IdRol;
                            usuarioBuscar.Rol.Nombre = obj.NombreRol;

                            //STATUS
                            usuarioBuscar.Status = obj.Status.Value;

                            //Imagen
                            usuarioBuscar.Imagen = obj.Imagen;

                            //DIRECIONES
                            usuarioBuscar.Direccion = new ML.Direccion();
                            usuarioBuscar.Direccion.IdDireccion = obj.IdDireccion;
                            usuarioBuscar.Direccion.Calle = obj.NombreDireccion;
                            usuarioBuscar.Direccion.NumeroInterior = obj.NumeroInterior;
                            usuarioBuscar.Direccion.NumeroExterior = obj.NumeroExterior;

                            usuarioBuscar.Direccion.Colonia = new ML.Colonia();
                            usuarioBuscar.Direccion.Colonia.IdColonia = obj.IdColonia;
                            usuarioBuscar.Direccion.Colonia.Nombre = obj.NombreColonia;
                            usuarioBuscar.Direccion.Colonia.CodigoPostal = obj.CodigoPostal;

                            usuarioBuscar.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuarioBuscar.Direccion.Colonia.Municipio.IdMunicipio = obj.IdMunicipio;
                            usuarioBuscar.Direccion.Colonia.Municipio.Nombre = obj.NombreMunicipio;

                            usuarioBuscar.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuarioBuscar.Direccion.Colonia.Municipio.Estado.IdEstado = (int)obj.IdEstado;
                            usuarioBuscar.Direccion.Colonia.Municipio.Estado.Nombre = obj.NombreEstado;

                            usuarioBuscar.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuarioBuscar.Direccion.Colonia.Municipio.Estado.Pais.IdPais = (int)obj.IdPais;
                            usuarioBuscar.Direccion.Colonia.Municipio.Estado.Pais.Nombre = obj.NombrePais;

                            result.Objects.Add(usuarioBuscar);
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

        public static ML.Result GetAllById(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EignacioProgramacionNcapasContext context = new DL.EignacioProgramacionNcapasContext())
                {
                    //var query = context.UsuarioGetById(IdUsuario).First();
                    //var query = context.UsuarioGetById(IdUsuario).FirstOrDefault();
                    //var query = context.UsuarioGetById(IdUsuario).Single();
                    var query = context.Usuarios.FromSqlRaw($"UsuarioGetById {IdUsuario}").AsEnumerable().FirstOrDefault();
                    result.Objects = new List<object>();

                    if (query != null)
                    {

                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = query.IdUsuario;
                        usuario.UserName = query.UserName;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        usuario.FechaNacimiento = query.FechaNacimiento.ToString("dd/MM/yyyy"); //"dd/MM/yyyy"
                        usuario.Sexo = query.Sexo;
                        usuario.Telefono = query.Telefono;
                        usuario.Celular = query.Celular;
                        usuario.Curp = query.Curp;
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = query.IdRol.Value;

                        usuario.Imagen = query.Imagen;

                        usuario.Direccion = new ML.Direccion();//Inicializamos 
                        usuario.Direccion.IdDireccion = query.IdDireccion;
                        usuario.Direccion.Calle = query.NombreDireccion;
                        usuario.Direccion.NumeroInterior = query.NumeroInterior;
                        usuario.Direccion.NumeroExterior = query.NumeroExterior;

                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = query.IdColonia;
                        usuario.Direccion.Colonia.Nombre = query.NombreColonia;
                        usuario.Direccion.Colonia.CodigoPostal = query.CodigoPostal;

                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = query.IdMunicipio;
                        usuario.Direccion.Colonia.Municipio.Nombre = query.NombreMunicipio;

                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = query.IdEstado;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = query.NombreEstado;

                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = query.IdPais;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = query.NombrePais;

                        //se guardan en un objeto
                        result.Object = usuario;

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

        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL.EignacioProgramacionNcapasContext context = new DL.EignacioProgramacionNcapasContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"UsuarioAdd '{usuario.UserName}','{usuario.Nombre}','{usuario.ApellidoPaterno}', '{usuario.ApellidoMaterno}','{usuario.Email}','{usuario.Password}','{usuario.FechaNacimiento}','{usuario.Sexo}','{usuario.Telefono}','{usuario.Celular}','{usuario.Curp}',{usuario.Rol.IdRol},'{usuario.Imagen}','{usuario.Direccion.Calle}','{usuario.Direccion.NumeroInterior}','{usuario.Direccion.NumeroExterior}',{usuario.Direccion.Colonia.IdColonia}") ;
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
                result.Ex = ex;
                result.Message = "Ocurrio un problema";
            }
            return result;
        }

        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioProgramacionNcapasContext context = new DL.EignacioProgramacionNcapasContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UsuarioUpdate {usuario.IdUsuario}, '{usuario.UserName}','{usuario.Nombre}','{usuario.ApellidoPaterno}', '{usuario.ApellidoMaterno}','{usuario.Email}','{usuario.Password}','{usuario.FechaNacimiento}','{usuario.Sexo}','{usuario.Telefono}','{usuario.Celular}','{usuario.Curp}',{usuario.Rol.IdRol},'{usuario.Imagen}','{usuario.Direccion.Calle}','{usuario.Direccion.NumeroInterior}','{usuario.Direccion.NumeroExterior}',{usuario.Direccion.Colonia.IdColonia}");

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
                result.Message = "Ocurrio un problema";
                result.Ex = ex;
                throw;
            }
            return result;
        }

        public static ML.Result Delete(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioProgramacionNcapasContext context = new DL.EignacioProgramacionNcapasContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UsuarioDelete {IdUsuario}");
                    if (query > 0)
                    {
                        result.Message = "Se elimino correctamente ";
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

        public static ML.Result ConvertirExcelDataTable(string connString)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (OleDbConnection context =new OleDbConnection(connString))
                {
                    string query = "SELECT * FROM [Sheet1$]";
                    using (OleDbCommand cmd=new OleDbCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection=context;

                        OleDbDataAdapter adapter = new OleDbDataAdapter();
                        adapter.SelectCommand = cmd;

                        DataTable usuariotable = new DataTable();
                        adapter.Fill(usuariotable);

                        if (usuariotable.Rows.Count>0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in usuariotable.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();

                                usuario.UserName = row[0].ToString();
                                usuario.Nombre = row[1].ToString();
                                usuario.ApellidoPaterno = row[2].ToString();
                                usuario.ApellidoMaterno = row[3].ToString();
                                usuario.Email = row[4].ToString();
                                usuario.Password = row[5].ToString();
                                usuario.FechaNacimiento = row[6].ToString();
                                usuario.Sexo = row[7].ToString();
                                usuario.Telefono = row[8].ToString();
                                usuario.Celular = row[9].ToString();
                                usuario.Curp = row[10].ToString();
                                //usuario.Imagen = row[11].ToString();

                                usuario.Rol = new ML.Rol();//Instanciamos la clase rol
                                usuario.Rol.IdRol = byte.Parse(row[11].ToString());

                                usuario.Direccion = new ML.Direccion();
                                usuario.Direccion.Calle = row[12].ToString();
                                usuario.Direccion.NumeroInterior = row[13].ToString();
                                usuario.Direccion.NumeroExterior = row[14].ToString();

                                usuario.Direccion.Colonia = new ML.Colonia();
                                usuario.Direccion.Colonia.IdColonia = byte.Parse(row[15].ToString());

                                result.Objects.Add(usuario);
                            }
                            result.Correct = true;
                        }
                        if (usuariotable.Rows.Count > 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.Message = "No existen registros en el excel";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result ValidarExcel(List<object> Object)
        {
            ML.Result result = new ML.Result();


            try
            {
                result.Objects=new List<object>();
                int i = 1;
                foreach (ML.Usuario usuario in Object)
                {
                    ML.ErrorExcel errorExcel = new ML.ErrorExcel();
                    errorExcel.IdRegistro = i++;
                    //Operador Ternario
                    usuario.UserName = (usuario.UserName == "") ? errorExcel.Mensaje += "Ingresa el UserName" : usuario.UserName;
                    usuario.Nombre = (usuario.Nombre == "") ? errorExcel.Mensaje += "Ingresa el Nombre" : usuario.Nombre;
                    usuario.ApellidoPaterno = (usuario.ApellidoPaterno == "") ? errorExcel.Mensaje += "Ingresa el ApellidoPaterno" : usuario.ApellidoPaterno;
                    usuario.ApellidoMaterno = (usuario.ApellidoMaterno == "") ? errorExcel.Mensaje += "Ingresa el ApellidoMaterno" : usuario.ApellidoMaterno;
                    usuario.Email = (usuario.Email == "") ? errorExcel.Mensaje += "Ingresa el Email" : usuario.Email;
                    usuario.Password = (usuario.Password == "") ? errorExcel.Mensaje += "Ingresa el Password" : usuario.Password;
                    usuario.Sexo = (usuario.Sexo == "") ? errorExcel.Mensaje += "Ingresa el Sexo" : usuario.Sexo;
                    usuario.Telefono = (usuario.Telefono == "") ? errorExcel.Mensaje += "Ingresa el Telefono" : usuario.Telefono;
                    usuario.Celular = (usuario.Celular == "") ? errorExcel.Mensaje += "Ingresa el Celular" : usuario.Celular;
                    usuario.Curp = (usuario.Curp == "") ? errorExcel.Mensaje += "Ingresa el Curp" : usuario.Curp;


                    if (usuario.Rol.IdRol.ToString() == "")
                    {
                        errorExcel.Mensaje += "Ingresa el IdRol";
                    }
                    if (usuario.Direccion.Calle == "")
                    {
                        errorExcel.Mensaje += "Ingresa el Calle";
                    }
                    usuario.Direccion.NumeroInterior = (usuario.Direccion.NumeroInterior == "") ? errorExcel.Mensaje += "Ingresa el NumeroInterior" : usuario.Direccion.NumeroInterior;
                    usuario.Direccion.NumeroExterior = (usuario.Direccion.NumeroExterior == "") ? errorExcel.Mensaje += "Ingresa el NumeroExterior" : usuario.Direccion.NumeroExterior;

                    if (usuario.Direccion.Colonia.IdColonia.ToString() == "")
                    {
                        errorExcel.Mensaje += "Ingresa el IdColonia";
                    }
                    if (errorExcel.Mensaje != null)
                    {
                        result.Objects.Add(errorExcel);
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
            }
            return result;
        }


        public static ML.Result UpdateStatus(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioProgramacionNcapasContext context=new DL.EignacioProgramacionNcapasContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UpdateStatus {usuario.IdUsuario},{usuario.Status}");
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
                result.Ex = ex;
            }

            return result;
        }

    }
}
