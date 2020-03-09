using OrdenesDeCompra.BLL;
using OrdenesDeCompra.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OrdenesDeCompra.UI.Consultas
{
    /// <summary>
    /// Lógica de interacción para FormularioConsultaProducto.xaml
    /// </summary>
    public partial class FormularioConsultaProducto : Window
    {
        public FormularioConsultaProducto()
        {
            InitializeComponent();
        }
        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Productos>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0:
                        listado = ProductoBLL.GetList(x => true);
                        break;
                    case 1:
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = ProductoBLL.GetList(x => x.ProductoId == id);
                        break;

                    case 2:
                        listado = ProductoBLL.GetList(x => x.Descripcion == CriterioTextBox.Text);
                        break;
                    case 3:
                        int cantidad = Convert.ToInt32(CriterioTextBox.Text);
                        listado = ProductoBLL.GetList(c => c.Cantidad == cantidad);
                        break;
                }
            }
            else
            {
                listado = ProductoBLL.GetList(p => true);
            }
            ConsultarDataGrid.ItemsSource = null;
            ConsultarDataGrid.ItemsSource = listado;
        }
    }
}
