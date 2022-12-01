using Microsoft.AspNetCore.Mvc;
namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();
            ML.Result result = BL.Empleado.GetAll();


            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
            }
            return View(empleado);
        }

        [HttpGet]
        public ActionResult Form(string? NumeroEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();
            ML.Empresa empresa=new ML.Empresa();
            ML.Result resultEmpleado = BL.Empresa.GetAll(empresa);
            empleado.Empresa = new ML.Empresa();
            empleado.Empresa.Empresas = resultEmpleado.Objects;
            if (NumeroEmpleado == null) //ADD
            {
                empleado.Action = "Add";
                return View(empleado);

            }
            else
            {
                //ML.Result result = BL.Empleado.GetById(numero.Value);
                empleado.Action = "Update";
                return View(empleado);
            }

        }

        [HttpPost]
        public ActionResult Form(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            ML.Empresa empresa = new ML.Empresa();

            if (empleado.NumeroEmpleado == null)
            {
                IFormFile image = Request.Form.Files["ImagenData"];
                if (image != null)
                {
                    //llamar al metodo que convierte a bytes la imagen
                    byte[] ImagenBytes = ConvertToBytes(image);
                    //convierto a base 64 la imagen y la guardo en la propiedad de imagen en el objeto usuario
                    empleado.Imagen = Convert.ToBase64String(ImagenBytes);
                }

                if (ModelState.IsValid)
                {
                    // ML.Result resultEmpresa= BL.Empresa.GetAll(empresa);

                    //empleado.Empresa = new ML.Empresa();

                    // empleado.Empresa.Empresas= resultEmpresa.Objects;
                    // return View(empleado);
                    if (empleado.Action == "Add")
                    {
                        result = BL.Empleado.Add(empleado);
                        if (result.Correct)
                        {
                            ViewBag.Message = "El empleado se ha registrado correctamente";
                        }
                        else
                        {
                            ViewBag.Message = "El empleado no se ha registrado correctamente " + result.Message;
                        }

                    }
                    return View(empleado);

                }
                else
                {

                }
            }

                return View(empleado);

        }
        public static byte[] ConvertToBytes(IFormFile Imagen)
        {
            using var fileStream = Imagen.OpenReadStream();


            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);

            return bytes;
        }
    }
}
