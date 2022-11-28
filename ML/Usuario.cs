using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        //Creacion constructores
        public int IdUsuario { get; set; }
        //[Required]
        public string UserName { get; set; }
        //[Required]
        public string Nombre { get; set; }
        //[Required]
        [DisplayName("Apellido Paterno")]
        public string ApellidoPaterno { get; set; }
        //[Required]
        [DisplayName("Apellido Materno")]
        public string ApellidoMaterno { get; set; }
        //[Required]
        //[RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
        public string Email { get; set; }
        //[Required]
        public string Password { get; set; }
        //[Required]
        [DisplayName("Fecha de nacimiento")]
        public string FechaNacimiento { get; set; }
        //[Required]        //[Required]
        public string Sexo { get; set; }
        //[Required]
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Curp { get; set; }

        public ML.Rol Rol { get; set; }//Propiedad de navegacion
        public bool Status { get; set; }
        public ML.Direccion Direccion { get; set; }
        //public ML.Pais Pais { get; set; }

        //Creamos una lista de objetos para guardar los datos del result
        //ya que result tambien es una lista 
        public List<object> Usuarios { get; set; }

        //Agregar imagen
        public string Imagen { get; set; }
    }
}
