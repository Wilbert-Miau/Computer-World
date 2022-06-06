using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_World.BL
{
    public class ProductosBL
    {
        Contexto _contexto; //variable global
        public List<Producto> ListadeProductos { get; set; }


        public ProductosBL()
        {
            _contexto = new Contexto();
            ListadeProductos = new List<Producto>();

        }

        public List<Producto> ObtenerProductos()
        {
            ListadeProductos = _contexto.Productos.ToList(); //igualar para retornar la variable mas facil de entender
            return ListadeProductos;   
        }
    }
}
