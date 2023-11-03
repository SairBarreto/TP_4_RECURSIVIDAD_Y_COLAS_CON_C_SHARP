using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese un la cantidad del Vector: ");

            if (int.TryParse(Console.ReadLine(), out int max) && max > 0)
            {
                int[] vector = new int[5];
                Console.WriteLine("\n\tIngrese Numeros para el Vector\n");

                for (int i = 0; i < max; i++)
                {
                    Console.Write($"Ingrese un numero en la posición ({i+1}): ");
                    vector[i] = Convert.ToInt16(Console.ReadLine());
                }

                Console.Write("\nVector Ingresado: ");
                foreach (int i in vector)
                {
                    Console.Write(i + " ");
                }
                OrdenarQuicksort(vector, 0, vector.Length - 1);
                Console.Write("\nVector Ingresado Ordenado: ");
                foreach (int i in vector)
                {
                    Console.Write(i + " ");
                }
            }
            else { Console.WriteLine("Numero ingresado no es Valido"); }

            Console.ReadKey();
        }

        static void OrdenarQuicksort(int[] vector, int inicio, int fin)
        {
            if (inicio < fin)
            {
                int indiceParticion = Particionar(vector, inicio, fin);

                OrdenarQuicksort(vector, inicio, indiceParticion - 1);
                OrdenarQuicksort(vector, indiceParticion + 1, fin);
            }
        }

        static int Particionar(int[] vector, int inicio, int fin)
        {
            int pivote = vector[fin];
            int indiceMenor = inicio - 1;

            for (int i = inicio; i < fin; i++)
            {
                if (vector[i] <= pivote)
                {
                    indiceMenor++;
                    Intercambiar(vector, indiceMenor, i);
                }
            }

            Intercambiar(vector, indiceMenor + 1, fin);

            return indiceMenor + 1;
        }

        static void Intercambiar(int[] vector, int indice1, int indice2)
        {
            int temp = vector[indice1];
            vector[indice1] = vector[indice2];
            vector[indice2] = temp;
        }
    }
}
