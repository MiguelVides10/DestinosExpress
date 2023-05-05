using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DestinosExpress
{
    public partial class FrmPrincipal : Form
    {
        Conexion conectando;
        public FrmPrincipal(Conexion con)
        {
            this.conectando = con;
            InitializeComponent();
            mostrarTodo();
            
        }

        public void mostrarTodo()
        {
            ClienteController clntCntlr = new ClienteController();
            dataGridView1.DataSource= clntCntlr.mostrarTodo(conectando);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAgregar frm = new FrmAgregar(conectando);
                frm.Show();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
