using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace U3_E9
{
    public partial class Form1 : Form
    {
        Banco banco;
        public Form1()
        {
            InitializeComponent(); 
            this.ActiveControl = btnAdd;
            FileInfo archivo = new FileInfo("banco.xml");
            bool existe = archivo.Exists;
            string path = archivo.FullName;
            if (existe == false)
            {
                banco = new Banco();
                
            }
            else
            {
                //Deserializo el banco
                XmlSerializer serializer = new XmlSerializer(typeof(Banco));
                using (var stream = new FileStream("banco.xml", FileMode.Open))
                {
                    banco = (Banco)serializer.Deserialize(stream);
                    stream.Close();
                }
                
                
                                
            }
            ActualizarDataGrid();
            

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            Cliente c = new Cliente(txtDNI.Text, txtNombre.Text, txtDireccion.Text, (int)numEdad.Value, txtTel.Text, txtCuenta.Text);

            banco.añadirCliente(c);
            
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            numEdad.Value = 0;
            txtTel.Text = "";
            txtCuenta.Text = "";
            ActualizarDataGrid();

        }

        private void txtDNI_Validating(object sender, CancelEventArgs e)
        {
            if (Regex.IsMatch(txtDNI.Text,@"^[0-9]{8}[A-Z]$")==false)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDNI, "El formato es incorrecto");
            }
            
        }

        private void txtDNI_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtDNI, "");
        }

        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
            if (Regex.IsMatch(txtNombre.Text, @"^\w+$") == false)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNombre, "El formato es incorrecto");
            }
        }

        private void txtNombre_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNombre, "");
        }

        private void ActualizarDataGrid() {
            BindingList<Cliente> listaClientes = new BindingList<Cliente>(banco.listaClientes);
            dataGridView1.DataSource = listaClientes;
            dataGridView1.Refresh();
            Console.WriteLine();

        }      

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Banco));
            using (var stream = new FileStream("banco.xml", FileMode.Create))
            {

                serializer.Serialize(stream, banco);
                stream.Close();
            }
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            ModOrRemove mod = new ModOrRemove(banco);
            mod.ShowDialog();
            banco = mod.Banco;
            ActualizarDataGrid();
            Console.WriteLine();
        }

        private void txtDireccion_Validating(object sender, CancelEventArgs e)
        {
            if (Regex.IsMatch(txtDireccion.Text, @"^\w+$") == false)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDireccion, "El formato es incorrecto");
            }
        }

        private void txtDireccion_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtDireccion, "");
        }

        private void txtTel_Validating(object sender, CancelEventArgs e)
        {
            if (Regex.IsMatch(txtTel.Text, @"^[0-9]{9}$") == false)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTel, "El formato es incorrecto");
            }
        }

        private void txtTel_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtTel, "");
        }

        private void txtCuenta_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtCuenta, "");
        }

        private void txtCuenta_Validating(object sender, CancelEventArgs e)
        {
            if (Regex.IsMatch(txtCuenta.Text, @"^[0-9]{10}$") == false)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCuenta, "El formato es incorrecto");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarDataGrid();
        }
    }
}
