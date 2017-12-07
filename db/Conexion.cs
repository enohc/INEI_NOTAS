using System;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Data;

namespace db
{
    public class Conexion
    {
        static string connStr = "server=localhost;user=root;database=INEI_NOTA;port=3306;password=";
        MySqlConnection conn = new MySqlConnection(connStr);
        MySqlDataAdapter da;
        DataSet ds;

        public MySqlDataReader Consulta(string sql)
        {          
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Close();
                return rdr;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            conn.Close();

            return null;
        }



        public DataSet grid(string tabla) {

            MySqlConnection conn = new MySqlConnection(connStr);
            string sql = "SELECT * FROM "+tabla;
            da = new MySqlDataAdapter(sql, conn);
            MySqlCommandBuilder cb = new MySqlCommandBuilder(da);

            ds = new DataSet();
            da.Fill(ds, tabla);

            return ds;
          
        }
    }
}
