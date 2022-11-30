using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        //MUESTRA TABLA CON TODOS LOS DATOS 
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();

            ML.Result resultRol = BL.Rol.GetAll(); //Para poder trar los drop down list tarer el getAll

            //Guardamos los datos del metodos que queremos llamar  en el objeto
            ML.Result result = BL.Usuario.GetAll(usuario);

           /* ML.Usuario usuario = new ML.Usuario();*/ //Instanciamos para poder usar los datos usuario

            if (result.Correct)
            {
                //Guaramos la lista result en la lista de usario(ML)
                usuario.Rol.Roles = resultRol.Objects;
                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
            }
            return View(usuario); //Guardamos los datos en la vista 
        }

        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
        {

            //Guardamos los datos del metodos que queremos llamar  en el objeto
            ML.Result result = BL.Usuario.GetAll(usuario);
            usuario.Rol = new ML.Rol();
            /* ML.Usuario usuario = new ML.Usuario();*/ //Instanciamos para poder usar los datos usuario
            ML.Result resultRol= BL.Rol.GetAll();
            if (result.Correct)
            {
                //Guaramos la lista result en la lista de usario(ML)
                usuario.Usuarios = result.Objects;
                usuario.Rol.Roles = resultRol.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
            }
            return View(usuario); //Guardamos los datos en la vista 
        }

        [HttpGet] //MUESTRA LAS VISTAS DEL FORMULARIO
        public ActionResult Form(int? IdUsuario)
        {

            ML.Result resultRol = BL.Rol.GetAll(); //Para poder trar los drop down list
            ML.Result resultPais = BL.Pais.GetAll(); //Para poder trar los drop down list

            //Se inicializar para trar los datos complejos
            ML.Usuario usuario = new ML.Usuario();

            usuario.Rol = new ML.Rol();

            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
            //usuario.Pais = new ML.Pais();

            //Si el ID no trae nada nos manda al form limipio para agregar (cuando le damos al boton + (agregar))
            if (IdUsuario == null)
            {
                //Se inicializa para poder usar las propiedades del ROLES y PAISES de la LIST (ML)
                usuario.Rol.Roles = resultRol.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                //usuario.Pais.Paises = resultPais.Objects;
                return View(usuario);
            }
            else
            {
                //GETBYID
                ML.Result result = BL.Usuario.GetAllById(IdUsuario.Value);

                if (result.Correct)
                {

                    usuario = (ML.Usuario)result.Object; //UNBOXING

                    //Se inicializa para poder usar las propiedades del ROLES y PAISES de la LIST (ML)
                    usuario.Rol.Roles = resultRol.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;

                    //Es para mostrar el drop down list
                    //Se crea metodo BL Estado que va a trar por el IdPais
                    ML.Result resultEstados = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;

                    ML.Result resultMunicipio = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                    usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipio.Objects;

                    ML.Result resultColonia = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);
                    usuario.Direccion.Colonia.Colonias = resultColonia.Objects;

                    //return View(usuario);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar los datos del usuario";
                }
                return View(usuario);
            }
        }


        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            //AGREGAR
            if (usuario.IdUsuario == 0)
            {
                IFormFile image = Request.Form.Files["ImagenData"];

                if (image != null)
                {
                    //llamar al metodo que convierte a bytes la imagen
                    byte[] ImagenBytes = ConvertToBytes(image);
                    //convierto a base 64 la imagen y la guardo en la propiedad de imagen en el objeto usuario
                    usuario.Imagen = Convert.ToBase64String(ImagenBytes);
                }

                //Validacion de las propiedades
                if (!ModelState.IsValid)
                {
                    ML.Result resultRol = BL.Rol.GetAll();
                    ML.Result resultPais = BL.Pais.GetAll();

                    usuario.Rol = new ML.Rol();

                    usuario.Direccion = new ML.Direccion();
                    usuario.Direccion.Colonia = new ML.Colonia();
                    usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                    usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                    usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();


                    usuario.Rol.Roles = resultRol.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                    return View(usuario);

                }
                else
                {
                    //Agregar PROP correctas
                    result = new ML.Result();

                    if (usuario.IdUsuario == 0)
                    {
                        result = BL.Usuario.Add(usuario);

                        if (result.Correct)
                        {
                            ViewBag.Message = "Alumno agregado correctamente";
                        }
                        else
                        {
                            ViewBag.Message = "Ocurrio un error al agregar al alumno" + result.Message;
                        }
                    }

                }
            }


            //ACTUALIZAR
            else
            {
                IFormFile image = Request.Form.Files["ImagenData"];

                if (image != null)
                {
                    //llamar al metodo que convierte a bytes la imagen
                    byte[] ImagenBytes = ConvertToBytes(image);
                    //convierto a base 64 la imagen y la guardo en la propiedad de imagen en el objeto usuario
                    usuario.Imagen = Convert.ToBase64String(ImagenBytes);
                }

                result = BL.Usuario.Update(usuario);
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Ocrrio un error";
                }
            }
            return PartialView("Modal");
        }   
        
        //ELIMINAR
        [HttpGet]
        public ActionResult Delete(int? IdUsuario)
        {
            if (IdUsuario >= 1)
            {
                ML.Result result = BL.Usuario.Delete(IdUsuario.Value);
                ViewBag.Message = result.Message;
            }
            else
            {
                ViewBag.Message = "Ocurrio un errror";
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
            var result = BL.Municipio.GetByIdEstado(IdEstado);
            return Json(result.Objects);
        }

        public JsonResult GetColonia(int IdMunicipio)
        {
            var result = BL.Colonia.GetByIdMunicipio(IdMunicipio);
            return Json(result.Objects);
        }
        
        //Convertir Bytes
        public static byte[] ConvertToBytes(IFormFile Imagen)
        {
            using var fileStream = Imagen.OpenReadStream();


            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);

            return bytes;
        }


        //Status 
        public JsonResult UpdateStatus(int IdUsuario,int status)
        {
            var result = BL.Usuario.UpdateStatus(IdUsuario,status);
            return Json(result.Objects);
        }
    }
}
