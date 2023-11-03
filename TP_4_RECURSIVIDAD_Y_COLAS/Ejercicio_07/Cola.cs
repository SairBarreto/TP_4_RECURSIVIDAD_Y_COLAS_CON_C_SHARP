using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_07
{
    class Cola
    {
        Nodo primerNodo;
        int cantidadTotal = 0;
        public void agregarNodo(Nodo nodoAgregar)
        {
            if (primerNodo == null)
            {
                primerNodo = nodoAgregar;
                cantidadTotal++;
            }
            else
            {
                Nodo ultimoNodo = buscarUltimoNodo(primerNodo);
                ultimoNodo.siguiente = nodoAgregar;
                cantidadTotal++;
            }
        }
        public Nodo eliminarNodo()
        {
            Nodo eliminado = new Nodo();
            if (primerNodo != null)
            {
                eliminado = primerNodo;
                primerNodo = primerNodo.siguiente;
                eliminado.siguiente = null;
            }
            cantidadTotal--;
            return eliminado;
        }
        public bool colaVacia()
        {
            return (primerNodo == null);
        }
        public Nodo buscarUltimoNodo(Nodo unNodo)
        {
            if (unNodo.siguiente == null)
            {
                return unNodo;
            }
            else
            {
                return buscarUltimoNodo(unNodo.siguiente);
            }
        }
        public int obtenerTotal()
        {
            return cantidadTotal;
        }
    }
}
