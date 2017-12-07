using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace NOTAS_INEI
{
    public partial class FrmBachillerato : Form
    {
        Conexion cn = new Conexion();
        
        public FrmBachillerato()
        {
            InitializeComponent();
            cn.tabla = "Bachillerato";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.da.Update(cn.ds, cn.tabla);
            label4.Text = "Se actulizo registro";
        }

        private void FrmBachillerato_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from "+ cn.tabla;

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
    }
}
