using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesoCRUD.Datos
{
    public class D_cargos
    {
        public DataTable ListadoCargos()
        {
            NpgsqlDataReader Resultado;

            DataTable Tabla = new DataTable();
            NpgsqlConnection SqlCon = new NpgsqlConnection();

            try
            {
                SqlCon = Conexion.GetInstacia().CrearConexion();
                NpgsqlCommand Comando = new NpgsqlCommand("SELECT car_uuid, car_descripcion FROM cargos WHERE car_activo IS TRUE;", SqlCon);
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
    }
}
