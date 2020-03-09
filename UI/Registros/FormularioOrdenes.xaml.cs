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
    /// Lógica de interacción para FormularioOrdenes.xaml
    /// </summary>
    public partial class FormularioOrdenes : Window
    {
        public List<OrdenDetalle> Detalle { get; set; }
        public FormularioOrdenes()
        {
            InitializeComponent();
            this.Detalle = new List<OrdenDetalle>();
            CargarGrid();

        }
        private void CargarGrid()
        {
            DetalleOrdenDataGrid.ItemsSource = null;
            DetalleOrdenDataGrid.ItemsSource = this.Detalle;
        }
        private void Limpiar()
        {
            OrdenIDTextBox.Text = "0";
            ClienteIdTextBox.Text = "0";
            AlmacenIdTextBox.Text = "0";
            FechaOrdenDateTimePicker.Text = "Fecha de orden";
            TotalTextBox.Text = "0";

            this.Detalle = new List<OrdenDetalle>();
            CargarGrid();

        }

        private Ordenes LlenaClase()
        {
            Ordenes orden = new Ordenes();
            orden.OrdenId = int.Parse(OrdenIDTextBox.Text);
            orden.ClienteID = int.Parse(ClienteIdTextBox.Text);
            orden.FechaOrden = (DateTime)FechaOrdenDateTimePicker.SelectedDate;
            orden.Total = decimal.Parse(TotalTextBox.Text);

            orden.Detalles = this.Detalle;

            return orden;
        }

        private void LlenaCampo(Ordenes orden)
        {
            OrdenIDTextBox.Text = Convert.ToString(orden.OrdenId);
            FechaOrdenDateTimePicker.SelectedDate = orden.FechaOrden;
            TotalTextBox.Text = Convert.ToString(orden.Total);

            this.Detalle = orden.Detalles;
            CargarGrid();
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(FechaOrdenDateTimePicker.Text))
            {
                MessageBox.Show("Debe Ingresar una Fecha", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                FechaOrdenDateTimePicker.Focus();
                paso = false;
            }
            if (string.IsNullOrEmpty(TotalTextBox.Text))
            {
                MessageBox.Show("Debe Ingresae un Total", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                TotalTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrEmpty(AlmacenIdTextBox.Text))
            {
                MessageBox.Show("Debe Ingresar un Almacen", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                AlmacenIdTextBox.Focus();
                paso = false;
            }
            if (this.Detalle.Count == 0)
            {
                MessageBox.Show("Debe Ingresar un telefono", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                ProductoIdTextBox.Focus();
                CantidadTextBox.Focus();
                paso = false;
            }
            return paso;
        }
        

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {

            if (DetalleOrdenDataGrid.ItemsSource != null)
            {
                this.Detalle = (List<OrdenDetalle>)DetalleOrdenDataGrid.ItemsSource;
            }

            
            this.Detalle.Add(new OrdenDetalle
            {
                OrdenId = Convert.ToInt32(OrdenIDTextBox.Text),
                ProductoId = Convert.ToInt32(ProductoIdTextBox.Text),
                Cantidad = Convert.ToInt32(CantidadTextBox.Text)

            });
            CargarGrid();
            int valor = Convert.ToInt32(CantidadTextBox.Text);
            int id = Convert.ToInt32(ProductoIdTextBox.Text);
            ProductoIdTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            Ordenes orden;

            if (!Validar())
                return;

            orden = LlenaClase();

            if (string.IsNullOrEmpty(OrdenIDTextBox.Text) || OrdenIDTextBox.Text == "0")
                paso = OrdenesBLL.Guardar(orden);
            else
            {
                if (!ExisteEnDb())
                {
                    MessageBox.Show("Persona No Encontrada", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                paso = OrdenesBLL.Modificar(orden);
            }

            if (paso)
            {
                MessageBox.Show("Guardado!!", "EXITO", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show(" No guardado!!", "Informacion", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(OrdenIDTextBox.Text, out id);



            if (OrdenesBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado con exito!!!", "ELiminado", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show(" No eliminado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Ordenes orden = new Ordenes();
            int.TryParse(OrdenIDTextBox.Text, out id);

            orden = OrdenesBLL.Buscar(id);

            if (orden != null)
            {
                LlenaCampo(orden);
            }
            else
            {
                MessageBox.Show(" No encontrado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void RemoverDetalleButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleOrdenDataGrid.Items.Count > 0 && DetalleOrdenDataGrid.SelectedItem != null)
            {
                Detalle.RemoveAt(DetalleOrdenDataGrid.SelectedIndex);
                CargarGrid();
            }
        }

        private bool ExisteEnDb()
        {
            Ordenes orden = OrdenesBLL.Buscar(Convert.ToInt32(OrdenIDTextBox.Text));

            return (orden != null);
        }

    }
}
