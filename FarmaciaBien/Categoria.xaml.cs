using FarmaciaBien.Clases;
using FarmaciaBien.LecturaArchivo;
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
using System.Windows.Shapes;

namespace FarmaciaBien
{
    /// <summary>
    /// Lógica de interacción para Categoria.xaml
    /// </summary>
    public partial class Categoria : Window
    {
        HerramientaCategoria herramientaCategoria;
        bool N;
        public Categoria()
        {
            InitializeComponent();
            herramientaCategoria = new HerramientaCategoria();
            ActualizarTabla();
            habilitado(false);
            HabilitarBotones(true);
        }

        private void ActualizarTabla()
        {
            dtgCategoria.ItemsSource = null;
            dtgCategoria.ItemsSource = herramientaCategoria.Leer();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea cancelar la operación?", "Categoria", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                habilitado(false);
                HabilitarBotones(true);
            }
        }

        private void habilitado(bool habilitado)
        {
            txbNombre.Clear();
            txbNombre.IsEnabled = habilitado;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (herramientaCategoria.Leer().Count == 0)
            {
                MessageBox.Show("No cuenta con ninguna categoria", "Categoria", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgCategoria.SelectedItem != null)
                {
                    CategoriaFarmacia a = dtgCategoria.SelectedItem as CategoriaFarmacia;
                    if (MessageBox.Show("Esta seguro de dar de baja a " + a.Descripcion, "Categoria", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (herramientaCategoria.Eliminar(a))
                        {
                            MessageBox.Show("Categoria dada de Baja", "Categoria", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido eliminar la categoria", "Categoria", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar a un empleado de la tabla", "Categoria", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }

        private void HabilitarBotones(bool v)
        {
            btnCancelar.IsEnabled = !v;
            btnEditar.IsEnabled = v;
            btnGuardar.IsEnabled = !v;
            btnNuevo.IsEnabled = v;
            btnEliminar.IsEnabled = v;
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (herramientaCategoria.Leer().Count == 0)
            {
                MessageBox.Show("No cuenta alguna Categoria", "Categoria", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgCategoria.SelectedItem != null)
                {
                    CategoriaFarmacia a = dtgCategoria.SelectedItem as CategoriaFarmacia;
                    habilitado(true);
                    txbNombre.Text = a.Descripcion;
                    HabilitarBotones(false);
                    N = false;
                }
                else
                {
                    MessageBox.Show("Debe seleccionar en la tabla a quien desea editar", "Categoria", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            habilitado(true);
            HabilitarBotones(false);
            N = true;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbNombre.Text))
            {
                MessageBox.Show("Falta la categoria", "Categoria", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (N)
            {
                CategoriaFarmacia a = new CategoriaFarmacia();
                    a.Descripcion = txbNombre.Text;
                if (herramientaCategoria.Agregar(a))
                {
                    MessageBox.Show("Dato guardado sadisfactoriamnete", "Categoria", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarBotones(true);
                    habilitado(false);
                }
                else
                {
                    MessageBox.Show("No se guardo correctamente la categoria", "Categoria", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                CategoriaFarmacia original = dtgCategoria.SelectedItem as CategoriaFarmacia;
                CategoriaFarmacia a = new CategoriaFarmacia();
                a.Descripcion = txbNombre.Text;
                if (herramientaCategoria.Modificar(original, a))
                {
                    HabilitarBotones(true);
                    habilitado(false);
                    ActualizarTabla();
                    MessageBox.Show("Categoria editada correctamente", "Categoria", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("No se edito correctamnete la Categoria", "Categoria", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

      
    }
}
