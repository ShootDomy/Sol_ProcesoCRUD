namespace ProcesoCRUD.Presentacion.Reportes
{
    partial class Frm_Reporte_Contactos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dS_Reportes = new ProcesoCRUD.Presentacion.Reportes.DS_Reportes();
            this.listadoDeContactoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txt01 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dS_Reportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listadoDeContactoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.listadoDeContactoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ProcesoCRUD.Presentacion.Reportes.Rpt_Contactos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1281, 646);
            this.reportViewer1.TabIndex = 0;
            // 
            // dS_Reportes
            // 
            this.dS_Reportes.DataSetName = "DS_Reportes";
            this.dS_Reportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listadoDeContactoBindingSource
            // 
            this.listadoDeContactoBindingSource.DataMember = "Listado de contacto";
            this.listadoDeContactoBindingSource.DataSource = this.dS_Reportes;
            // 
            // txt01
            // 
            this.txt01.Location = new System.Drawing.Point(12, 40);
            this.txt01.Name = "txt01";
            this.txt01.Size = new System.Drawing.Size(100, 20);
            this.txt01.TabIndex = 1;
            this.txt01.Visible = false;
            // 
            // Frm_Reporte_Contactos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 646);
            this.Controls.Add(this.txt01);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_Reporte_Contactos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Reporte_Contactos";
            this.Load += new System.EventHandler(this.Frm_Reporte_Contactos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dS_Reportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listadoDeContactoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource listadoDeContactoBindingSource;
        private DS_Reportes dS_Reportes;
        internal System.Windows.Forms.TextBox txt01;
    }
}