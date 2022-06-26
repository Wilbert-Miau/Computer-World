using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_World.BL
{
    public class Orden
    {
        public int Id { get; set; }
        public int ClienteId { get; set; } //entityframework lo necesita para insertar en la base de datos, llave foranea
        public Cliente Cliente { get; set; } //entityframework lo necesita el objeto cliente para manejar internamente en el lenguaje
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public bool Activo { get; set; }

        public List<OrdenDetalle> ListadeOrdenDetalle { get; set; }
        public Orden()
        {
            Activo = true;
            Fecha = DateTime.Now;

            ListadeOrdenDetalle = new List<OrdenDetalle>();
        }
    }

    public class OrdenDetalle
    {
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public Orden Orden { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Total { get; set; }
    }
}
