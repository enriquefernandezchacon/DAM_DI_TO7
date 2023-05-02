using DI07_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Dominio;
using DI07_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Negocio;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace DI07_Tarea_Fernandez_Chacon_EnriqueOctavio
{
    /// <summary>
    /// Lógica de interacción para DialogoCliente.xaml
    /// </summary>
    public partial class DialogoCliente : Window
    {
        private Cliente cliente;
        private Clientes clientes;
        private int errores;

        /// <summary>
        /// Constructor del formulario de clientes
        /// </summary>
        /// <param name="clientes">Modulo para gestionar los clientes de la aplicación</param>
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

        /// <summary>
        /// Método que gestiona los errores del formulario así como el conteo de los mismos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Evento del boton aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTAceptarClick(object sender, RoutedEventArgs e)
        {
            clientes.AgregarCliente(cliente);
            this.Close();
        }

        /// <summary>
        /// Evento del boton cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTCancelarClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento para mostrar el formulario principal al cerrar el formulario de clientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Show();
        }

        /// <summary>
        /// Gestion de los errores del campo nombre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxNombre_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxNombre.Text))
            {
                MessageBox.Show("Debes completar el campo nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        /// <summary>
        /// Gestion de los errores del campo apellidos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxApellidos_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxApellidos.Text))
            {
                MessageBox.Show("Debes completar el campo apellido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Gestion de los errores del campo telefono
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
