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
    public partial class FrmAgregar : Form
    {
        Conexion conectando;
        public FrmAgregar(Conexion con)
        {
            this.conectando = con;
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ClienteController controller = new ClienteController();
            try
            {
                controller.guardarCliente(txtNombre.Text, txtApellido.Text, Convert.ToInt16(txtEdad.Text),
                    cmbxPasaporte.Text, cmbxPasaporte.Text, conectando);
                MessageBox.Show("Registro guardado con éxito","Guardado",MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch(Exception ex)
            {
                MessageBox.Show("Error al guardar el registro\n" + ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
