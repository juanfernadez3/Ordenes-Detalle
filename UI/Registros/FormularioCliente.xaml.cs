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

namespace OrdenesDeCompra.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para FormularioCliente.xaml
    /// </summary>
    public partial class FormularioCliente : Window
    {
        Clientes cliente = new Clientes();
        public FormularioCliente()
        {
            InitializeComponent();
            this.DataContext = cliente;
            PersonaIdTextBox.Text = "0";
        }

        private void Limpiar()
        {
            PersonaIdTextBox.Text = "0";
            NombreTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = cliente;
        }

        private bool ExisteEnDb()
        {
            Clientes clientes = ClientesBLL.Buscar(Convert.ToInt32(PersonaIdTextBox.Text));

            return (clientes != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(NombreTextBox.Text))
            {
                paso = false;
                MessageBox.Show("Debe Ingresar Nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

            }

            if (string.IsNullOrEmpty(CedulaTextBox.Text.Replace("-", "")))
            {
                paso = false;
                MessageBox.Show("Debe Ingresar Cedula", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (string.IsNullOrEmpty(TelefonoTextBox.Text.Replace("-", "")))
            {
                paso = false;
                MessageBox.Show("Debe Ingresar Cedula", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (string.IsNullOrEmpty(DireccionTextBox.Text.Replace("-", "")))
            {
                paso = false;
                MessageBox.Show("Debe Ingresar Cedula", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            return paso;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
                return;

            if (String.IsNullOrEmpty(PersonaIdTextBox.Text) || PersonaIdTextBox.Text == "0")
                paso = ClientesBLL.Guardar(cliente);
            else
            {
                if (!ExisteEnDb())
                {
                    MessageBox.Show("Persona no valida", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                paso = ClientesBLL.Modificar(cliente);
            }

            if (paso)
            {
                MessageBox.Show("Accion realizada con Exito", "Guardado", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show(" No guardado", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            }
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Clientes anterior = ClientesBLL.Buscar(int.Parse(PersonaIdTextBox.Text));

            if (cliente != null)
            {
                cliente = anterior;
                Actualizar();
            }
            else
            {
                MessageBox.Show(" Persona No Encontrada", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(PersonaIdTextBox.Text, out id);

            if (ClientesBLL.Eliminar(id))
            {
                MessageBox.Show("Accion Realizada ", "ELiminado", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show(" No eliminado", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
