using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NOTAS_INEI
{
    public partial class FrmMateria : Form
    {
        Conexion cn = new Conexion();

        public FrmMateria()
        {
            InitializeComponent();
            cn.tabla = "Materia";
        }

        private void FrmMateria_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from " + cn.tabla;

                cn.da = new MySqlDataAdapter(sql, cn.conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(cn.da);

                cn.da.Fill(cn.ds, cn.tabla);
                dataGridView1.DataSource = cn.ds;
                dataGridView1.DataMember = cn.tabla;
            }
            catch (Exception ex)
            {
                label4.Text = ex.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cn.da.Update(cn.ds, cn.tabla);
                label4.Text = "Se actulizo registro";
            }
            catch (Exception ex)
            {
                label4.Text = ex.ToString();
            }
            
        }
    }
}
