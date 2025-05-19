using System;

class Programa
{
    static void Main()
    {
        int[] numeros = new int[10];

        Console.WriteLine("Ingrese 10 números desordenados:");

        for (int i = 0; i < numeros.Length; i++)
        {
            Console.Write($"Número {i + 1}: ");
            numeros[i] = int.Parse(Console.ReadLine());
        }

        // Ordenar el arreglo usando Array.Sort
        Array.Sort(numeros);

        Console.WriteLine("\nNúmeros ordenados de menor a mayor:");
        foreach (int numero in numeros)
        {
            Console.WriteLine(numero);
        }

        // Esperar a que el usuario presione una tecla antes de cerrar
        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }
}
