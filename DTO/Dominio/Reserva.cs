using System;
using System.ComponentModel;

namespace DI07_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Dominio
{
    public class Reserva : INotifyPropertyChanged, ICloneable, IDataErrorInfo
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public TipoCita TipoCita { get; set; }
        public Boolean Seguro { get; set; }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string result = "";
                if (columnName == "Fecha")
                {
                    if (Fecha == null)
                    {
                        result = "El campo Fecha no debe ser nulo";
                    }
                }
                if (columnName == "TipoCita")
                {
                    if (TipoCita == null)
                    {
                        result = "El campo Tipo de cita no debe ser nulo";
                    }
                }
                if (columnName == "Seguro")
                {
                    if (Seguro == null)
                    {
                        result = "El campo seguro no debe ser nulo";
                    }
                }
                if (columnName == "Cliente")
                {
                    if (Cliente == null)
                    {
                        result = "El campo cliente no debe ser nulo";
                    }
                }
                return result;
            }
        }

        public Reserva()
        {

        }

        public Reserva(Cliente cliente, DateTime fecha, TipoCita tipoCita, Boolean seguro)
        {
            Cliente = cliente;
            Fecha = fecha;
            TipoCita = tipoCita;
            Seguro = seguro;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
