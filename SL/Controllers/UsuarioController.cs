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
        public IActionResult Add(string? UserName, string? Nombre, string? ApellidoPaterno, string? ApellidoMaterno, string?Email, string?Password, string?FechaNacimiento, string? Sexo, string? Telefono, string? Celular, string? Curp, byte? IdRol, string? Imagen, string? Calle, string? NumeroInterior, string? NumeroExterior, int? IdColonia)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            //usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            //usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            //usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

            usuario.UserName = (UserName == null) ? "" : UserName;
            usuario.Nombre = (Nombre == null) ? "" : Nombre;
            usuario.ApellidoPaterno = (ApellidoPaterno == null) ? "" : ApellidoPaterno;
            usuario.ApellidoMaterno = (ApellidoMaterno == null) ? "" : ApellidoMaterno;
            usuario.Email = (Email == null) ? "" : Email;
            usuario.Password = (Password == null) ? "" : Password;
            usuario.FechaNacimiento = (FechaNacimiento == null) ? "" : FechaNacimiento;
            usuario.Sexo = (Sexo == null) ? "" : Sexo;
            usuario.Telefono = (Telefono == null) ? "" : Telefono;
            usuario.Celular = (Celular == null) ? "" : Celular;
            usuario.Curp = (Curp == null) ? "" : Curp;
            usuario.Rol.IdRol = (IdRol == null) ? 0 : IdRol;
            usuario.Imagen = (Imagen == null) ? "" : Imagen;
            usuario.Direccion.Calle = (Calle == null) ? "" : Calle;
            usuario.Direccion.NumeroInterior = (NumeroInterior == null) ? "" : NumeroInterior;
            usuario.Direccion.NumeroExterior = (NumeroExterior == null) ? "" : NumeroExterior;
            usuario.Direccion.Colonia.IdColonia = (int)((IdColonia == null) ? 0 : IdColonia);

            ML.Result result = BL.Usuario.Add(usuario);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);

            }
        }



        // PUT api/<UsuarioController>/5
        [HttpPost("UpdateUsuario/{idUsuario}")]
        //public IActionResult Put(int? IdUsuario, string? UserName, string? Nombre, string? ApellidoPaterno, string? ApellidoMaterno, string? Email, string? Password, string? FechaNacimiento, string? Sexo, string? Telefono, string? Celular, string? Curp, byte? IdRol, string? Imagen, string? Calle, string? NumeroInterior, string? NumeroExterior, int? IdColonia)
        public IActionResult Put(int idUsuario, [FromBody]ML.Usuario usuario)
        {
            usuario.IdUsuario = idUsuario;
            ML.Result result = BL.Usuario.Update(usuario);

            usuario.Rol = new ML.Rol();
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();

            //ML.Usuario usuario = new ML.Usuario();
            //usuario.Rol = new ML.Rol();
            //usuario.Direccion = new ML.Direccion();
            //usuario.Direccion.Colonia = new ML.Colonia();



            //usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            //usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            //usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();



            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();

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
    }
}
