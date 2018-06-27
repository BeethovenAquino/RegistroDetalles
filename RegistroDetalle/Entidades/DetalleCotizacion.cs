using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace RegistroDetalle.Entidades
{
  public class DetalleCotizacion
    {
        [Key]
        public int ID { get; set; }
        public int CotizacionID { get; set; }
        public int PersonaID { get; set; }
        public int ArticuloID { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public int Importe { get; set; }
        public string Descripcion { get; set; }

        [ForeignKey("ArticuloID")]
        public virtual Articulos Articulos { get; set; }

        [ForeignKey("PersonaID")]
        public virtual Persona Personas { get; set; }

        public DetalleCotizacion()
        {
            this.ID = 0;
            this.CotizacionID = 0;

        }

        public DetalleCotizacion(int id, int cotizacioId, int personaId, int articuloId, int cantidad,string descripcion, int precio, int importe)
        {
            ID = id;
            CotizacionID = cotizacioId;
            PersonaID = personaId;
            ArticuloID = articuloId;
            Cantidad = cantidad;
            Descripcion = Descripcion;
            Precio = precio;
            Importe = importe;
        }
    }
}

