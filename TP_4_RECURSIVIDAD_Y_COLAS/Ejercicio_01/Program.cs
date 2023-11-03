using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese un Numero Positivo: ");

            if (int.TryParse(Console.ReadLine(), out int numero) && numero >= 0)
            {
                Console.WriteLine();
                mostrarRecursivo(numero);
            }
            else { Console.WriteLine("Numero ingresado no es Valido"); }

            Console.ReadKey();
        }

        static void mostrarRecursivo(int num)
        {
            if (num == 0)
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Numero: {num}");
                mostrarRecursivo(num - 1);
            }
            
        }
    }
}
