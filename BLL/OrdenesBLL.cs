using Microsoft.EntityFrameworkCore;
using OrdenesDeCompra.Dal;
using OrdenesDeCompra.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OrdenesDeCompra.BLL
{
    public class OrdenesBLL
    {
        public static bool Guardar(Ordenes ordenes)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Ordenes.Add(ordenes) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Ordenes ordenes)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Database.ExecuteSqlRaw($"Delete FROM OrdeneDetalle where OrdenId = {ordenes.OrdenId}");
                foreach (var item in ordenes.Detalles)
                {
                    db.Entry(item).State = EntityState.Added;
                }
                db.Entry(ordenes).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
                
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.Ordenes.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Ordenes Buscar(int id)
        {
            Ordenes ordenes = new Ordenes();
            Contexto db = new Contexto();

            try
            {
                ordenes = db.Ordenes.Where(o => o.OrdenId == id).
                     Include(d => d.Detalles).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return ordenes;
        }

        public static List<Ordenes> GetList(Expression<Func<Ordenes, bool>> ordenes)
        {
            List<Ordenes> lista = new List<Ordenes>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Ordenes.Where(ordenes).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return lista;
        }
    }
}
