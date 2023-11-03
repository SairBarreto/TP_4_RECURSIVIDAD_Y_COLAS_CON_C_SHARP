using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_04
{
    class Nodo
    {
        public string nombre { get; set; }
        public string genero { get; set; }

        public Nodo siguiente { get; set; }
        public Nodo(string pNombre = "", string pGenero = "", Nodo pSiguiente = null)
        {
            nombre = pNombre;
            genero = pGenero;
            siguiente = pSiguiente;
        }
    }
}
