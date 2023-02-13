using DI04_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Dominio;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace DI04_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Negocio
{
    public class Reservas : INotifyCollectionChanged
    {
        private ObservableCollection<Reserva> listado;
        private int id = 1;

        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        public Reservas()
        {
            listado = new ObservableCollection<Reserva>();
        }

        //Metodos de la lógica de negocio
        public void AgregarReserva(Reserva reserva)
        {
            if (reserva != null)
            {
                reserva.Id = id++;
                listado.Add(reserva);
            } 
        }

        public void BorrarReserva(int id)
        {
            Reserva reserva = listado.FirstOrDefault(r => r.Id == id);
            if (reserva != null)
            {
                listado.Remove(reserva);
            }
        } 
        //Para modificar la reserva, reemplazo en la lista la reserva a modificar por un nuevo objeto del tipo Reserva
        //con los nuevos datos
        public void ModificarReserva(Reserva reservaModificada)
        {
            if (reservaModificada != null)
            {
                Reserva reservaAModificar = listado.FirstOrDefault(r => r.Id == reservaModificada.Id);
                int indice = listado.IndexOf(reservaAModificar);
                listado[indice] = reservaModificada;
            }
        }

        public ObservableCollection<Reserva> GetReservas()
        {
            return listado;
        }
    }
}
