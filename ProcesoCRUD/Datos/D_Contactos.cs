using Npgsql;
using ProcesoCRUD.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesoCRUD.Datos
{
    public class D_Contactos
    {
        public DataTable ListadoContactos(string cTexto)
        {
            NpgsqlDataReader Resultado;

            DataTable Tabla = new DataTable();
            NpgsqlConnection SqlCon = new NpgsqlConnection();

            try
            {
                SqlCon = Conexion.GetInstacia().CrearConexion();
                NpgsqlCommand Comando = new NpgsqlCommand("SELECT (func_listado_contacto('"+cTexto+"')).*;", SqlCon);
                Comando.CommandType = CommandType.Text;
                Comando.CommandTimeout = 60;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);

                return Tabla;
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        public string GuardarContacto(int nOpcion, Contactos contactos) {
            string Rpta = "";
            string SentenciaSQL = "INSERT INTO public.contactos(con_nombre, con_telefono, con_correo, con_fecha_nac, car_uuid)" +
                "VALUES ('"+contactos.Con_nombre+"', '"+contactos.Con_telefono+ "', '"+contactos.Con_correo+ "', " +
                "'"+contactos.Con_fecha_nac+ "', '"+contactos.Car_uuid+"');";

            NpgsqlConnection SqlCon = new NpgsqlConnection();

            try 
            {
                SqlCon = Conexion.GetInstacia().CrearConexion();
                NpgsqlCommand Comando = new NpgsqlCommand(SentenciaSQL, SqlCon);
                Comando.CommandType = CommandType.Text;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo registrar la información";
            } catch (Exception err)
            {
                Rpta = err.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return Rpta;
        }
    }
}
