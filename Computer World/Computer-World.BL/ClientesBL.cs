using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_World.BL
{
    public class ClientesBL
    {
        Contexto _contexto;
        public List<Cliente> ListadeCLientes { get; set; }

        public ClientesBL()
        {
            _contexto = new Contexto();
            ListadeCLientes = new List<Cliente>();
        }

        public List<Cliente> ObtenerClientes()
        {
            ListadeCLientes = _contexto.Clientes.ToList(); //obtiene los datos de los clientes en la base de datos
            return ListadeCLientes;
        }
        
        public void GuardarCliente(Cliente cliente)
        {
            if (cliente.Id == 0)
            {
                _contexto.Clientes.Add(cliente);
            }
            else
            {
                var clienteExistente = _contexto.Clientes.Find(cliente.Id);
                clienteExistente.Nombre = cliente.Nombre;
                clienteExistente.Telefono = cliente.Telefono;
                clienteExistente.Direccion = cliente.Direccion;
            }
            _contexto.SaveChanges();
        }

        public Cliente ObtenerCliente(int Id)
        {
            var cliente = _contexto.Clientes.Find(Id);
            return cliente;
        }

        public void EliminarCliente(int Id)
        {
            var cliente = _contexto.Clientes.Find(Id);
            _contexto.Clientes.Remove(cliente);
            _contexto.SaveChanges();

        }



    }
}
