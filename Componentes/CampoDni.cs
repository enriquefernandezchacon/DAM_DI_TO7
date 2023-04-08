using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Controls;
using System.Windows.Input;

namespace DI06_Tarea_Fernandez_Chacon_EnriqueOctavio.Componentes
{
    /// <summary>
    /// LÓGICA DE INTERACCIÓN PARA EL CONTROL DEL DNI
    /// </summary>
    public partial class CampoDni : UserControl, INotifyPropertyChanged
    {
        private string _dni = "";

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Dni
        {
            get { return _dni; }
            set
            {
                _dni = value;
                //ESTA LÍNEA PERMITE A LA VISTA REFRESCARSE TRAS CAMBIOS EN EL MODELO
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Dni)));
            }
        }
        //LONGITUD MÁXIMA DEL TEXT BOX DEL DNI
        public int LongitudMaxima { get; set; } = 8;
        //CAMPO QUE CONTROLA EL ESTADO DEL DISABLED DEL BOTON PARA CALCULAR LA LETRA
        private bool _estadoBoton;
        public bool EstadoBoton
        {
            get { return _estadoBoton; }
            set
            {
                _estadoBoton = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EstadoBoton)));
            }
        }

        public CampoDni()
        {
            InitializeComponent();
            this.DataContext = this;
            EstadoBoton = Dni.Length > 7;
        }

        /// <summary>
        /// METODO PARA DETECTAR LA PULSACIÓN DEL ENTER
        /// </summary>
        /// <param name="sender">PARAMETRO DEL EVENTO</param>
        /// <param name="e">PARAMETRS DEL EVENTO</param>
        public void EventoTecladoCalcularLetra(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Dni = TextBoxEntidad.Text;
                CalcularLetra();
            }
        }

        /// <summary>
        /// EVENTO PARA EL CLICK EN EL BOTÓN
        /// </summary>
        /// <param name="sender">PARAMETRO DEL EVENTO</param>
        /// <param name="e">PARAMETRO DEL EVENTO</param>
        public void EventoClickCalcularLetra(object sender, EventArgs e)
        {
            CalcularLetra();
        }

        /// <summary>
        /// MÉTODO QUE CALCULA LA LETRA DEL DNI INTRODUCIDO EN EL TEXT BOX
        /// </summary>
        private void CalcularLetra()
        {
            if (Dni.Length == 8)
            {
                string[] control = { "T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E" };
                bool flag = Int32.TryParse(Dni, out var dni);
                if (flag)
                {
                    //ANTES DE MODIFICAR EL DNI, AUMENTO LA LONGITUD MAXIMA DEL TEXTBOX A 9 PARA QUE QUEPA LA LETRA
                    LongitudMaxima = 9;
                    Dni += control[dni % 23];
                    Keyboard.ClearFocus();     
                }
            }
        }

        /// <summary>
        /// MÉTODO PARA ELIMINAR LA LETRA CUANDO SE QUIERE EDITAR EL CAMPO DEL DNI
        /// </summary>
        /// <param name="sender">PARAMETRO DEL EVENTO</param>
        /// <param name="e">PARAMETRO DEL EVENTO</param>
        public void QuitarLetra(object sender, EventArgs e)
        {
            //SOLO SE QUITA LA LETRA, CUANDO EL CAMPO TIENE 9 CARACTERES, EN ESE MOMENTO, SEGURO QUE HAY UNA LETRA
            if (Dni.Length == 9)
            {
                //MODIFICO LA LONGITUD MAXIMA DEL CAMPO A 8 Y ELIMINO LA LETRA
                LongitudMaxima = 8;
                Dni = Dni[..8];
            }
        }

        /// <summary>
        /// MÉTODO PARA COMPROBAR SI EL BOTÓN DEBE ESTAR HABILITADO, SOLAMENTE LO ESTA, CUANDO HAYA 8 CARACTERES
        /// </summary>
        /// <param name="sender">PARAMETRO DEL EVENTO</param>
        /// <param name="e">PARAMETRO DEL EVENTO</param>
        public void CheckDni(object sender, EventArgs e)
        {
            EstadoBoton = TextBoxEntidad.Text.Length == 8;
        }
    }
}
