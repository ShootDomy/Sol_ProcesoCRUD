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

      
    }
}
