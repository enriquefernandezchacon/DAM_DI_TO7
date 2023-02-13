using DI04_Tarea_Fernandez_Chacon_EnriqueOctavio.Componentes;
using DI04_Tarea_Fernandez_Chacon_EnriqueOctavio.Extensiones;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace DI04_Tarea_Fernandez_Chacon_EnriqueOctavio.Vistas.Clientes
{
    /// <summary>
    /// LÓGICA DE INTERACCIÓN PARA WINDOWANADIRCLIENTE.XAML
    /// </summary>
    public partial class WindowAnadirCliente : Window
    {
        /// <summary>
        /// LISTA CON LOS ERRORES GENERAR POR EL FORMULARIO
        /// </summary>
        private List<string> errores = new List<string>();
        public WindowAnadirCliente()
        {
            InitializeComponent();
        }

        /// <summary>
        /// METODO LLAMADO AL CLICAR EN EL BOTÓN PARA AÑADIR UN CLIENTE
        /// </summary>
        /// <param name="sender">ELEMENTO REQUERIDO POR EL EVENTO</param>
        /// <param name="e">ELEMENTO REQUERIDO POR EL EVENTO</param>
        private void AnadirCliente(object sender, RoutedEventArgs e)
        {
            //INICIALIZAMOS EL ARRAY DE ERRORES SIEMPRE QUE CLIQUEMOS EN EL BOTÓN PARA NO ACUMULARLOS
            errores = new();
            //COMPROBAMOS LOS CAMPOS
            ComprobarCampos();
            //SI HAY ERRORES
            if (errores.Count > 0)
            {
                MostrarErrores();
            }
            //SI NO HAY ERRORES
            else
            {
                ProcesarPeticion();
            }
        }

        /// <summary>
        /// MÉTODO PARA GENERAR UN DIALOGO CON LOS ERRORES
        /// </summary>
        private void MostrarErrores()
        {
            //CABECERA
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("El formulario presente los siguientes errores:");
            sb.AppendLine();
            //SE AÑADEN LOS ERRORES
            foreach (var error in errores)
            {
                sb.AppendLine(string.Concat("- ", error));
            }
            //PIE Y FINAL
            sb.AppendLine();
            sb.AppendLine("Revise los errores y vuelva a intentarlo");
            MessageBox.Show(sb.ToString(), "Errores en el formulario", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// MÉTODO PARA PORCESAR LA PETICIÓN CUANDO LOS DATOS SON CORRECTOS
        /// </summary>
        private void ProcesarPeticion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Cliente añadido con éxito.");
            sb.AppendLine();
            sb.AppendLine(string.Concat(Regex.Replace(TextBoxNombre.Text.Trim(), @"\s+", " "), " ", Regex.Replace(TextBoxApellidos.Text.Trim(), @"\s+", " ")));
            sb.AppendLine(string.Concat("Fecha de nacimiento: ", DatePickerFechaNacimiento.ToString().Substring(0, 10)));
            sb.AppendLine(string.Concat("Teléfono: ", TextBoxTelefono.Text));
            sb.AppendLine(string.Concat("Email: ", TextBoxMail.Text));
            sb.AppendLine(string.Concat("Dirección: ", TextBoxDireccion.Text));

            MessageBox.Show(sb.ToString(), "Cliente Añadido", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ComprobarCampos()
        {
            // NOMBRE
            // COMPRUEBO QUE NO ESTE VACÍO
            if (string.IsNullOrEmpty(TextBoxNombre.Text.Trim()))
            {
                errores.Add("nombre".ErrorVacio());
            }
            //COMPRUEBO QUE SEA VÁLIDO
            else if (!TextBoxNombre.Text.EsValido())
            {
                errores.Add("nombre".ErrorFormato());
            }

            //APELLIDOS
            if (string.IsNullOrEmpty(TextBoxApellidos.Text.Trim()))
            {
                errores.Add("apellidos".ErrorVacio());
            }
            else if (!TextBoxApellidos.Text.EsValido())
            {
                errores.Add("apellidos".ErrorFormato());
            }

            //TELEFONO
            if (string.IsNullOrEmpty(TextBoxTelefono.Text.Trim()))
            {
                errores.Add("telefono".ErrorVacio());
            }
            else if (!TextBoxTelefono.Text.EsTelefono())
            {
                errores.Add("telefono".ErrorFormato());
            }

            //EMAIL
            if (string.IsNullOrEmpty(TextBoxMail.Text.Trim()))
            {
                errores.Add("email".ErrorVacio());
            }
            else if (!TextBoxMail.Text.EsEmail())
            {
                errores.Add("email".ErrorFormato());
            }

            //DNI
            if (string.IsNullOrEmpty(CustomDni.Dni.Trim()))
            {
                errores.Add("dni".ErrorVacio());
            }
            else if (!CustomDni.Dni.EsDni())
            {
                errores.Add("dni".ErrorFormato());
            }

            //DIRECCION
            if (string.IsNullOrEmpty(TextBoxDireccion.Text.Trim()))
            {
                errores.Add("dirección".ErrorVacio());
            }

            //FECHA DE NACIMIENTO

            if (string.IsNullOrEmpty(DatePickerFechaNacimiento.ToString()))
            {
                errores.Add("fecha de nacimiento".ErrorVacio());
            }
        }


        /// <summary>
        /// METODO PARA DETECTAR EL CERRADO DE LA VENTANA Y VOLVER A MOSTRAR LA VENTANA ANTERIOR
        /// </summary>
        /// <param name="sender">ELEMENTO REQUERIDO POR EL EVENTO</param>
        /// <param name="e">ELEMENTO REQUERIDO POR EL EVENTO</param>
        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Show();
        }
    }
}
