using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DestinosExpress
{
    public class Conexion
    {
        private string contrasenha, usuario, cadenaDeConexion;
        private SqlConnection con;
        public Conexion(string usuario, string contrasenha)
        {
            this.contrasenha = contrasenha;
            this.usuario = usuario;
            cadenaDeConexion = string.Format("Data Source=.; Initial catalog= DestinosExpress; User id= {0} ; password= {1}", usuario, contrasenha);
            try
            {
                con = new SqlConnection(cadenaDeConexion);
                con.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al conectar a la base de datos\n" + e.Message);
            }
        }

        public SqlConnection obtenerConexion { get => con; }
        public string CadenaDeConexion { get => cadenaDeConexion; set => cadenaDeConexion = value; }
    }
}
