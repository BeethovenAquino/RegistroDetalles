using RegistroDetalle.DAL;
using RegistroDetalle.Entidades;
using RegistroDetalle.BLL;
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
    public partial class RegisCotizaciones : Form
    {
        decimal importe = 0;
        public RegisCotizaciones()
        {
            InitializeComponent();
            LlenarComboBox();
            

        }
        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);
            return retorno;

        }


        private decimal ToDecimal(object valor)
        {
            decimal retorno = 0;
            decimal.TryParse(valor.ToString(), out retorno);
            return retorno;

        }

        private bool Validar()
        {
            bool paso = false;



            if (String.IsNullOrWhiteSpace(observacionesTextbox.Text))
            {
                ValidarerrorProvider.SetError(observacionesTextbox,
                   "No debes dejar la Observacion vacia");
                paso = true;
            }


            if (CantidadnumericUpDown.Value == 0)
            {
                ValidarerrorProvider.SetError(CantidadnumericUpDown,
                   "No debes dejar la Cantidad Vacia vacia");
                paso = true;
            }

            if (DetalleCotizacionesdataGridView.RowCount == 0)
            {
                ValidarerrorProvider.SetError(DetalleCotizacionesdataGridView,
                    "Es obligatorio Agregar un Articulo ");
                paso = true;
            }

            return paso;
        }

        private bool ValidarE()
        {
            bool paso = false;



            if (CotizacioIDnumericUpDown.Value == 0)
            {
                ValidarerrorProvider.SetError(CotizacioIDnumericUpDown,
                   "Llene el campo");
                paso = true;
            }


            return paso;
        }

       

        private Cotizaciones LlenaClase()
        {
            Cotizaciones cotizacionArticulos = new Cotizaciones();

            cotizacionArticulos.CotizacionId = Convert.ToInt32(CotizacioIDnumericUpDown.Value);
            cotizacionArticulos.Fecha = Fecha2dateTimePicker.Value;
            cotizacionArticulos.Observaciones = observacionesTextbox.Text;
            
            




            foreach (DataGridViewRow item in DetalleCotizacionesdataGridView.Rows)
            {

                cotizacionArticulos.AgregarDetalle
                    (ToInt(item.Cells["ID"].Value),
                    cotizacionArticulos.CotizacionId,
                      ToInt(item.Cells["PersonaId"].Value),
                      ToInt(item.Cells["ArticuloId"].Value),
                       ToInt(item.Cells["Cantidad"].Value),
                       Convert.ToString(item.Cells["Descripcion"].Value),
                    ToInt(item.Cells["Precio"].Value),
                    ToInt(item.Cells["Importe"].Value)
                  



                  );
            }
            return cotizacionArticulos;
        }

        private void LlenarComboBox()
        {
            Repositorio<Persona> repositorio = new Repositorio<Persona>(new Contexto());
            Repositorio<Articulos> repositori = new Repositorio<Articulos>(new Contexto());
            PersonacomboBox.DataSource = repositorio.GetList(c => true);
            PersonacomboBox.ValueMember = "PersonaId";
            PersonacomboBox.DisplayMember = "Nombres";

            ArticulocomboBox.DataSource = repositori.GetList(c => true);
            ArticulocomboBox.ValueMember = "ArticuloId";
            ArticulocomboBox.DisplayMember = "Descripcion";
        }

        private void LlenarCampos(Cotizaciones cotizacionArticulos)
        {
            importe = 0;
            CotizacioIDnumericUpDown.Value = cotizacionArticulos.CotizacionId;
            Fecha2dateTimePicker.Value = cotizacionArticulos.Fecha;
            observacionesTextbox.Text = cotizacionArticulos.Observaciones;
           

            foreach (var item in cotizacionArticulos.Detalle)
            {
                importe += item.Importe;
            }
            TotaltextBox.Text = importe.ToString();
           
            DetalleCotizacionesdataGridView.DataSource = cotizacionArticulos.Detalle;

            
            DetalleCotizacionesdataGridView.Columns["Id"].Visible = false;
            DetalleCotizacionesdataGridView.Columns["PersonaId"].Visible = false;
            DetalleCotizacionesdataGridView.Columns["CotizacionArticulosId"].Visible = false;
            DetalleCotizacionesdataGridView.Columns["articulos"].Visible = false;




        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(CotizacioIDnumericUpDown.Value);
            Cotizaciones cotizacionArticulos = BLL.ContizacionBLL.Buscar(id);

            if (cotizacionArticulos != null)
            {
                LlenarCampos(cotizacionArticulos);

            }
            else
                MessageBox.Show("No se encontro!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            List<DetalleCotizacion> detalle = new List<DetalleCotizacion>();
            Cotizaciones cotizacionArticulos = new Cotizaciones();

            if (DetalleCotizacionesdataGridView.DataSource != null)
            {
                cotizacionArticulos.Detalle = (List<DetalleCotizacion>)DetalleCotizacionesdataGridView.DataSource;
            }


            if (string.IsNullOrEmpty(ImporteTextbox.Text))
            {
                MessageBox.Show("Importe esta vacio , Llene cantidad ", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cotizacionArticulos.Detalle.Add( 
                    new DetalleCotizacion(
                        id: 0,
                       cotizacioId: (int)Convert.ToInt32(CotizacioIDnumericUpDown.Value),
                       personaId: (int)PersonacomboBox.SelectedValue,
                        articuloId: (int)ArticulocomboBox.SelectedValue,
                        cantidad: (int)Convert.ToInt32(CantidadnumericUpDown.Value),
                        descripcion: (string)BLL.ArticulosBLL.RetornarDescripcion(ArticulocomboBox.Text),
                        precio: (int)Convert.ToDecimal(PreciotextBox.Text),
                        importe: (int)Convert.ToDecimal(ImporteTextbox.Text)
                    
                    ));


                
                DetalleCotizacionesdataGridView.DataSource = null;
                DetalleCotizacionesdataGridView.DataSource = cotizacionArticulos.Detalle;


                importe += BLL.ContizacionBLL.CalcularImporte(Convert.ToDecimal(PreciotextBox.Text), Convert.ToInt32(CantidadnumericUpDown.Value));




                TotaltextBox.Text = importe.ToString();
            }
        }

        private void Guardar2button_Click(object sender, EventArgs e)
        {
            Cotizaciones cotizacionArticulos = LlenaClase();
            bool Paso = false;

            if (Validar())
            {
                MessageBox.Show("Favor revisar todos los campos", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CotizacioIDnumericUpDown.Value == 0)
            {
                Paso = BLL.ContizacionBLL.Guardar(cotizacionArticulos);
                ValidarerrorProvider.Clear();
            }
            else
            {

                Paso = BLL.ContizacionBLL.Modificar(cotizacionArticulos);
                ValidarerrorProvider.Clear();
            }

            if (Paso)
            {
                
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CotizacioIDnumericUpDown.Value = 0;
                Fecha2dateTimePicker.Value = DateTime.Now;
                observacionesTextbox.Clear();
                TotaltextBox.Clear();
                CantidadnumericUpDown.Value = 0;
                ImporteTextbox.Clear();
                DetalleCotizacionesdataGridView.DataSource = null;
                ValidarerrorProvider.Clear();
            }
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevo2button_Click(object sender, EventArgs e)
        {
            CotizacioIDnumericUpDown.Value = 0;
            Fecha2dateTimePicker.Value = DateTime.Now;
            observacionesTextbox.Clear();
            TotaltextBox.Clear();
            CantidadnumericUpDown.Value = 0;
            ImporteTextbox.Clear();
            DetalleCotizacionesdataGridView.DataSource = null;
            ValidarerrorProvider.Clear();

        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (ValidarE())
            {


                MessageBox.Show("Favor Llenar Casilla!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                int id = Convert.ToInt32(CotizacioIDnumericUpDown.Value);
                if (BLL.ContizacionBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CotizacioIDnumericUpDown.Value = 0;
                    Fecha2dateTimePicker.Value = DateTime.Now;
                    observacionesTextbox.Clear();
                    TotaltextBox.Clear();
                    CantidadnumericUpDown.Value = 0;
                    ImporteTextbox.Clear();
                    DetalleCotizacionesdataGridView.DataSource = null;
                    ValidarerrorProvider.Clear();
                }
                else
                    MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ArticulocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in BLL.ArticulosBLL.GetList(x => x.Nombre == ArticulocomboBox.Text))
            {
                PreciotextBox.Text = item.Precio.ToString();



            }
        }

        private void CantidadnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            decimal precio = Convert.ToDecimal(PreciotextBox.Text);
            int cantidad = Convert.ToInt32(CantidadnumericUpDown.Value);


            ImporteTextbox.Text = BLL.ContizacionBLL.CalcularImporte(precio, cantidad).ToString();

        }

        private void Removerbutton_Click(object sender, EventArgs e)
        {
            if (DetalleCotizacionesdataGridView.Rows.Count > 0
              && DetalleCotizacionesdataGridView.CurrentRow != null)
            {
              
                List<DetalleCotizacion> detalle = (List<DetalleCotizacion>)DetalleCotizacionesdataGridView.DataSource;
                detalle.RemoveAt(DetalleCotizacionesdataGridView.CurrentRow.Index);
                DetalleCotizacionesdataGridView.DataSource = null;
                DetalleCotizacionesdataGridView.DataSource = detalle;
            }
        }

        private void RegisCotizaciones_Load(object sender, EventArgs e)
        {
            PreciotextBox.Text = "0";
        }
    }
    }


