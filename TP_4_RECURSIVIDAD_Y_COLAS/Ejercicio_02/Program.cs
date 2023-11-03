using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese un Numero Positivo: ");

            if (int.TryParse(Console.ReadLine(), out int numero) && numero >= 0)
            {
                Console.WriteLine($"\nEl factorial de {numero} es: {factorial(numero)}");
            }
            else { Console.WriteLine("Numero ingresado no es Valido"); }

            Console.ReadKey();
        }
        public static int factorial(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            else
            {
                return n * factorial(n - 1);
            }
        }
    }
}
