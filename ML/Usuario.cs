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
        //[Required]
        //Creacion constructores
        public int IdUsuario { get; set; }
        public string UserName { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Apellido Paterno")]
        public string ApellidoPaterno { get; set; }
        [DisplayName("Apellido Materno")]
        public string ApellidoMaterno { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [DisplayName("Fecha de nacimiento")]
        public string FechaNacimiento { get; set; }
        public string Sexo { get; set; }
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
