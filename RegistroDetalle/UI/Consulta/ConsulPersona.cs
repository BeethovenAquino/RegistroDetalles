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
    public partial class ConsulPersona : Form
    {
        public ConsulPersona()
        {
            InitializeComponent();
        }

        private void Buscar1button_Click(object sender, EventArgs e)
        {
            //Inicializando el filtro en True
            Expression<Func<Persona, bool>> filtro = x => true;

            int id;
            switch (FiltrarcomboBox.SelectedIndex)
            {
                case 0://ID
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.PersonaID == id
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
                case 1:// nombre
                    filtro = x => x.Nombre.Contains(CriteriotextBox.Text)
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
                case 2://Fecha
                    filtro = x => x.Fecha.Equals(CriteriotextBox.Text)
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;

                case 3:// cedula
                    filtro = x => x.Cedula.Equals(CriteriotextBox.Text)
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
                case 4:// direccion
                    filtro = x => x.Direccion.Contains(CriteriotextBox.Text)
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
                case 5://telefono
                    filtro = x => x.Telefono.Equals(CriteriotextBox.Text)
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
                case 6://Todo
                    ConsulPersonasdataGridView.DataSource = BLL.PersonaBLL.GetList(filtro);
                    break;

            }
            ConsulPersonasdataGridView.DataSource = BLL.PersonaBLL.GetList(filtro);
        }

        private void FiltrarcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FiltrarcomboBox.SelectedIndex == 6)
            {
                CriteriotextBox.Enabled = false;
            }
            else
                CriteriotextBox.Enabled = true;
        }
    }
}
    