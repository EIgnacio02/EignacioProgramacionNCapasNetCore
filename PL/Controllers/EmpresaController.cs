using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class EmpresaController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Empresa empresa = new ML.Empresa();
            ML.Result result = BL.Empresa.GetAll(empresa);


            if (result.Correct)
            {
                empresa.Empresas = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
            }
            return View(empresa);
        }

        [HttpPost]
        public ActionResult GetAll(ML.Empresa empresa)
        {
            ML.Result result = BL.Empresa.GetAll(empresa);
            empresa = new ML.Empresa();

            if (result.Correct)
            {
                empresa.Empresas = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
            }
            return View(empresa);
        }
        [HttpGet]
        public ActionResult Form(int? IdEmpresa)
        {
            if (IdEmpresa == null)
            {
                //MOSTRAR FORMULARIO
                return View();
            }
            else
            {
                //GETBYID
                ML.Result result = BL.Empresa.GetById(IdEmpresa.Value);
                ML.Empresa empresa = new ML.Empresa();

                if (result.Correct)
                {
                    empresa = (ML.Empresa)result.Object;
                }
                else
                {
                    ViewBag.Message = "Ocurrio un errro al solicitar los datos";
                }
                return View(empresa);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Empresa empresa)
        {
            if (empresa.IdEmpresa == 0)
            {
                IFormFile image = Request.Form.Files["ImagenData"];
                if (image != null)
                {
                    //llamar al metodo que convierte a bytes la imagen
                    byte[] ImagenBytes = ConvertToBytes(image);
                    //convierto a base 64 la imagen y la guardo en la propiedad de imagen en el objeto usuario
                    empresa.Imagen = Convert.ToBase64String(ImagenBytes);
                }

                ML.Result result = BL.Empresa.Add(empresa);
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error";
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
                    empresa.Imagen = Convert.ToBase64String(ImagenBytes);
                }

                ML.Result result = BL.Empresa.Update(empresa);
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error";
                }
            }

            //Creamos el modal 
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int? IdEmpresa)
        {

            if (IdEmpresa >= 1)
            {
                ML.Result result = BL.Empresa.Delete(IdEmpresa.Value);
                ViewBag.Message = result.Message;

            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
            }
            return PartialView("Modal");

        }


        //Convertir Bytes
        public static byte[] ConvertToBytes(IFormFile Imagen)
        {
            using var fileStream = Imagen.OpenReadStream();


            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);

            return bytes;
        }
    }
}
