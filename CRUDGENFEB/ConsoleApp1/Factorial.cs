using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Factorial
    {
        public static int CalcularFactorial(int numero)
        {
            if (numero == 0)
            {              // Aseguramos que termine (caso base)
                return 1;
            }
            return numero * CalcularFactorial(numero - 1);  // Si no es 1, sigue la recursión
        }
    }
}
