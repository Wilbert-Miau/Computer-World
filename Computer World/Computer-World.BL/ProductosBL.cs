using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_World.BL
{
    public class ProductosBL
    {
        Contexto _contexto; //variable global conexion a la base de datos
        public List<Producto> ListadeProductos { get; set; }  // lista vacia para guardar los datos


        public ProductosBL()
        {
            _contexto = new Contexto();
            ListadeProductos = new List<Producto>();

        }

        public List<Producto> ObtenerProductos()
        {
            ListadeProductos = _contexto.Productos 
                .Include("Categoria")
                .OrderBy(r=> r.Categoria.Descripcion)
                .ThenBy(r=>r.Descripcion)
                .ToList(); //igualar para retornar la variable mas facil de entender
            return ListadeProductos;   
        }

        public List<Producto> ObtenerProductosActivos()
        {
            ListadeProductos = _contexto.Productos
                .Include("Categoria")
                .OrderBy(r=>r.Descripcion)
                .Where(r => r.Activo == true)
                .ToList(); //igualar para retornar la variable mas facil de entender
            return ListadeProductos;
        }

        public void GuardarProductos(Producto producto)
        {
            if (producto.Id == 0)
            {
                _contexto.Productos.Add(producto);
                

            }else
            {
                var productoExistente = _contexto.Productos.Find(producto.Id);
                productoExistente.Descripcion = producto.Descripcion;
                productoExistente.Precio = producto.Precio;
                productoExistente.UrlImagen = producto.UrlImagen;
                

            }
            _contexto.SaveChanges();
        }

        public Producto ObtenerProducto(int id)
        {
            var producto = _contexto.Productos.Include("Categoria").FirstOrDefault(p => p.Id == id);
            return producto;
        }

        public void EliminarProducto(int id)
        {
            var producto = _contexto.Productos.Find(id);
            _contexto.Productos.Remove(producto);
            _contexto.SaveChanges();
        }

        
    }
}
