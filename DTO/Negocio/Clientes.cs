using DI07_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Dominio;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DI07_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Negocio
{
    public class Clientes
    {
        public ObservableCollection<Cliente> listadoClientes;
        private int id = 1;

        /// <summary>
        /// Constructor de la clase Clientes
        /// </summary>
        public Clientes()
        {
            listadoClientes = new ObservableCollection<Cliente>();
        }

        /// <summary>
        /// Metodo que permite agregar un cliente a la lista de clientes
        /// </summary>
        /// <param name="cliente">Objeto creado a guardar</param>
        public void AgregarCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                cliente.Id = id++;
                listadoClientes.Add(cliente);
            }
        }

        /// <summary>
        /// Metodo que permite buscar un cliente por su id
        /// </summary>
        /// <param name="id">Id del cliente en la BD</param>
        /// <returns>El cliente encontrado o null si no lo enceuntra</returns>
        public Cliente? BuscarCliente(int id)
        {
            return listadoClientes.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Devuelve una lista de clientes
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Cliente> GetClientes()
        {
            return listadoClientes;
        }
    }
}
