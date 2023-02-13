using System.ComponentModel;
using System;
using System.Text.RegularExpressions;

namespace DI04_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Dominio
{
    public class Cliente : INotifyPropertyChanged, ICloneable, IDataErrorInfo
    {
        public int? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? Telefono { get; set; }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string result = "";
                if (columnName == "Nombre")
                {
                    if (string.IsNullOrEmpty(this.Nombre))
                    {
                        result = "El campo nombre no debe estar vacio";
                    }
                }
                if (columnName == "Apellidos")
                {
                    if (string.IsNullOrEmpty(this.Apellidos))
                    {
                        result = "El campo apellidos no debe estar vacio";
                    }
                }
                if (columnName == "Telefono")
                {
                    if (string.IsNullOrEmpty(this.Telefono))
                    {
                        result = "El campo teléfono no debe estar vacio";
                    } else if (!Regex.IsMatch(Telefono, "[6789]\\d{8}"))
                    {
                        result = "El campo telefono no es correcto";
                    }
                }
                return result;
            }
        }

        public Cliente() { }

        public Cliente(string nombre, string apellidos, string telefono)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Telefono = telefono;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public override string ToString()
        {
            return Nombre + " " + Apellidos;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
