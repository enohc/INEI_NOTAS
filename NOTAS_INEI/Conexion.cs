using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTAS_INEI
{
    class Conexion
    {
        public MySqlConnection conn;
        public MySqlDataAdapter da;
        public DataSet ds = new DataSet();

        public string tabla;
        private string connStr = "server=localhost;user=root;database=inei_nota;port=3306;password=toor;Convert Zero Datetime=True;";

        public Conexion()
        {
            conn = new MySqlConnection(connStr);
        }

        public MySqlConnection getConexion ()
        {
            return conn;

        }



    }
}
