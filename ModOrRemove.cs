using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace U3_E9
{
    public partial class ModOrRemove : Form
    {
        Banco banco;
        Cliente clienteElegido;
        int indiceElegido;
        public ModOrRemove(Banco b)
        {
            InitializeComponent();
            
            banco = b;
            Console.WriteLine();
            actualizarComboBox();
        }

        private void actualizarComboBox()
        {
            comboDNI.Items.Clear();
            foreach (var item in banco.listaClientes)
            {
                comboDNI.Items.Add(item.dni);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboDNI.SelectedIndex==-1)
            {

            }
            else {
                clienteElegido = (Cliente)banco.listaClientes.First(a => a.dni == comboDNI.SelectedItem.ToString());

                txtDNI.Text = clienteElegido.dni;
                txtNombre.Text = clienteElegido.nombre;
                txtDireccion.Text = clienteElegido.direccion;
                txtCuenta.Text = clienteElegido.cuentaCorriente;
                txtTel.Text = clienteElegido.telefono;
            }
            
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            indiceElegido = banco.listaClientes.IndexOf(clienteElegido);
            banco.listaClientes.RemoveAt(indiceElegido);
            actualizarComboBox();

            txtDNI.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            numEdad.Value = 0;
            txtTel.Text = "";
            txtCuenta.Text = "";
            comboDNI.SelectedIndex = -1;
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            banco.listaClientes[indiceElegido].nombre = txtNombre.Text;
            banco.listaClientes[indiceElegido].cuentaCorriente = txtCuenta.Text;
            banco.listaClientes[indiceElegido].direccion = txtDireccion.Text;
            banco.listaClientes[indiceElegido].edad = (int)numEdad.Value;
            banco.listaClientes[indiceElegido].telefono = txtTel.Text;
            actualizarComboBox();
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            numEdad.Value = 0;
            txtTel.Text = "";
            txtCuenta.Text = "";
            comboDNI.SelectedIndex = -1;
            

        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Banco Banco { get { return this.banco; } }
    }
}
