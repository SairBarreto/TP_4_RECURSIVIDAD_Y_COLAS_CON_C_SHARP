using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_07
{
    class Nodo
    {
        public string cliente { get; set; }
        public Nodo siguiente { get; set; }
        public Nodo(string pCliente="", Nodo pSiguiente = null)
        {
            cliente = pCliente;
            siguiente = pSiguiente;
        }
    }
}
