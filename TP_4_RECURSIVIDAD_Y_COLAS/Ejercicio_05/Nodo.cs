using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_05
{
    class Nodo
    {
        public string nombre { get; set; }
        public int prioridad { get; set; }
        public Nodo siguiente { get; set; }
        public Nodo(string pNombre = "", int pPrioridad = 0, Nodo pSiguiente = null)
        {
            nombre = pNombre;
            prioridad = pPrioridad;
            siguiente = pSiguiente;
        }
    }
}
