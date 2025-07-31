using Microsoft.Reporting.WinForms;
using ProcesoCRUD.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcesoCRUD.Presentacion.Reportes
{
    public partial class Frm_Reporte_Contactos : Form
    {
        public Frm_Reporte_Contactos()
        {
            InitializeComponent();
        }

        #region "Mis Metodos"
        private void ListadoReporte()
        {
            try
            {
                D_Contactos contactos = new D_Contactos();
                string cTexto = txt01.Text.Trim();
                DataTable dt = new DataTable();
                dt = contactos.ListadoContactos(cTexto);
                ReportDataSource fuente = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(fuente);
                reportViewer1.LocalReport.ReportEmbeddedResource = "ProcesoCRUD.Presentacion.Reportes.Rpt_Contactos.rdlc";
                reportViewer1.LocalReport.Refresh();
                reportViewer1.Refresh();
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ""
        #endregion

        private void Frm_Reporte_Contactos_Load(object sender, EventArgs e)
        {
            this.ListadoReporte();
            //this.reportViewer1.RefreshReport();
        }
    }
}
