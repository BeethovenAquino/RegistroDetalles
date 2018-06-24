using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RegistroDetalle.Entidades
{
   public class Persona

    {
        [Key]
        public int PersonaID { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public Persona()
        {
        }

      
    }


}
