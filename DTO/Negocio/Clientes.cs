using DI06_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Dominio;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DI06_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Negocio
{
    public class Clientes
    {
        public ObservableCollection<Cliente> listadoClientes;
        private int id = 1;

        public Clientes()
        {
            listadoClientes = new ObservableCollection<Cliente>();
        }

        //Metodos de la lógica de negocio
        public void AgregarCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                cliente.Id = id++;
                listadoClientes.Add(cliente);
            }
        }

        public Cliente? BuscarCliente(int id)
        {
            return listadoClientes.FirstOrDefault(c => c.Id == id);
        }

        public ObservableCollection<Cliente> GetClientes()
        {
            return listadoClientes;
        }
    }
}
