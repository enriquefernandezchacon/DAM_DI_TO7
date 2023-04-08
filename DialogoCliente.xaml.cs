using DI06_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Dominio;
using DI06_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DI06_Tarea_Fernandez_Chacon_EnriqueOctavio
{
    /// <summary>
    /// Lógica de interacción para DialogoCliente.xaml
    /// </summary>
    public partial class DialogoCliente : Window
    {
        private Cliente cliente;
        private Clientes clientes;
        private int errores;
        public DialogoCliente(Clientes clientes)
        {
            InitializeComponent();
            //Creo el cliente
            cliente = new Cliente();
            //Lo establezco como contexto
            this.DataContext = cliente;
            //Asigno la logica de negocio
            this.clientes = clientes;
        }

        //Metodo de validacion del boton
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errores++;
            else
                errores--;

            if (errores == 0)
                this.btAceptar.IsEnabled = true;
            else
                this.btAceptar.IsEnabled = false;

        }

        //No hago comprobación, pues si el botón esta activo, es que los campos son correctos
        private void BTAceptarClick(object sender, RoutedEventArgs e)
        {
            clientes.AgregarCliente(cliente);
            this.Close();
        }

        private void BTCancelarClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Cuando se cierra la ventana, se muestra la ventana padre
        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Show();
        }

        //Comprobacion del nombre
        private void TextBoxNombre_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxNombre.Text))
            {
                MessageBox.Show("Debes completar el campo nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //Comprobacion de los apellidos
        private void TextBoxApellidos_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxApellidos.Text))
            {
                MessageBox.Show("Debes completar el campo apellido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //Comprobacion de telefono
        private void TextBoxTelefono_LostFocus(object sender, RoutedEventArgs e)
        {
            //Que no este vacío
            if (string.IsNullOrEmpty(TextBoxTelefono.Text))
            {
                MessageBox.Show("Debes completar el campo telefono", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //Que cumpla con el formato de un número
            } else if (!Regex.IsMatch(TextBoxTelefono.Text, "[6789]\\d{8}")) {
                MessageBox.Show("El formato del campo telefono no es correcto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
