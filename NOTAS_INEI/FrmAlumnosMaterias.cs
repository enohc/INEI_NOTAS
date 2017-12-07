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
    public partial class FrmAlumnosMaterias : Form
    {
        Conexion cnM = new Conexion();
        Conexion cnA = new Conexion();
        Conexion cnMA = new Conexion();

        public FrmAlumnosMaterias()
        {
            InitializeComponent();
            cnA.tabla  = "Alumno";
            cnM.tabla  = "Materia";
            cnMA.tabla = "Alumno";
        }
        
        private void FrmAlumnosMaterias_Load(object sender, EventArgs e)
        {            
            try
            {
                string sql  = "SELECT Codigo, concat(Codigo,' - ',Nombre) as Nombre FROM " + cnM.tabla;
 
                alumnosMaterias();
                alumnosActivos();

                cnM.da = new MySqlDataAdapter(sql,  cnM.conn);
 
                cnM.da.Fill(cnM.ds, cnM.tabla);
                comboBox1.DataSource = cnM.ds.Tables["materia"];
                comboBox1.DisplayMember = "Nombre";
                comboBox1.ValueMember = "Codigo";
  
            }
            catch (Exception ex)
            {
                label2.Text = ex.ToString();
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            alumnosMaterias();
        }

        private void alumnosMaterias()
        {
            try
            {
                listBox2.DataSource = null;
                cnMA.ds.Clear();
                listBox2.Items.Clear();
                listBox2.Refresh();
                
                string txt = comboBox1.GetItemText(comboBox1.SelectedValue);
                string sql = "SELECT carnet, concat( apellidos, ', ', nombres) as nombre FROM alumno where carnet in ( SELECT alumno FROM alumno_materia where materia='"+txt+"')";
                
                cnMA.da = new MySqlDataAdapter(sql, cnMA.conn);

                cnMA.da.Fill(cnMA.ds, cnMA.tabla);
                listBox2.DataSource = cnMA.ds.Tables["alumno"];
                listBox2.DisplayMember = "nombre";
                listBox2.ValueMember = "carnet";
                listBox2.Refresh();
            }
            catch (Exception ex)
            {
                label2.Text = ex.Message;
                Debug.Write(ex);
            }
        }

        private void alumnosActivos()
        {
            try
            {
                string sql = "SELECT carnet, concat(apellidos,', ',nombres) as nombre FROM " + cnA.tabla +" where activo=1";
                
                cnA.da = new MySqlDataAdapter(sql, cnA.conn);
                
                cnA.da.Fill(cnA.ds, cnA.tabla);
                listBox1.DataSource = cnA.ds.Tables["alumno"];
                listBox1.DisplayMember = "nombre";
                listBox1.ValueMember = "carnet";

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
                string materia = comboBox1.GetItemText(comboBox1.SelectedValue); 
                string alumno = listBox1.GetItemText(listBox1.SelectedValue);
                string observaciones = "--";
                string sql = "insert into alumno_materia (alumno,materia,observaciones) values ('"+alumno+"','"+materia+"','"+observaciones+"');";
                
                cnMA.conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, cnMA.conn);
                cmd.ExecuteNonQuery();
                cnMA.conn.Close();
                label2.Text = "Alumno ya se asociado a la Materia";

                alumnosMaterias();
            }
            catch (Exception ex)
            {
                label2.Text += ex.Message;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string materia = comboBox1.GetItemText(comboBox1.SelectedValue);
                string alumno = listBox1.GetItemText(listBox1.SelectedValue);
                
                string sql = "delete alumno_materia where alumno='" + alumno + "' and materia ='" + materia + "'";
                
                cnMA.conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, cnMA.conn);
                cmd.ExecuteNonQuery();
                cnMA.conn.Close();

                label2.Text = "Alumno ya no esta asociado a la Materia";

            }
            catch (Exception ex)
            {
                label2.Text = ex.ToString();
            }
        }
    }
}
