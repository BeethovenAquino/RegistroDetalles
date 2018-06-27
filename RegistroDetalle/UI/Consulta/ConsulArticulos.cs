using RegistroDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace RegistroDetalle.UI.Consulta
{
    public partial class ConsulArticulos : Form
    {
        public ConsulArticulos()
        {
            InitializeComponent();
        }

        private void Buscar1button_Click(object sender, EventArgs e)
        {
            Expression<Func<Articulos, bool>> filtro = x => true;

            int id, precio;
            switch (FiltrarcomboBox.SelectedIndex)
            {
                case 0://ID
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.ArticuloID == id
                    && (x.FehaVencimiento >= DesdedateTimePicker.Value && x.FehaVencimiento <= HastadateTimePicker.Value);
                    break;
                case 1:// Descripcion
                    filtro = x => x.Descripcion.Contains(CriteriotextBox.Text)
                    && (x.FehaVencimiento >= DesdedateTimePicker.Value && x.FehaVencimiento <= HastadateTimePicker.Value);
                    break;
                case 2://Fecha
                    filtro = x => x.FehaVencimiento.Equals(CriteriotextBox.Text)
                   && (x.FehaVencimiento >= DesdedateTimePicker.Value && x.FehaVencimiento <= HastadateTimePicker.Value);
                    break;

                case 3:// Precio
                    precio = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.Precio == precio
                    && (x.FehaVencimiento >= DesdedateTimePicker.Value && x.FehaVencimiento <= HastadateTimePicker.Value);
                    break;
                case 4:// Cantidad cotizada
                    filtro = x => x.CantidadCotizada.Equals(CriteriotextBox.Text)
                    && (x.FehaVencimiento >= DesdedateTimePicker.Value && x.FehaVencimiento <= HastadateTimePicker.Value);
                    break;
                case 5://Todo
                    ConsulArticulosdataGridView.DataSource = BLL.ArticulosBLL.GetList(filtro);
                    break;

            }
           ConsulArticulosdataGridView.DataSource = BLL.ArticulosBLL.GetList(filtro);
        }

        private void FiltrarcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FiltrarcomboBox.SelectedIndex == 5)
            {
                CriteriotextBox.Enabled = false;
            }
            else
                CriteriotextBox.Enabled = true;
        }
    }
    }

