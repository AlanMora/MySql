using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;// conector de MySQL

using System.Data;

using System.Drawing;

using System.IO;// para poder emplear el DataTable

namespace MySql
{
    class Conexion
    {
        public DataTable dt = new DataTable();

        //cadena de conexion

        public String strConexion = "server = localhost; user id = root; password = lalomataaisaac; database = bd_ejemplo";

// clase para conectar con MySQL

public MySqlConnection conectar;
        public bool abrir()
        {
            try
            {
                conectar = new MySqlConnection(strConexion);
                conectar.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void cerrar()
        {
            conectar.Close();
        }
        public bool ejecutarQuery(string query)
        {
            try
            {
                abrir();
                MySqlCommand comando = new MySqlCommand(query, conectar);
                comando.ExecuteNonQuery();
                cerrar();
                return true;
            }
            catch (Exception er)
            {
                System.Windows.Forms.MessageBox.Show(er.Message);
                return false;
            }
        }
        public DataTable cargarDatos(String query)
        {
            try
            {
                abrir();
                MySqlDataAdapter comando = new MySqlDataAdapter(query,
                strConexion);
                comando.Fill(dt);
                return dt;
            }
            catch (Exception er)
            {
                return dt;
            }
        }
    }
}
