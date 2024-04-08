using ejercicioCrud.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioCrud.Dato
{
    public class ProductoAdmin
    {
        public List<productos> Consultar()
        {
            using (supermerkEntities contexto = new supermerkEntities())
            {
                return contexto.productos.AsNoTracking().ToList();
            }
        }

        public void Guardar(productos modelo)
        {
            using (supermerkEntities contexto = new supermerkEntities())
            {
                contexto.productos.Add(modelo);
                contexto.SaveChanges();
            }
        }

        public void Actualizar(productos modelo)
        {
            using (supermerkEntities contexto = new supermerkEntities())
            {
                contexto.Entry(modelo).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }


        public void Borrar (int pId)
        {
            using (supermerkEntities contexto = new supermerkEntities())
            {
                contexto.productos.Remove(contexto.productos.Single(p => p.Id == pId));
                contexto.SaveChanges();
            }
        }

        public productos buscarid(int pId)
        {
            using (supermerkEntities contexto = new supermerkEntities())
            {
                return contexto.productos.FirstOrDefault(p => p.Id == pId);
            }
        }


        public List<productos> buscarnombre(String pNom)
        {
            using (supermerkEntities contexto = new supermerkEntities())
            {
                return contexto.productos.Where(p => p.nombre_Producto.Contains(pNom)).ToList();
            }
        }

    }

}

