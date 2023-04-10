using DI06_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Dominio;
using DI06_Tarea_Fernandez_Chacon_EnriqueOctavio.DTO.Negocio;
using DI06_Tarea_Fernandez_Chacon_EnriqueOctavio.Vistas.Clientes;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DI06_Tarea_Fernandez_Chacon_EnriqueOctavio
{
    public partial class MainWindow : Window
    {
        /*Los dos elementos con los que trabajaremos, la lista de clientes, y la lista de reservas*/
        private Reservas reservas;
        private Clientes clientes;

        /// <summary>
        /// Constructor de la ventana principal
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            //Inicializamos las clases de negocio
            reservas = new Reservas();
            clientes = new Clientes();
            //Cargamos los datos y creamos la tabla
            InicializarDatos();
            CrearTabla();
            //Mostramos la ventana nueva en el centro de la pnatalla
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    
        /// <summary>
        /// Gestion del click en nueva reserva, se abre una nueva ventana para crear una nueva reserva
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_NuevaReserva(object sender, RoutedEventArgs e) {
            //Instancio la ventana de reserva, y paso por parametro la lógica de negocio
            WindowNuevaReserva window = new WindowNuevaReserva(clientes, reservas);
            //Establezco esta ventana como padre de la nueva
            window.Owner = this;
            //Oculto esta ventana
            Hide();
            //Muestro la nueva ventana
            window.Show();
        }

        /// <summary>
        /// Metodo que borra la reserva seleccionada en la tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BorrarReserva_Click(object sender, RoutedEventArgs e)
        {
            //Compruebo si hay alguna reserva seleccionada
            if (dgReservas.SelectedIndex == -1) 
            {
                //Si no hay nada seleccionado, muestro un mensaje de error
                MessageBox.Show("No ha seleccionado ninguna reserva para borrar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else 
            {
                //Si hay seleccionada, muestro mensaje de coinfirmacion
                MessageBoxResult result = MessageBox.Show("¿Esta seguro de borrar la reserva?", "Borrar Reserva", MessageBoxButton.YesNo, MessageBoxImage.Question);
                //Si se confirma, borro la reserva
                if (result == MessageBoxResult.Yes)
                {
                    //Obtengo la reserva seleccionada
                    Reserva reserva = (Reserva) dgReservas.SelectedItem;
                    //Obtengo el id de la reserva y se lo paso al metodo de la lógica de negocio
                    reservas.BorrarReserva(reserva.Id);
                }
            }
        }

        /// <summary>
        /// Metodo para modificar una reserva, se abre una nueva ventana para modificar la reserva seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModificarReserva_Click(object sender, RoutedEventArgs e)
        {
            //Compruebo que haya alguna seleccionada
            if (dgReservas.SelectedIndex == -1)
            {
                MessageBox.Show("No ha seleccionado ninguna reserva para modificar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //Obtengo la reserva
                Reserva reserva = (Reserva)dgReservas.SelectedItem;
                //Nueva ventana, usando el constructor para las modifiaciones
                WindowNuevaReserva window = new WindowNuevaReserva(clientes, reservas, reserva);
                //Establezco el padre
                window.Owner = this;
                //Oculto esta ventana y muestro la nueva
                this.Hide();
                window.Show();
            }
            
        }

        /// <summary>
        /// Gestion del click en el boton salir, cierra la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_Salir(object sender, RoutedEventArgs e) {
            Close();
        }

        /// <summary>
        /// Metodo para mostrar el dialogo de "Acerca de"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_ClickAcercaDe(object sender, RoutedEventArgs e) {
            //Creo la ventana
            WindowAcercaDe windowAcercaDe = new WindowAcercaDe();
            //Establezco el padre
            windowAcercaDe.Owner = this;
            //Establezco el titulo
            windowAcercaDe.Title = "Acerca De";
            //Oculto esta ventana y muestro la nueva
            Hide();
            windowAcercaDe.Show();
        }

        /// <summary>
        /// Metodo para mostrar el dialogo de "Añadir Cliente"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_AnadirCliente(object sender, RoutedEventArgs e)
        {
            //Creo la ventana
            WindowAnadirCliente windowAnadirCliente = new();
            //Establezco el padre
            windowAnadirCliente.Owner = this;
            //Establezco el titulo
            windowAnadirCliente.Title = "Añadir Cliente";
            //Oculto esta ventana y muestro la nueva
            this.Hide();
            windowAnadirCliente.Show();
        }

        /// <summary>
        /// Metodo que reinicia el contenido de la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReiniciarContenido(object sender, RoutedEventArgs e)
        {
            //Limpio los datos del negocio
            reservas.GetReservas().Clear();
            clientes.GetClientes().Clear();
            //Me creo como cliente y lo agrego a la lógica
            Cliente c1 = new Cliente("Enrique Octavio", "Fernandez Chacon", "656656656");
            clientes.AgregarCliente(c1);
            //Creo la cita y la agrego a la lógica
            Reserva r1 = new Reserva(c1, DateTime.Now, TipoCita.Revision, true);
            reservas.AgregarReserva(r1);
        }

        /// <summary>
        /// Metodo que configura la tabla de reservas
        /// </summary>
        private void CrearTabla()
        {
            //Establezco la fuente de datos
            dgReservas.ItemsSource = reservas.GetReservas();
            //Creo las columnas con sun Binding
            dgReservas.Columns.Add(new DataGridTextColumn { Binding = new Binding("Fecha") });
            dgReservas.Columns.Add(new DataGridTextColumn { Binding = new Binding("TipoCita") });
            dgReservas.Columns.Add(new DataGridTextColumn { Binding = new Binding("Cliente.Nombre") });
            dgReservas.Columns.Add(new DataGridTextColumn { Binding = new Binding("Cliente.Apellidos") });
            dgReservas.Columns.Add(new DataGridTextColumn { Binding = new Binding("Cliente.Telefono") });
            dgReservas.Columns.Add(new DataGridTextColumn { Binding = new Binding("Seguro") });
            //Establezco el titulo de las columnas
            dgReservas.Columns[0].Header = "Fecha";
            dgReservas.Columns[1].Header = "Tipo de cita";
            dgReservas.Columns[2].Header = "Nombre del Paciente";
            dgReservas.Columns[3].Header = "Apellidos del Paciente";
            dgReservas.Columns[4].Header = "Teléfono";
            dgReservas.Columns[5].Header = "Seguro Privado";
        }

        /// <summary>
        /// Metodo que se ejecuta cuando se muestra la ventana, se encarga de actualizar la tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisibilidadChange(object sender, DependencyPropertyChangedEventArgs e)
        {
            dgReservas.Items.Refresh();
        }
    }
}
