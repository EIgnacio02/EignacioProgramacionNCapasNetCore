using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
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

        // POST api/<UsuarioController>
        [HttpPost("GetAllPost")]
        public ActionResult GetAllPost([FromBody] ML.Usuario usuario)
        {
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

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("DeleteUsuario/{id}")]
        public ActionResult Delete(int idUsuario)
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
    }
}
