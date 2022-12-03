using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Direccion
    {
        public int IdDireccion { get; set; }
        public string Calle { get; set; }
        [DisplayName("Numero Interior")]
        public string NumeroInterior { get; set; }
        [DisplayName("Numero Exterior")]
        public string NumeroExterior { get; set; }
        //Propiedades de navegacion
        //public ML.Usuario Usuario { get; set; }
        public ML.Colonia Colonia { get; set; }

        public List<object> Direcciones { get; set; }
    }
}
