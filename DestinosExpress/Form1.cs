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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion con = new Conexion(textBox1.Text, textBox2.Text);
                con.obtenerConexion.Close();
                FrmAgregar frm = new FrmAgregar(con);
                frm.Show();
            }catch (Exception ex)
            {
                MessageBox.Show("Hubo un error\n"+ ex.Message);
            }
            
        }
    }
}
