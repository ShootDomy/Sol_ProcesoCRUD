using Npgsql.Internal.TypeHandlers;
using ProcesoCRUD.Datos;
using ProcesoCRUD.Entidades;
using ProcesoCRUD.Presentacion.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcesoCRUD.Presentacion
{
    public partial class FrmContactos : Form
    {
        public FrmContactos()
        {
            InitializeComponent();
            this.EstadoTexto(false);
            this.EstadoBotonesProceso(false);
            this.EstadoBotonesPrincipales(true);
        }

        #region "Mis Variables"
        Guid vCon_codigo = Guid.NewGuid();
        Guid vCar_codigo = Guid.NewGuid();
        int nEstadoGuardar = 0;
        #endregion

        #region "Mis Metodos"
        private void LimpiarTextos()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
        }

        private void EstadoTexto(bool lEstado) {
            txtNombre.Enabled = lEstado;
            txtTelefono.Enabled = lEstado;
            txtCorreo.Enabled = lEstado;
            dtpFechaNac.Enabled = lEstado;
            cbxCargo.Enabled = lEstado;
        }

        private void EstadoBotonesProceso(bool lEstado)
        {
            btnGuardar.Visible = lEstado;
            btnCancelar.Visible = lEstado;
        }

        private void EstadoBotonesPrincipales(bool lEstado)
        {
            btnNuevo.Enabled = lEstado;
            btnActualizar.Enabled = lEstado;
            btnEliminar.Enabled = lEstado;
            btnReporte.Enabled = lEstado;
            //btnSalir.Enabled = lEstado;
        }

        private void ListadoCargos()
        {
            try { 
                D_cargos objCargos = new D_cargos();
                cbxCargo.DataSource = objCargos.ListadoCargos();
                cbxCargo.ValueMember = "car_uuid";
                cbxCargo.DisplayMember = "car_descripcion";

            } catch (Exception err)
            {
                MessageBox.Show("Error al cargar los cargos: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatoContactos()
        {
            try
            {
                dgvListado.Columns[0].Visible = false; // Ocultar columna de codigo

                dgvListado.Columns[1].Width = 130; // Ajustar ancho de columna Nombre
                dgvListado.Columns[1].HeaderText = "Nombre";

                dgvListado.Columns[2].Width = 100;
                dgvListado.Columns[2].HeaderText = "Telefono";

                dgvListado.Columns[3].Width = 150;
                dgvListado.Columns[3].HeaderText = "Correo";

                dgvListado.Columns[4].Width = 130;
                dgvListado.Columns[4].HeaderText = "Fecha Nacimiento";

                dgvListado.Columns[5].Width = 150;
                dgvListado.Columns[5].HeaderText = "Cargo";
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al formatear el listado de contactos: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListadoContactos(string cTexto)
        {
            try
            {
                D_Contactos objContactos = new D_Contactos();
                dgvListado.DataSource = objContactos.ListadoContactos(cTexto);
                this.FormatoContactos();    
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al cargar los contactos: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarContacto()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgvListado.CurrentRow.Cells["codigo"].Value))) {
                MessageBox.Show("Seleccione un registro valido", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtNombre.Text = Convert.ToString(dgvListado.CurrentRow.Cells["nombre"].Value);
                txtTelefono.Text = Convert.ToString(dgvListado.CurrentRow.Cells["telefono"].Value);
                txtCorreo.Text = Convert.ToString(dgvListado.CurrentRow.Cells["correo"].Value);
                dtpFechaNac.Value = Convert.ToDateTime(dgvListado.CurrentRow.Cells["fecha_nac"].Value);
                vCon_codigo = Guid.Parse(Convert.ToString(dgvListado.CurrentRow.Cells["codigo"].Value));
                cbxCargo.Text = Convert.ToString(dgvListado.CurrentRow.Cells["cargo"].Value);
            }
        }
        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nEstadoGuardar = 1; // Nuevo registro
            this.LimpiarTextos();
            this.EstadoTexto(true);
            this.EstadoBotonesProceso(true);
            this.EstadoBotonesPrincipales(false);
            txtNombre.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            nEstadoGuardar = 0; // Ninguna accion
            this.EstadoTexto(false);
            this.EstadoBotonesProceso(false);
            this.EstadoBotonesPrincipales(true);
        }

        private void FrmContactos_Load(object sender, EventArgs e)
        {
            this.ListadoCargos();
            this.ListadoContactos("%");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // VALIDACION DE CAMPOS OBLIGATORIOS
            if (txtNombre.Text ==string.Empty || cbxCargo.Text==string.Empty) 
            {
                MessageBox.Show("Faltan campos requeridos: ", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            else { 
                string Rpta = "";
                vCar_codigo = cbxCargo.SelectedValue != null ? Guid.Parse(cbxCargo.SelectedValue.ToString()) : Guid.Empty;
                Contactos objContactos = new Contactos();
                //objContactos.Con_uuid = vCon_codigo;
                objContactos.Con_nombre = txtNombre.Text.Trim();
                objContactos.Con_telefono = txtTelefono.Text.Trim();
                objContactos.Con_correo = txtCorreo.Text.Trim();
                objContactos.Con_fecha_nac = dtpFechaNac.Value.ToString("yyyy-MM-dd");
                objContactos.Car_uuid = vCar_codigo;

                D_Contactos contactos = new D_Contactos();

                if (nEstadoGuardar == 1) {
                    Rpta = contactos.GuardarContacto(nEstadoGuardar, objContactos);
                }
                else if (nEstadoGuardar == 2)
                {
                    objContactos.Con_uuid = vCon_codigo;
                    Rpta = contactos.ActualizarContacto(nEstadoGuardar, objContactos);
                }
                    

                if (Rpta == "OK") {
                    this.LimpiarTextos();
                    this.EstadoTexto(false);
                    this.EstadoBotonesProceso(false);
                    this.EstadoBotonesPrincipales(true);
                    this.ListadoContactos("%");

                    if (nEstadoGuardar == 1)
                    {
                        MessageBox.Show("Los datos han sido creados correctamente: ", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (nEstadoGuardar == 2)
                    {
                        MessageBox.Show("Los datos han sido actualizados correctamente: ", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                } else {
                    MessageBox.Show(Rpta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvListado_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.SeleccionarContacto();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            nEstadoGuardar = 2; // Atualizar registro
            //this.LimpiarTextos();
            this.EstadoTexto(true);
            this.EstadoBotonesProceso(true);
            this.EstadoBotonesPrincipales(false);
            txtNombre.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.ListadoContactos(txtEditar.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count > 0) {
                string Rpta = "";
                D_Contactos contacto = new D_Contactos();
                vCon_codigo = Guid.Parse(Convert.ToString(dgvListado.CurrentRow.Cells["codigo"].Value));
                Rpta = contacto.EliminarContacto(vCon_codigo);

                if (Rpta == "OK")
                {
                    this.LimpiarTextos();
                    this.EstadoTexto(false);
                    this.EstadoBotonesProceso(false);
                    this.EstadoBotonesPrincipales(true);
                    this.ListadoContactos("%");

                    MessageBox.Show("Los datos han sido  correctamente: ", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(Rpta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Frm_Reporte_Contactos frm_Reporte_Contactos = new Frm_Reporte_Contactos();
            frm_Reporte_Contactos.txt01.Text = txtEditar.Text.Trim();
            frm_Reporte_Contactos.ShowDialog();
        }
    }
}
