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
using OrdenesDeCompra.Entidades;
using OrdenesDeCompra.BLL;

namespace OrdenesDeCompra.UI.Consultas
{
    /// <summary>
    /// Lógica de interacción para FormularioConsultaOrden.xaml
    /// </summary>
    public partial class FormularioConsultaOrden : Window
    {
        public FormularioConsultaOrden()
        {
            InitializeComponent();
        }
        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Ordenes>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0:
                        listado = OrdenesBLL.GetList(o => true);
                        break;
                    case 1:
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = OrdenesBLL.GetList(o => o.OrdenId == id);
                        break;

                    case 2:
                        int clienteid;
                        clienteid = int.Parse(CriterioTextBox.Text);
                        listado = OrdenesBLL.GetList(o => o.ClienteID == clienteid);
                        break;
                }
            }
            else
            {
                listado = OrdenesBLL.GetList(p => true);
            }
            ConsultarDataGrid.ItemsSource = null;
            ConsultarDataGrid.ItemsSource = listado;
        }
    }
}
