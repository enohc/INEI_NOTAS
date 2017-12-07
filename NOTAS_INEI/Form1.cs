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
    public partial class Form1 : Form
    {
        FrmBachillerato frmBachillerato = new FrmBachillerato();
        FrmNotas frmNotas = new FrmNotas();
        FrmAlumnos frmAlumnos = new FrmAlumnos();
        FrmMateria frmMateria = new FrmMateria();
        FrmAlumnosMaterias frmAlumnosMaterias = new FrmAlumnosMaterias();
        FrmActividades     frmActividades = new FrmActividades();

        public Form1()
        {
            InitializeComponent();
        }
        
        private void bachilleratoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmBachillerato.MdiParent = this;
            frmBachillerato.FormBorderStyle = FormBorderStyle.None;
            frmBachillerato.Show();
            
            frmNotas.Hide();
            frmAlumnos.Hide();
            frmMateria.Hide();
            frmAlumnosMaterias.Hide();
            frmActividades.Hide();
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmAlumnos.MdiParent = this;
            frmAlumnos.FormBorderStyle = FormBorderStyle.None;
            frmAlumnos.Show();
            frmBachillerato.Hide();
            frmNotas.Hide();
            frmMateria.Hide();
            frmAlumnosMaterias.Hide();
            frmActividades.Hide();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMateria.MdiParent = this;
            frmMateria.FormBorderStyle = FormBorderStyle.None;
            frmMateria.Show();
            frmBachillerato.Hide();
            frmNotas.Hide();
            frmAlumnos.Hide();
            frmAlumnosMaterias.Hide();
            frmActividades.Hide();
        }

        private void materiasAlumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlumnosMaterias.FormBorderStyle = FormBorderStyle.None;
            frmAlumnosMaterias.MdiParent = this;
            frmAlumnosMaterias.Show();
            frmBachillerato.Hide();
            frmNotas.Hide();
            frmAlumnos.Hide();
            frmMateria.Hide();
            frmActividades.Hide();
        }

        private void actividadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmActividades.MdiParent = this;
            frmActividades.FormBorderStyle = FormBorderStyle.None;
            frmActividades.Show();
            frmBachillerato.Hide();
            frmNotas.Hide();
            frmAlumnos.Hide();
            frmMateria.Hide();
            frmAlumnosMaterias.Hide();
        }

        private void notasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNotas.MdiParent = this;
            frmNotas.FormBorderStyle = FormBorderStyle.None;
            frmNotas.Show();
            frmBachillerato.Hide();
            frmAlumnos.Hide();
            frmMateria.Hide();
            frmAlumnosMaterias.Hide();
            frmActividades.Hide();
        }
    }
}
