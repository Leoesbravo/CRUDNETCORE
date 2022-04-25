using ConsoleApp1;

Console.WriteLine("Introduzca un número entero: ");
int numero = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("El factorial de " + numero + " es: " + Factorial.CalcularFactorial(numero));

