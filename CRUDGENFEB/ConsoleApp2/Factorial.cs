using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Factorial
    {
        public  int CalcularFactorial(int numero)
        {
            if (numero == 0)//Caso Base(evita que el ciclo sea infinito)
            {              
                return 1;
            }
            return numero * CalcularFactorial(numero - 1);
        }

        public bool CalcularFactorial(bool objeto)
        {
            return true;
        }
    }
}
