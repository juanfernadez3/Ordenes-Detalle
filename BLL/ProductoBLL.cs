using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OrdenesDeCompra.Entidades;
using OrdenesDeCompra.Dal;
using System.Linq;
using System.Linq.Expressions;

namespace OrdenesDeCompra.BLL
{
    public class ProductoBLL
    {
        public static bool Guardar(Productos productos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Productos.Add(productos) != null)
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

        public static bool Modificar(Productos productos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(productos).State = EntityState.Modified;
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.Productos.Find(id);
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

        public static Productos Buscar(int id)
        {
            Productos productos = new Productos();
            Contexto db = new Contexto();

            try
            {
                productos = db.Productos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return productos;
        }
        /*
        public static bool DisminuirInventario(int id, int cantidad)
        {
            bool paso = false;
            Contexto db = new Contexto();
            Productos productos = new Productos();
            productos = db.Productos.Find(id);

            if (productos != null)
            {
                try
                {
                    if (productos.Cantidad >= 0)
                        productos.Cantidad = (productos.Cantidad - cantidad);


                    db.Entry(productos).State = EntityState.Modified;
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
            }

            return paso;


        }
        */
        public static List<Productos> GetList(Expression<Func<Productos, bool>> producto)
        {
            List<Productos> lista = new List<Productos>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Productos.Where(producto).ToList();
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

