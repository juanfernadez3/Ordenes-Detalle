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
    /// Lógica de interacción para FormularioProductos.xaml
    /// </summary>
    public partial class FormularioProductos : Window
    {
        Productos producto = new Productos();
        public FormularioProductos()
        {
            InitializeComponent();
            this.DataContext = producto;
            ProductoIdTextBox.Text = "0";
        }
        private void Limpiar()
        {
            ProductoIdTextBox.Text = "0";
            DescripcionTextBox.Text = string.Empty;
            PrecioTextBox.Text = "0";
            CantidadTextBox.Text = "0";
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = producto;
        }
        

        private bool ExisteEnDb()
        {
            Productos producto = ProductoBLL.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));

            return (producto != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(DescripcionTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo descripcion no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                DescripcionTextBox.Focus();


            }

            if (string.IsNullOrEmpty(PrecioTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo precio no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                PrecioTextBox.Focus();
            }
            if (string.IsNullOrEmpty(CantidadTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo inventario no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                CantidadTextBox.Focus();
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

            if (String.IsNullOrEmpty(ProductoIdTextBox.Text) || ProductoIdTextBox.Text == "0")
                paso = ProductoBLL.Guardar(producto);

            else
            {
                if (!ExisteEnDb())
                {
                    MessageBox.Show("Persona no Valida", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                paso = ProductoBLL.Modificar(producto);
            }

            if (paso)
            {
                MessageBox.Show("Accion Realizada ", "Guardado", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show(" No guardado", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            }
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Productos anterior = ProductoBLL.Buscar(int.Parse(ProductoIdTextBox.Text));

            if (producto != null)
            {
                producto = anterior;
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
            int.TryParse(ProductoIdTextBox.Text, out id);



            if (ProductoBLL.Eliminar(id))
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
