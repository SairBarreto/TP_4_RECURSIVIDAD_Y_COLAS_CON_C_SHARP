using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_04
{
    class Cola
    {
        Nodo primerNodo;

        public void agregarNodo(string pNombre, string pGenero)
        {
            Nodo nuevoNodo = new Nodo(pNombre, pGenero);

            if(primerNodo == null)
            {
                primerNodo = nuevoNodo;
            }
            else
            {
                Nodo ultimoNodo = BuscarUltimo(primerNodo);
                ultimoNodo.siguiente = nuevoNodo;
            }
        }
        private Nodo BuscarUltimo(Nodo unNodo)
        {
            if (unNodo.siguiente == null)
            {
                return unNodo;
            }
            else
            {
                return BuscarUltimo(unNodo.siguiente);
            }
        }
        public Nodo eliminarNodo()
        {
            Nodo eliminar = new Nodo();

            if (primerNodo != null)
            {
                eliminar = primerNodo;
                primerNodo = primerNodo.siguiente;
                eliminar.siguiente = null;
            }

            return eliminar;
        }
        public Nodo mostrarNodo()
        {
            Nodo mostrar = null;

            if (primerNodo != null)
            {
                mostrar = new Nodo(primerNodo.nombre, primerNodo.genero);
            }

            return mostrar;
        }
        public bool colaVacia()
        {
            return (primerNodo == null);
        }
    }
}
