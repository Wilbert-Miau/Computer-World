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
            contexto.Usuarios.Add(nuevoUsuario);
           

            var nuevoUsuario1 = new Usuario();
            nuevoUsuario1.Nombre = "Emilson";
            nuevoUsuario1.Contrasena = Encriptar.CodificarContrasena("123");
            contexto.Usuarios.Add(nuevoUsuario1);
            

            var nuevoUsuario2 = new Usuario();
            nuevoUsuario2.Nombre = "Erick";
            nuevoUsuario2.Contrasena = Encriptar.CodificarContrasena("123");
            contexto.Usuarios.Add(nuevoUsuario2);
            

            var nuevoUsuario3 = new Usuario();
            nuevoUsuario3.Nombre = "Elvin";
            nuevoUsuario3.Contrasena = Encriptar.CodificarContrasena("123");
            contexto.Usuarios.Add(nuevoUsuario3);
            

            var nuevoUsuario4 = new Usuario();
            nuevoUsuario4.Nombre = "Wilbert";
            nuevoUsuario4.Contrasena = Encriptar.CodificarContrasena("123");
            contexto.Usuarios.Add(nuevoUsuario4);
            base.Seed(contexto);


        }
    }
}
