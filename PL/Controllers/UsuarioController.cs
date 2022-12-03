using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        public UsuarioController(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result resultRol = BL.Rol.GetAll();
            ML.Usuario usuario = new ML.Usuario();

            usuario.Rol = new ML.Rol();
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();

            /*ML.Result resultRol = BL.Rol.GetAll();*/ //Para poder trar los drop down list tarer el getAll

            //Guardamos los datos del metodos que queremos llamar  en el objeto

            //ML.Result result = BL.Usuario.GetAll(usuario)


            try
            {
                string urlAPI = _configuration["UrlAPI"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);
                    var responseTask = client.GetAsync("Usuario/GetAll");
                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        foreach (var resultItem in readTask.Result.Objects)
                        {
                            ML.Usuario resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(resultItem.ToString());
                            result.Objects.Add(resultItemList);
                        }

                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }

            if (result.Correct)
            {
                //Guaramos la lista result en la lista de usario(ML)
                usuario.Rol.Roles = resultRol.Objects;
                usuario.Usuarios = result.Objects;
                return View(usuario); //Guardamos los datos en la vista 
            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
                return View();
            }
        }


        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
        {
            //Guardamos los datos del metodos que queremos llamar  en el objeto
            //ML.Result result = BL.Usuario.GetAll(usuario);
            
            /* ML.Usuario usuario = new ML.Usuario();*/ //Instanciamos para poder usar los datos usuario
            ML.Result resultRol= BL.Rol.GetAll();
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            usuario.Rol = new ML.Rol();

            try
            {
                string urlAPI = _configuration["UrlAPI"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);
                    var responseTask = client.PostAsJsonAsync("Usuario/GetAllPost/", usuario);
                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        foreach (var resultItem in readTask.Result.Objects)
                        {
                            ML.Usuario resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(resultItem.ToString());
                            result.Objects.Add(resultItemList);
                        }

                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }




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
            //Se inicializar para trar los datos complejos
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();


            ML.Result resultRol = BL.Rol.GetAll(); //Para poder trar los drop down list
            ML.Result resultPais = BL.Pais.GetAll(); //Para poder trar los drop down list


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
                //ML.Result result = BL.Usuario.GetAllById(IdUsuario.Value);
                //ML.Result result = BL.Usuario.GetAll(usuario)

                //GETBYID
                //CONSUMO DE API
                try
                {
                    string urlAPI = _configuration["UrlAPI"];
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(urlAPI);
                        var responseTask = client.GetAsync("Usuario/GetById/" + IdUsuario);
                        responseTask.Wait();

                        var resultServicio = responseTask.Result;

                        if (resultServicio.IsSuccessStatusCode)
                        {
                            var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                            readTask.Wait();

                            ML.Usuario resultItemList = new ML.Usuario();

                            resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(readTask.Result.Object.ToString());
                            result.Object = resultItemList;
                            

                            result.Correct = true;
                        }
                    }

                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.Message = ex.Message;
                }
                

                //TRAER EL DROP DOWN LIST
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

                result = BL.Usuario.Add(usuario);

                if (result.Correct)
                {
                    ViewBag.Message = "Alumno agregado correctamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al agregar al alumno" + result.Message;
                }
                //Validacion de las propiedades
                //if (!ModelState.IsValid)
                //{
                //    ML.Result resultRol = BL.Rol.GetAll();
                //    ML.Result resultPais = BL.Pais.GetAll();

                    //    usuario.Rol = new ML.Rol();

                    //    usuario.Direccion = new ML.Direccion();
                    //    usuario.Direccion.Colonia = new ML.Colonia();
                    //    usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                    //    usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                    //    usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();


                    //    usuario.Rol.Roles = resultRol.Objects;
                    //    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                    //    return View(usuario);

                    //}
                //else
                //{
                    
                //    result = new ML.Result();//Agregar PROP correctas

                //    if (usuario.IdUsuario == 0)
                //    {
                //        result = BL.Usuario.Add(usuario);

                //        if (result.Correct)
                //        {
                //            ViewBag.Message = "Alumno agregado correctamente";
                //        }
                //        else
                //        {
                //            ViewBag.Message = "Ocurrio un error al agregar al alumno" + result.Message;
                //        }
                //    }

                //}
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

                //result = BL.Usuario.Update(usuario);

                //SERVICIOS WEB API UPDATE
                result.Objects = new List<object>();

                string urlAPI = _configuration["UrlAPI"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);
                        
                    var responseTask = client.PostAsJsonAsync<ML.Usuario>("Usuario/UpdateUsuario/" + usuario.IdUsuario, usuario);
                    responseTask.Wait();
                            
                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "El usuario ha sido actualizado correctamente";
                    }
                    else
                    {
                        ViewBag.Message = "El usuario no pudo ser actualizado" + result.Message;
                    }
                }
            }

            //Result Correct
            //if (result.Correct)
            //    {
            //        ViewBag.Message = result.Message;
            //    }
            //    else
            //    {
            //        ViewBag.Message = "Ocrrio un error";
            //    }
            //}
            return PartialView("Modal");
        }   
        
        //ELIMINAR
        [HttpGet]
        public ActionResult Delete(int? IdUsuario)
        {
            ML.Result result = new ML.Result();
            if (IdUsuario >= 1)
            {
                //ML.Result result = BL.Usuario.Delete(IdUsuario.Value);

                try
                {
                    string urlAPI = _configuration["UrlAPI"];
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(urlAPI);
                        var responseTask = client.DeleteAsync("Usuario/DeleteUsuario/" + IdUsuario);
                        responseTask.Wait();

                        var resultServicio = responseTask.Result;

                        if (resultServicio.IsSuccessStatusCode)
                        {
                            ViewBag.Message = "El usuario ha sido eliminada";

                        }
                        else
                        {
                            ViewBag.Message = "El usuario no pudo ser eliminado" + result.Message;
                        }
                    }

                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.Message = ex.Message;
                }
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
        public JsonResult CambiarStatus(int IdUsuario,bool status)
        {
            var result = BL.Usuario.UpdateStatus(IdUsuario,status);
            return Json(result);
        }
    }
}
