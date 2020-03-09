using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using OrdenesDeCompra.BLL;
using OrdenesDeCompra.UI.Consultas;
using OrdenesDeCompra.UI.Registros;

namespace OrdenesDeCompra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void RegistroCliente_Click(object sender, RoutedEventArgs e)
        {
            FormularioCliente fc = new FormularioCliente();
            fc.Show();
        }

        private void RegistroEmpleados_Click(object sender, RoutedEventArgs e)
        {

            FormularioProductos fp = new FormularioProductos();
            fp.Show();
        }

        private void RegistroOrdenes_Click(object sender, RoutedEventArgs e)
        {

            FormularioOrdenes fo = new FormularioOrdenes();
            fo.Show();
        }

        private void ConsultarClientes_Click(object sender, RoutedEventArgs e)
        {

            FormularioConsultaCliente fc = new FormularioConsultaCliente();
            fc.Show();
        }

        private void ConsultarOrdenes_Click(object sender, RoutedEventArgs e)
        {

            FormularioConsultaOrden fo = new FormularioConsultaOrden();
            fo.Show();
        }

        private void ConsultarProductos_Click(object sender, RoutedEventArgs e)
        {

            FormularioConsultaProducto fp = new FormularioConsultaProducto();
            fp.Show();
        }

        

        
    }
}
