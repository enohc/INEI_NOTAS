using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace NOTAS_INEI
{
    public partial class FrmActividades : Form
    {
        Conexion cnM = new Conexion();
        Conexion cnA = new Conexion();

        public FrmActividades()
        {
            InitializeComponent();
            cnM.tabla = "Materia";
            cnA.tabla = "actividad";
        }

        private void Actividad_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT Codigo, concat(Codigo,' - ',Nombre) as Nombre FROM " + cnM.tabla+" where activa =1";
                

                cnM.da = new MySqlDataAdapter(sql, cnM.conn);

                cnM.da.Fill(cnM.ds, cnM.tabla);
                comboBox1.DataSource = cnM.ds.Tables["materia"];
                comboBox1.DisplayMember = "Nombre";
                comboBox1.ValueMember = "Codigo";
            }
            catch (Exception ex)
            {
                label2.Text = ex.Message;
                Debug.Write(ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                cnA.ds.Clear();
                dataGridView1.Refresh();

                label2.Text = "";
                string txt = comboBox1.GetItemText(comboBox1.SelectedValue);
                string sql = "select * from " + cnA.tabla +" where materia = '"+txt+"'";

                cnA.da = new MySqlDataAdapter(sql, cnA.conn);

                cnA.da.Fill(cnA.ds, cnA.tabla);
                dataGridView1.DataSource = cnA.ds;
                dataGridView1.DataMember = cnA.tabla;
                
            }
            catch (Exception ex)
            {
                label2.Text = ex.Message;
                Debug.Write(ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cnA.da.Update(cnA.ds, cnA.tabla);
                label2.Text = "Se actulizo registro";
            }
            catch (Exception ex)
            {
                label2.Text = ex.Message;
                Debug.Write(ex);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
