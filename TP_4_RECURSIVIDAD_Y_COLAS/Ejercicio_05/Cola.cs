using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_05
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
                Nodo nodoMayor = buscarUltimo(primerNodo, unNodo);
                nodoAnterior.siguiente = unNodo;
                unNodo.siguiente = nodoMayor;
            }
        }
        private Nodo buscarUltimo(Nodo unNodo, Nodo nodoAregar)
        {
            if (unNodo.siguiente == null)
            {
                nodoAnterior = unNodo;
                return unNodo.siguiente;
            }
            else if (unNodo.siguiente.prioridad <= nodoAregar.prioridad)
            {
                nodoAnterior = unNodo.siguiente;
                return buscarUltimo(unNodo.siguiente, nodoAregar);
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
            if(primerNodo != null)
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
    }
}
