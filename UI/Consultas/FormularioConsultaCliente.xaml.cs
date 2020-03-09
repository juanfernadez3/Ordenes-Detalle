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
    /// Lógica de interacción para FormularioConsultaCliente.xaml
    /// </summary>
    public partial class FormularioConsultaCliente : Window
    {
        public FormularioConsultaCliente()
        {
            InitializeComponent();
        }
        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Clientes>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0:
                        listado = ClientesBLL.GetList(c => true);
                        break;
                    case 1:
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = ClientesBLL.GetList(c => c.CLienteId == id);
                        break;

                    case 2:
                        listado = ClientesBLL.GetList(x => x.Nombre == CriterioTextBox.Text);
                        break;
                    case 3:
                        listado = ClientesBLL.GetList(x => x.Cedula == CriterioTextBox.Text);
                        break;
                }
            }
            else
            {
                listado = ClientesBLL.GetList(p => true);
            }
            ConsultarDataGrid.ItemsSource = null;
            ConsultarDataGrid.ItemsSource = listado;
        }
    }
}
