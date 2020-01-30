using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SncMusic
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAluno frmaluno = new FrmAluno();
            frmaluno.MdiParent = this;
            frmaluno.Show();
        }

        private void alunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void novaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProfessor frmProfessor = new FrmProfessor();
            frmProfessor.MdiParent = this;
            frmProfessor.Show();
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCurso frmCurso = new FrmCurso();
            frmCurso.MdiParent = this;
            frmCurso.Show();


        }

        private void matrículaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMatrícula frmMatrícula = new FrmMatrícula();
            frmMatrícula.MdiParent = this;
            frmMatrícula.Show();
        }
    }
}
