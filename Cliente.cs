using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3_E9
{
    public class Cliente
    {
        public string dni;
        public string nombre;
        public string direccion;
        public int edad;
        public string telefono;
        public string cuentaCorriente;

        public Cliente()
        {
        }

        public Cliente(string dni, string nombre, string direccion, int edad, string telefono, string cuentaCorriente)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.direccion = direccion;
            this.edad = edad;
            this.telefono = telefono;
            this.cuentaCorriente = cuentaCorriente;
        }

        public override bool Equals(object obj)
        {
            return obj is Cliente cliente &&
                   dni == cliente.dni;
        }

        public override int GetHashCode()
        {
            return 1456690394 + EqualityComparer<string>.Default.GetHashCode(dni);
        }
    }
}
