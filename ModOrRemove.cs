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
        public ModOrRemove()
        {
            InitializeComponent();
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
            Cliente c = (Cliente)banco.listaClientes.First(a => a.dni == comboDNI.SelectedItem.ToString());
            Console.WriteLine();
        }
    }
}
