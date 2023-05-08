using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DestinosExpress
{
    public partial class FrmAgregar : Form
    {
        Conexion conectando;
        public FrmAgregar(Conexion con)
        {
            this.conectando = con;
            InitializeComponent();
            mostrarTodo();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ClienteController controller = new ClienteController();
            try
            {
                controller.guardarCliente(txtNombre.Text, txtApellido.Text, Convert.ToInt16(txtEdad.Text),
                    cmbxPasaporte.Text, cmbxPasaporte.Text, conectando);
                MessageBox.Show("Registro guardado con éxito","Guardado",MessageBoxButtons.OK, MessageBoxIcon.Information);
                mostrarTodo();

            } catch(Exception ex)
            {
                MessageBox.Show("Error al guardar el registro\n" + ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public void mostrarTodo()
        {
            ClienteController clntCntlr = new ClienteController();
            dataGridView1.DataSource = clntCntlr.mostrarTodo(conectando);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ClienteController clnt = new ClienteController();
            try
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                clnt.editarCliente(id,txtNombre.Text, txtApellido.Text, Convert.ToInt16(txtEdad.Text),
                    cmbxPasaporte.Text, cmbxPasaporte.Text, conectando);
                MessageBox.Show("Registro editado con éxito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource= clnt.mostrarTodo(conectando);
            } catch( Exception ex )
            {
                MessageBox.Show("Error al editar el registro\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            ClienteController clnt = new ClienteController();
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            Cliente cliente = clnt.mostrarCliente(id, conectando);
            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtEdad.Text = cliente.Edad.ToString();
            cmbxPasaporte.Text = cliente.Pasaporte;
            cmbxDui.Text = cliente.Dui;
        }
    }
}
