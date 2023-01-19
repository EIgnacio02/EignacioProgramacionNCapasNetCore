using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //MOSTRAR RESULTADOSS
        [HttpGet ("GetAll")]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            ML.Result result = BL.Usuario.GetAll(usuario);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        //BUSCAR POR ID
        // GET api/<UsuarioController>/5
        [HttpGet("GetById/{IdUsuario}")]
        public ActionResult GetById(int IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            ML.Result result = BL.Usuario.GetAllById(IdUsuario);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }



        //BUSQUEDA ABIERTA
        // POST api/<UsuarioController>


        //[HttpPost("GetAllPost")]
        //public ActionResult GetAllPost(string? nombre, string? apellidoPaterno, byte? IdRol)
        //{
        //    ML.Usuario usuario = new ML.Usuario();
        //    usuario.Rol = new ML.Rol();

        //    usuario.Nombre = (nombre == null) ? "" : nombre;
        //    usuario.ApellidoPaterno = (apellidoPaterno == null) ? "" : apellidoPaterno;
        //    usuario.Rol.IdRol = (IdRol == null) ? 0 : IdRol;


        //    ML.Result result = BL.Usuario.GetAll(usuario);


        //    if (result.Correct)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return NotFound(result);
        //    }
        //}


        [HttpPost("GetAllPost")]
        public IActionResult GetAllPost(ML.Usuario usuario)
        {
            //ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();

            ML.Result result = BL.Usuario.GetAll(usuario);


            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }


        [HttpPost("Add")]
        public IActionResult Add([FromBody] ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.Add(usuario);


            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("Update/{IdUsuario}")]
        //public IActionResult Put(int? IdUsuario, string? UserName, string? Nombre, string? ApellidoPaterno, string? ApellidoMaterno, string? Email, string? Password, string? FechaNacimiento, string? Sexo, string? Telefono, string? Celular, string? Curp, byte? IdRol, string? Imagen, string? Calle, string? NumeroInterior, string? NumeroExterior, int? IdColonia)
        public IActionResult Put(int IdUsuario,[FromBody] ML.Usuario usuario)
        {

            usuario.IdUsuario = IdUsuario;
            ML.Result result = BL.Usuario.Update(usuario);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        // DELETE api/<UsuarioController>/
        [HttpDelete("DeleteUsuario/{idUsuario}")]
        public IActionResult Delete(int idUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            ML.Result result = BL.Usuario.Delete(idUsuario);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }


        //Login

        [HttpGet ("Login/{userName}")]
        public ActionResult GetByUserName(string userName)
        {

            ML.Result result = BL.Usuario.GetAllUserName(userName);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);

            }


        }
    }
}
