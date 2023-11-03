using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_06
{
    class Cola
    {
        Nodo primerNodo;
        Nodo nodoAnterior;
        public void agregarNodo(Nodo unNodo)
        {
            if (primerNodo == null)
            {
                primerNodo = unNodo;
            }
            else
            {
                Nodo nodoMayor = buscarMayor(primerNodo, unNodo);
                nodoAnterior.siguiente = unNodo;
                unNodo.siguiente = nodoMayor;
            }
        }
        private Nodo buscarMayor(Nodo unNodo, Nodo nodoAregar)
        {
            if (unNodo.siguiente == null)
            {
                nodoAnterior = unNodo;
                return unNodo.siguiente;
            }
            else if (unNodo.siguiente.ticket <= nodoAregar.ticket)
            {
                nodoAnterior = unNodo.siguiente;
                return buscarMayor(unNodo.siguiente, nodoAregar);
            }
            else
            {
                nodoAnterior = unNodo;
                return unNodo.siguiente;
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
            return eliminado;
        }
        public bool colaVacia()
        {
            return (primerNodo == null);
        }
        public Nodo buscarUltimoNodo(Nodo unNodo)
        {
            if(primerNodo.siguiente != null)
            {
                return buscarUltimoNodo(primerNodo.siguiente);
            }
            return unNodo;
        }
    }
}
