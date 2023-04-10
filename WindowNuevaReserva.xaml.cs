using DI06_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Dominio;
using DI06_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Negocio;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DI06_Tarea_Fernandez_Chacon_EnriqueOctavio
{
    /// <summary>
    /// Lógica de interacción para WindowNuevaReserva.xaml
    /// </summary>
    public partial class WindowNuevaReserva : Window
    {
        private Clientes clientes;
        private Reservas reservas;
        private Reserva reserva;
        private int errores;
        private int numeroClientes;
        private bool modificar = false;
        
        /// <summary>
        /// Constructor para crear reservas
        /// </summary>
        /// <param name="clientes"></param>
        /// <param name="reservas"></param>
        public WindowNuevaReserva(Clientes clientes, Reservas reservas)
        {
            InitializeComponent();
            //Pantalla nueva centrada
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //Establecemos la lógica
            this.clientes = clientes;
            this.reservas = reservas;
            //Creamos una reserva y la establecemos como contexto
            this.reserva = new Reserva();
            this.DataContext = this.reserva;
            InicializarComponentes();
        }
        

        /// <summary>
        /// Constructor para modificar reservas
        /// </summary>
        /// <param name="clientes"></param>
        /// <param name="reservas"></param>
        /// <param name="reserva"></param>
        public WindowNuevaReserva(Clientes clientes, Reservas reservas, Reserva reserva)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.clientes = clientes;
            this.reservas = reservas;
            //Diferencia en que la reserva asignada al contexto, es la pasado por parametro
            this.reserva = reserva;
            this.DataContext = this.reserva;
            modificar = true;
            InicializarComponentes();
        }

        /// <summary>
        /// Metodo auxiliar para inicializar la vista
        /// </summary>
        private void InicializarComponentes()
        {
            //Establecemos los objetos para los comboBox, tanto de clientes como los tipos de cita
            cbClientes.ItemsSource = clientes.GetClientes();
            cbMotivo.ItemsSource = Enum.GetValues(typeof(TipoCita)).Cast<TipoCita>();
            //Asignamos a la variable la cantidad de cliente
            numeroClientes = clientes.GetClientes().Count();

            //Comprobamos si esta modificando o creando una reserva
            if (modificar)
            {
                /*MODIFICANDO
                 * Establecemos la hora y los minutos en su campo
                 * Cambiamos algunos textos para adecuarlos a la funcionalidad*/
                tbHora.Text = reserva.Fecha.Hour.ToString();
                tbMinutos.Text = reserva.Fecha.Minute.ToString();
                btReservar.Content = "Modificar";
                this.Title = "Modificar Reserva";
                lTitulo.Content = "Modificar Reserva";
            }
            else
            {
                /*CREANDO
                 * Fecha por defecto: Ahora mismo
                 * Cliente por defecto: EL primero
                 * Tipo de cita por defecto: Revision
                 * Hora por defecto: 10:00*/
                reserva.Fecha = DateTime.Now;
                reserva.Cliente = clientes.BuscarCliente(1);
                reserva.TipoCita = TipoCita.Revision;
                tbHora.Text = "10";
            }
     
        }

        /// <summary>
        /// Evento que gestiona el boton cancelar cerrando la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Metodo que comprueba los datos introducidos por el usuario,
        /// si son correctos, crea una reserva y la añade a la lista de reservas.
        /// Si no, muestra un mensaje de error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReservar_Click(object sender, RoutedEventArgs e)
        {
            //creo variable flag, y de apoyo para el tiempo1
            bool centinela = true;
            int hora;
            int minutos;

            //compruebo que la hora sea numerica
            if (!int.TryParse(tbHora.Text, out hora)) 
            {
                centinela = false;
                MessageBox.Show("El campo hora debe ser numérico", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //compruebo que los minutos sean numericos
            if (!int.TryParse(tbMinutos.Text, out minutos))
            {
                centinela = false;
                MessageBox.Show("El campo minutos debe ser numérico", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } //si es numerico, compruebo el rango de lso minutos
            else if (minutos < 0 || minutos > 59)
            {
                centinela = false;
                MessageBox.Show("Valor del campo minutos fuera de rango", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (centinela)
            {
                //Compruebo el rango de las horas, en este caso, se aceptan reservas de 10:00 a 23:59
                if (hora < 10 || hora > 23)
                {
                    centinela = false;
                    MessageBox.Show("El horario de reserva es de 10:00 a 23:59", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            if (centinela)
            {
                //Al validar los datos para la fecha, creo un nuevo objeto DateTime con los datos del formulario
                DateTime fecha = new DateTime(reserva.Fecha.Year, reserva.Fecha.Month, reserva.Fecha.Day, Int32.Parse(tbHora.Text), Int32.Parse(tbMinutos.Text), 0);
                //Condicion mia para reservar como minimo una hora en el futuro
                if (DateTime.Compare(fecha, DateTime.Now.AddHours(1)) < 0)
                {
                    centinela = false;
                    MessageBox.Show("La fecha y hora de la reserva debe ser posterior a 1 hora desde el momento actual", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                if (centinela)
                {
                    //Si todo es correcto, asigno la fecha y el valor de seleccionado en los radioButton referidos al seguro
                    reserva.Fecha = fecha;
                    reserva.Seguro = (bool) rbSi.IsChecked;
                    //Llamo al metodo que corresponda
                    if (modificar)
                    {
                        reservas.ModificarReserva(reserva);
                    } 
                    else
                    {
                        reservas.AgregarReserva(reserva);
                    }
                    this.Close();
                }
            }
        }
       
        /// <summary>
        /// Evento que gestiona el cierre de la ventana, tras ello muestra el listado principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            Owner.Show();
        }

        /// <summary>
        /// Metodo para gestionar el clic en nuevo cliente, crea una ventana de dialogo para crear un nuevo cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNuevoCliente_Click(object sender, RoutedEventArgs e)
        {
            //Creo la ventana
            DialogoCliente dialogoCliente = new DialogoCliente(clientes);
            //Asigno este elemento como padre
            dialogoCliente.Owner = this;
            //Muestro la ventana y oculto esta
            dialogoCliente.Show();
            Hide();
        }
        
        /// <summary>
        /// Metodo para la gestion de errores en los campos del formulario
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
                btReservar.IsEnabled = true;
            else
                btReservar.IsEnabled = false;

        }

        /// <summary>
        /// Metodo que selecciona el nuevo cliente de forma automatica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisibilidadChange(object sender, DependencyPropertyChangedEventArgs e)
        {
            //Si hay mas clientes ahora que antes, es que se ha añadido un nuevo cliente
            if (numeroClientes != clientes.GetClientes().Count)
            {
                //En caso positivo, selecciono automaticamente ese nuevo cliente
                cbClientes.SelectedIndex = clientes.GetClientes().Count - 1;
            }
        }
    }
}
