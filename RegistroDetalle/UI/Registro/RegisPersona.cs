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
    public partial class RegisPersona : Form
    {
        public RegisPersona()
        {
            InitializeComponent();
        }

        private Persona LlenaClase()
        {

            Persona personas = new Persona();

           personas.PersonaID = Convert.ToInt32(IDnumericUpDown.Value);
           personas.Nombre = NombretextBox.Text;
            personas.Fecha = FechadateTimePicker.Value;
            personas.Direccion = DirecciontextBox.Text;
            personas.Telefono = TelefonotextBox.Text;
            personas.Cedula = CedulatextBox.Text;

            return personas;
        }

        private bool Validar(int validar)
        {

            bool paso = false;
            if (validar == 1 && IDnumericUpDown.Value == 0)
            {
                errorProvider.SetError(IDnumericUpDown, "Ingrese un ID");
                paso = true;

            }
            if (validar == 2 && NombretextBox.Text == string.Empty)
            {
                errorProvider.SetError(NombretextBox, "Ingrese un Nombre");
                paso = true;
            }

            if (validar == 2 && DirecciontextBox.Text == string.Empty)
            {
                errorProvider.SetError(DirecciontextBox, "Ingrese una Direccion");
                paso = true;
            }

            if (validar == 2 && TelefonotextBox.Text == string.Empty)
            {

                errorProvider.SetError(TelefonotextBox, "Ingrese un Telefono");

            }

            if (validar == 2 && CedulatextBox.Text == string.Empty)
            {

                errorProvider.SetError(CedulatextBox, "Ingrese una Cedula");

            }
            return paso;

        }


        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IDnumericUpDown.Value = 0;
            NombretextBox.Clear();
            DirecciontextBox.Clear();
            TelefonotextBox.Clear();
            CedulatextBox.Clear();
            errorProvider.Clear();

        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            if (Validar(2))
            {

                MessageBox.Show("Llenar todos los campos ");
                return;
            }

            errorProvider.Clear();


            if (IDnumericUpDown.Value == 0)
                paso = BLL.PersonaBLL.Guardar(LlenaClase());
            else
                paso = BLL.PersonaBLL.Modificar(LlenaClase());


            if (paso)
            {

                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IDnumericUpDown.Value = 0;
                NombretextBox.Clear();
                DirecciontextBox.Clear();
                TelefonotextBox.Clear();
                CedulatextBox.Clear();
                errorProvider.Clear();
            }
            else
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (BLL.PersonaBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IDnumericUpDown.Value = 0;
                NombretextBox.Clear();
                DirecciontextBox.Clear();
                TelefonotextBox.Clear();
                CedulatextBox.Clear();
                errorProvider.Clear();
            }

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
            Persona personas = BLL.PersonaBLL.Buscar(id);

            if (personas != null)
            {

                NombretextBox.Text = personas.Nombre;
                DirecciontextBox.Text = personas.Direccion;
                FechadateTimePicker.Text = personas.Fecha.ToString();
                TelefonotextBox.Text = personas.Telefono;
                CedulatextBox.Text = personas.Cedula;


            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    }

