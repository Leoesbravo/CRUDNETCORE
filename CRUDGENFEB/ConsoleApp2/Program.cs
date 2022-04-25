using System;

namespace ConsoleApp2 // Note: actual namespace depends on the project name.
{
    internal class Program : Factorial
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduzca un número entero: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            Factorial objeto = new Factorial();
            objeto.CalcularFactorial(true)

            Console.WriteLine("El factorial de: " + numero + " es: " + Factorial.CalcularFactorial(numero));
        }
    }
}