using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace DestinosExpress
{
    public class ClienteController
    {

        public List<Cliente> verTodo(Conexion con)
        {
            List<Cliente> lClientes = new List<Cliente>();
            string query = "select * from clientes";
            SqlCommand scm = new SqlCommand(query, con.obtenerConexion);
            try
            {
                con.obtenerConexion.Open();
                SqlDataReader lector = scm.ExecuteReader();
                while (lector.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Id_cliente = lector.GetInt32(0);
                    cliente.Nombre = lector.GetString(1);
                    cliente.Apellido = lector.GetString(2);
                    cliente.Edad = lector.GetInt32(3);
                    cliente.Pasaporte = lector.GetString(4);
                    cliente.Dui = lector.GetString(5);
                    lClientes.Add(cliente);
                }
                lector.Close();
                con.obtenerConexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hay un error \n" + ex.Message);
            }
            return lClientes;
        }

        public void editarCliente(int id,string nombre, string apellido, int edad, string pasaporte, string dui, Conexion con)
        {
            string query = "UPDATE clientes set nombre =@nombre, apellido=@apellido, edad=@edad, pasaporte=@pasaporte, dui=@dui WHERE id_cliente=@id";
            using (SqlConnection conectar = new SqlConnection(con.CadenaDeConexion))
            {
                conectar.Open();
                using(SqlCommand sqlc = new SqlCommand(query, conectar))
                {
                    Cliente clnte = new Cliente(nombre, apellido, edad, pasaporte, dui);
                    sqlc.Parameters.AddWithValue("@id", id);
                    sqlc.Parameters.AddWithValue("@nombre", clnte.Nombre);
                    sqlc.Parameters.AddWithValue("@apellido", clnte.Apellido);
                    sqlc.Parameters.AddWithValue("@edad", clnte.Edad);
                    sqlc.Parameters.AddWithValue("@pasaporte", clnte.Pasaporte);
                    sqlc.Parameters.AddWithValue("@dui", clnte.Dui);

                    try
                    {
                        sqlc.ExecuteNonQuery();

                    }catch(Exception ex)
                    {
                        throw new Exception("Hay un error\n"+ex.Message);
                    }
                }
            }
        }

        public void guardarCliente(string nombre, string apellido, int edad, string pasaporte, string dui, Conexion con)
        {
            string query = "INSERT INTO clientes(nombre, apellido, edad, pasaporte, dui) " +
                "values(@nombre, @apellido, @edad, @pasaporte, @dui);";
            Cliente clnte = new Cliente(nombre, apellido, edad, pasaporte, dui);
            using (SqlConnection conectar = new SqlConnection(con.CadenaDeConexion))
            {
                SqlCommand sqlc = new SqlCommand(query, conectar);
                sqlc.Parameters.AddWithValue("@nombre", clnte.Nombre);
                sqlc.Parameters.AddWithValue("@apellido", clnte.Apellido);
                sqlc.Parameters.AddWithValue("@edad", clnte.Edad);
                sqlc.Parameters.AddWithValue("@pasaporte", clnte.Pasaporte);
                sqlc.Parameters.AddWithValue("@dui", clnte.Dui);
                try
                {
                    conectar.Open();
                    sqlc.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hubo un error\n" + ex.Message);
                }
            }
        }

        public Cliente mostrarCliente (int id, Conexion con)
        {
            string query = "SELECT * FROM clientes WHERE id_cliente=@id;";
            using (SqlConnection conectar = new SqlConnection(con.CadenaDeConexion))
            {
                using (SqlCommand sqlc = new SqlCommand(query, conectar))
                {
                    conectar.Open();
                    sqlc.Parameters.AddWithValue("@id", id);
                    try
                    {
                        SqlDataReader lector = sqlc.ExecuteReader();
                        lector.Read();

                        Cliente clnt = new Cliente();
                        clnt.Id_cliente = lector.GetInt32(0);
                        clnt.Nombre = lector.GetString(1);
                        clnt.Apellido = lector.GetString(2);
                        clnt.Edad = lector.GetInt32(3);
                        clnt.Pasaporte = lector.GetString(4);
                        clnt.Dui = lector.GetString(5);

                        return clnt;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }

            }
        }

        //uso de Using statement
        public List<Cliente> mostrarTodo(Conexion con)
        {
            List<Cliente> lClientes = new List<Cliente>();
            string query = "select * from clientes";

            using (SqlConnection conectar = new SqlConnection(con.CadenaDeConexion))
            {
                conectar.Open();
                using (SqlCommand scm = new SqlCommand(query, conectar))
                {
                    try
                    {
                        SqlDataReader lector = scm.ExecuteReader();
                        while (lector.Read())
                        {
                            Cliente cliente = new Cliente();
                            cliente.Id_cliente = lector.GetInt32(0);
                            cliente.Nombre = lector.GetString(1);
                            cliente.Apellido = lector.GetString(2);
                            cliente.Edad = lector.GetInt32(3);
                            cliente.Pasaporte = lector.GetString(4);
                            cliente.Dui = lector.GetString(5);
                            lClientes.Add(cliente);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hay un error \n" + ex.Message);
                    }
                }
            }

            return lClientes;
        }
    }
}

