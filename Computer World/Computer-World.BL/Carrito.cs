using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_World.BL
{
    class Carrito
    {
        [Key]
        public int RegistroId { get; set; }
        public string CarritoId { get; set; }
        public System.DateTime Fecha { get; set; }

    }
}
