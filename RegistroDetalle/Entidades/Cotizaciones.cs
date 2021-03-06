﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RegistroDetalle.Entidades
{
   public class Cotizaciones
    {
        [Key]
        public int CotizacionId { get; set; }
        public DateTime Fecha { get; set; }
        [StringLength(100)]
        public string Observaciones { get; set; }
        public int Monto { get; set; }

        public virtual ICollection<DetalleCotizacion> Detalle { get; set; }

        public Cotizaciones()
        {
           
            this.Detalle = new List<DetalleCotizacion>();
        }

        public void AgregarDetalle(int id, int CotizacionId, int PersonaId, int ArticuloId, int Cantidad,string Descripcion, int Precio, int Importe)
        {
            this.Detalle.Add(new DetalleCotizacion(id, CotizacionId, PersonaId, ArticuloId, Cantidad,Descripcion, Precio, Importe));
        }
        
    }
}
