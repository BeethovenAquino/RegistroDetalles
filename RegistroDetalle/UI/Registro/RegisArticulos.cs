using RegistroDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroDetalle.UI.Registro
{
    public partial class RegisArticulos : Form
    {
        public RegisArticulos()
        {
            InitializeComponent();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            if (Validar(2))
            {

                MessageBox.Show("Llenar todos los campos marcados");
                return;
            }

            errorProvider.Clear();

           
            if (IDnumericUpDown.Value == 0)
                paso = BLL.ArticulosBLL.Guardar(LlenarClase());
            else
                paso = BLL.ArticulosBLL.Modificar(LlenarClase());

          
            if (paso)

                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private Articulos LlenarClase()
        {

            Articulos articulo= new Articulos();

            articulo.ArticuloID = Convert.ToInt32(IDnumericUpDown.Value);
            articulo.Descripcion = DescripciontextBox.Text;
            articulo.Precio = Convert.ToInt32(PrecionumericUpDown.Value);
            articulo.FehaVencimiento = VencimientodateTimePicker.Value;
            articulo.CantidadCotizada = Convert.ToInt32(CantidadCotizadatextBox.Text);

            return articulo;
        }
        private bool Validar(int validar)
        {

            bool paso = false;
            if (validar == 1 && IDnumericUpDown.Value == 0)
            {
                errorProvider.SetError(IDnumericUpDown, "Ingrese un ID");
                paso = true;

            }
            if (validar == 2 && DescripciontextBox.Text == string.Empty)
            {
                errorProvider.SetError(DescripciontextBox, "Ingrese una descripcion");
                paso = true;
            }
            if (validar == 2 && PrecionumericUpDown.Value == 0)
            {

                errorProvider.SetError(PrecionumericUpDown, "Ingrese un precio");
                paso = true;
            }
            if (validar == 2 && CantidadCotizadatextBox.Text == string.Empty)
            {

                errorProvider.SetError(CantidadCotizadatextBox, "Ingrese la cantidad cotizada");

            }
            return paso;

        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IDnumericUpDown.Value = 0;
            DescripciontextBox.Clear();
            PrecionumericUpDown.Value = 0;
            CantidadCotizadatextBox.Clear();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(IDnumericUpDown.Value);

            if (BLL.ArticulosBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(IDnumericUpDown.Value);
            Articulos articulo = BLL.ArticulosBLL.Buscar(id);

            if (articulo != null)
            {

                DescripciontextBox.Text = articulo.Descripcion;
                PrecionumericUpDown.Value = articulo.Precio;
                VencimientodateTimePicker.Text = articulo.FehaVencimiento.ToString();
                CantidadCotizadatextBox.Text = articulo.CantidadCotizada.ToString();

            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    }




 
