using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_World.BL
{
    public class Producto
    {
        public Producto()
        {
            Activo = true;
        }
        public int Id { get; set; }

        [Display(Name ="Descripción")]
        [Required(ErrorMessage = "Ingrese una descripcion")]
        [MinLength(3, ErrorMessage = "Ingrese minimo 3 caracteres")]
        [MaxLength(20, ErrorMessage = "Ingrese maximo 20 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage ="Ingrese el precio")]
        [Range(0,100000, ErrorMessage ="Ingrese un precio entre 0 y 100 mil")]
        public double Precio { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }


        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }
        public bool Activo { get; set; }
    }
}
