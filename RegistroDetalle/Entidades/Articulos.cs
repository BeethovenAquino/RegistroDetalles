using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RegistroDetalle.Entidades
{
    public class Articulos
    {
        [Key]

        public int ArticuloID { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int CantidadCotizada { get; set; }
        public DateTime FehaVencimiento { get; set; }

        public Articulos()
        {

        }

        public override string ToString()
        {
            return this.Descripcion;
        }
    }
}
