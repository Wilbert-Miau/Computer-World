using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_World.BL
{
   public class DatosdeInicio: CreateDatabaseIfNotExists<Contexto>
    {

        protected override void Seed(Contexto contexto)
        {
            var nuevoUsuario = new Usuario();
            nuevoUsuario.Nombre = "admin";
            nuevoUsuario.Contrasena = Encriptar.CodificarContrasena("123");
            contexto.Ususarios.Add(nuevoUsuario);
            base.Seed(contexto);
        }
    }
}
