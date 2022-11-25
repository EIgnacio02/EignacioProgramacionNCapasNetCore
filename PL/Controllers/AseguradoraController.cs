using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class AseguradoraController : Controller
    {
        public ActionResult GetAll()
        {
            ML.Result result = BL.Aseguradora.GetAll();

            ML.Aseguradora aseguradora = new ML.Aseguradora();

            if (result.Correct)
            {
                aseguradora.Aseguradoras = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
            }

            return View(aseguradora);
        }

        public ActionResult Form(int? IdAseguradora)
        {
            //ML.Result resultUsuario = BL.Usuario.GetAll();
            ML.Aseguradora aseguradora = new ML.Aseguradora();

            aseguradora.Usuario = new ML.Usuario();

            if (IdAseguradora!=null)
            {
                //aseguradora.Usuario.Usuarios=resultUsuario.Objects;
                return View(aseguradora);
            }
            return PartialView("Modal");
        }


        [HttpGet]
        public ActionResult Delete(int? IdAseguradora)
        {
            if (IdAseguradora >= 1)
            {
                ML.Result result = BL.Usuario.Delete(IdAseguradora.Value);
                ViewBag.Message = result.Message;
            }
            else
            {
                ViewBag.Message = "Ocurrio un errror";
            }

            return PartialView("Modal");
        }

    }
}
