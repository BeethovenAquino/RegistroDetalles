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
    public class PersonaBLL
    {

        public static bool Guardar(Persona personas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Personas.Add(personas) != null)
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

        public static bool Modificar(Persona personas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(personas).State = EntityState.Modified;
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
                Persona persona = contexto.Personas.Find(id);

                contexto.Personas.Remove(persona);

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


        public static Persona Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Persona personas = new Persona();
            try
            {
                personas = contexto.Personas.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return personas;
        }

        public static List<Persona> GetList(Expression<Func<Persona, bool>> expression)
        {
            List<Persona> personas = new List<Persona>();
            Contexto contexto = new Contexto();
            try
            {
                personas = contexto.Personas.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return personas;
        }


    }
}




