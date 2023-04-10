using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
    /// Lógica de interacción para WindowAcercaDe.xaml
    /// </summary>
    public partial class WindowAcercaDe : Window
    {
        /// <summary>
        /// Constructor de la ventana
        /// </summary>
        public WindowAcercaDe()
        {
            InitializeComponent();
            //Muestro la ventana en el centro
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        /// <summary>
        /// Gestiona el cierre de la ventana y muestra la ventana principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            Owner.Show();
        }
    }

    
}
