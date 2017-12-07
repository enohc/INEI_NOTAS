using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NOTAS_INEI
{
    public partial class FrmNotas : Form
    {
        Conexion cnM = new Conexion();
        Conexion cnA = new Conexion();
        Conexion cnN = new Conexion();
        string txtMateria = "";
        public FrmNotas()
        {
            InitializeComponent();
            cnM.tabla = "Materia";
            cnA.tabla = "Actividad";
            cnN.tabla = "Notas";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox2.DataSource = null;
                cnA.ds.Clear();
                comboBox2.Refresh();

                string txt = comboBox1.GetItemText(comboBox1.SelectedValue);
                txtMateria = txt;
                string sql = "SELECT Actividad, Nombre FROM " + cnA.tabla;
                       sql += " where activo = 1 and materia = '"+txt+"'";

                cnA.da = new MySqlDataAdapter(sql, cnM.conn);

                cnA.da.Fill(cnA.ds, cnA.tabla);     
                comboBox2.DataSource = cnA.ds.Tables["Actividad"];
                comboBox2.DisplayMember = "Nombre";
                comboBox2.ValueMember = "Actividad";
                comboBox2.Refresh();
                label3.Text = "";
            }
            catch (Exception ex)
            {
                label3.Text = ex.Message;
                Debug.Write(ex);
            }
        }

        private void FrmNotas_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT Codigo, concat(Codigo,' - ',Nombre) as Nombre FROM " + cnM.tabla;


                cnM.da = new MySqlDataAdapter(sql, cnM.conn);

                cnM.da.Fill(cnM.ds, cnM.tabla);
                comboBox1.DataSource = cnM.ds.Tables["materia"];
                comboBox1.DisplayMember = "Nombre";
                comboBox1.ValueMember = "Codigo";
                label3.Text = "";
            }
            catch (Exception ex)
            {
                label3.Text = ex.Message;
                Debug.Write(ex);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2 != null)
            { 
                try
                {

                    dataGridView1.DataSource = null;
                    cnN.ds.Clear();
                    dataGridView1.Refresh();

                    string txt = comboBox2.GetItemText(comboBox2.SelectedValue);
                    
                    string sql = "select a.carnet, a.apellidos, a.nombres,  \"\" nota from Alumno_materia  am ";
                    sql += " join alumno a on a.carnet = am.alumno";
                    sql += " where materia = " + txtMateria;

                    Debug.WriteLine(sql);
                    cnN.da = new MySqlDataAdapter(sql, cnN.conn);
       
                    cnN.da.Fill(cnN.ds, "Alumno_materia");
                    dataGridView1.DataSource = cnN.ds;
                    dataGridView1.DataMember = "Alumno_materia";
                    dataGridView1.Refresh();
                    label3.Text = "";
                }
                catch (Exception ex)
                {
                    label3.Text = ex.Message;
                    Debug.WriteLine(ex);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32 filas = dataGridView1.RowCount;
            if (filas > 0)
            {
                label3.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();


            }
        }
    }
}
