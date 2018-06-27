using RegistroDetalle.DAL;
using RegistroDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RegistroDetalle.BLL
{
    public class ContizacionBLL
    {
        public static bool Guardar(Cotizaciones cotizacion)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Cotizaciones.Add(cotizacion) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }

                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Modificar(Cotizaciones cotizacion)
        {

            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
             
                foreach (var item in cotizacion.Detalle)
                {
                    
                    var estado = item.ID > 0 ? EntityState.Modified : EntityState.Added;
                    contexto.Entry(item).State = estado;
                }

               
                contexto.Entry(cotizacion).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }

        public static bool Eliminar(int id)
        {

            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {

                Cotizaciones cotizacion = contexto.Cotizaciones.Find(id);
                contexto.Cotizaciones.Remove(cotizacion);
                if (contexto.SaveChanges() > 0)
                {

                    paso = true;

                }

                contexto.Dispose();

            }

            catch (Exception)
            {

                throw;

            }

            return paso;
        }

        public static Cotizaciones Buscar(int id)
        {

            Cotizaciones cotizacion = new Cotizaciones();
            Contexto contexto = new Contexto();

            try
            {
                cotizacion = contexto.Cotizaciones.Find(id);
                
                cotizacion.Detalle.Count();

               
                foreach (var item in cotizacion.Detalle)
                {
                    
                    string s = item.Articulos.Descripcion;
                    //string r = item.Personas.Nombres;
                }
                contexto.Dispose();
            }

            catch (Exception)
            {

                throw;

            }

            return cotizacion;

        }

        public static List<Cotizaciones> GetList(Expression<Func<Cotizaciones, bool>> expression)
        {

            List<Cotizaciones> Cotizaciones = new List<Cotizaciones>();
            Contexto contexto = new Contexto();

            try
            {

                Cotizaciones = contexto.Cotizaciones.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return Cotizaciones;
        }

        public static decimal CalcularImporte(decimal precio, int cantidad)
        {
            return Convert.ToDecimal(precio) * Convert.ToInt32(cantidad);
        }

    }
}
