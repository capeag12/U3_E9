using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace U3_E9
{
    public class Banco
    {
        public List<Cliente> listaClientes;

        public Banco()
        {
            this.listaClientes = new List<Cliente>();
        }

        public Banco(List<Cliente> listaClientes)
        {
            this.listaClientes = listaClientes;
        }

        public void añadirCliente(Cliente c)
        {
            this.listaClientes.Add(c);
        }

        
    }
}
