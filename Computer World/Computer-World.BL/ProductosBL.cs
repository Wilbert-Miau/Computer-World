﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_World.BL
{
    public class ProductosBL
    {
        List<Producto> ObtenerProductos()
        {
            var producto = new Producto();
            producto.Id = 1;
            producto.Descripcion = "computadora";

            var producto2 = new Producto();
            producto2.Id = 2;
            producto2.Descripcion = "computadora2";
            var producto3 = new Producto();
            producto3.Id = 3;
            producto3.Descripcion = "computadora3";

            var listadeProductos = new List<Producto>();
            listadeProductos.Add(producto);
            listadeProductos.Add(producto2);
            listadeProductos.Add(producto3);
            return listadeProductos;
        }
    }
}