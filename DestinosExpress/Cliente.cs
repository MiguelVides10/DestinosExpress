using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DestinosExpress
{
    public class Cliente
    {
        private int id_cliente;
        private string nombre;
        private string apellido;
        private int edad;
        private string pasaporte;
        private string dui;

        public int Id_cliente { get => id_cliente; set => id_cliente = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Pasaporte { get => pasaporte; set => pasaporte = value; }
        public string Dui { get => dui; set => dui = value; }
        


        public Cliente(string _nombre, string _apellido, int _edad, string _pasaporte, string _dui)
        {
            DialogResult respuesta;
            Nombre = _nombre;
            Apellido = _apellido;
            //Al ser menor de edad tiene que poseer un documento para poder viajar
            if (_edad < 18 && _pasaporte == "No")
            {
                respuesta = MessageBox.Show("No puede viajar un menor de edad sin pasaporte\n ¿Desea agregar el pasaporte?",
                    "De ninguna manera", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                if (respuesta == System.Windows.Forms.DialogResult.Yes)
                {
                    Edad = _edad;
                    Pasaporte = "Si";
                    Dui = "No";
                }
                else
                {
                    throw new SystemException();
                }
            }
            // en caso contrario se almacenan los valores
            else
            {
                Edad = _edad;
                Pasaporte = _pasaporte;
                Dui = _dui;
            }
        }

        public Cliente() { }
    }
}
