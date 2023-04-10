using DI06_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Dominio;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace DI06_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Negocio
{
    public class Reservas : INotifyCollectionChanged
    {
        private ObservableCollection<Reserva> listado;
        private int id = 1;

        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        /// <summary>
        /// Constructor de la clase Reservas
        /// </summary>
        public Reservas()
        {
            listado = new ObservableCollection<Reserva>();
        }

        /// <summary>
        /// Metodo que permite agregar una reserva a la lista de reservas
        /// </summary>
        /// <param name="reserva">Reserva a añadir</param>
        public void AgregarReserva(Reserva reserva)
        {
            if (reserva != null)
            {
                reserva.Id = id++;
                listado.Add(reserva);
            } 
        }

        /// <summary>
        /// Metodo para borra una reserva de la lista de reservas
        /// </summary>
        /// <param name="id">Id de la reserva en la BD</param>
        public void BorrarReserva(int id)
        {
            Reserva? reserva = listado.FirstOrDefault(r => r.Id == id);
            if (reserva != null)
            {
                listado.Remove(reserva);
            }
        } 
        
        /// <summary>
        /// Metodo para modificar una reseva
        /// </summary>
        /// <param name="reservaModificada">La reserva ya modificada</param>
        public void ModificarReserva(Reserva reservaModificada)
        {
            if (reservaModificada != null)
            {
                Reserva reservaAModificar = listado.FirstOrDefault(r => r.Id == reservaModificada.Id);
                int indice = listado.IndexOf(reservaAModificar);
                listado[indice] = reservaModificada;
            }
        }

        /// <summary>
        /// Metodo que devuelve una lista de reservas
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Reserva> GetReservas()
        {
            return listado;
        }
    }
}
