using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesoCRUD.Datos
{
    public class Conexion
    {
        private string BaseDatos;
        private string Servidor;
        private string Puerto;
        private string Usuario;
        private string Contrasena;
        private static Conexion Con = null;

        public Conexion()
        {
            this.BaseDatos = "c_crud";
            this.Servidor = "localhost";
            this.Puerto = "5432";
            this.Usuario = "postgres";
            this.Contrasena = "admin";

        }

        public NpgsqlConnection CrearConexion()
        {
            NpgsqlConnection Cadena = new NpgsqlConnection();
            try { 
                Cadena.ConnectionString = 
                    "Server=" + this.Servidor + 
                    ";Port=" + this.Puerto + 
                    ";User Id=" + this.Usuario + 
                    ";Password=" + this.Contrasena + 
                    ";Database=" + this.BaseDatos + ";";

            } catch(Exception err) {
                Cadena = null;
                throw err;
            }

            return Cadena;
        }

        public static Conexion GetInstacia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }
    }
}
