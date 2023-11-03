using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_06
{
    class Nodo
    {
        public string nombre { get; set; }
        public int ticket { get; set; }
        public Nodo siguiente { get; set; }
        public Nodo(string pNombre = "", int pTicket = 0, Nodo pSiguiente = null)
        {
            nombre = pNombre;
            ticket = pTicket;
            siguiente = pSiguiente;
        }

        public void asignarTicket(int numeroTicket)
        {
            ticket = numeroTicket;
        }
    }
}
