using System;

class Program
{
    static void Main()
    {
        Console.Write("Ingrese su nombre: ");
        string nombre = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(nombre))
        {
            char inicial = nombre.Trim()[0];
            Console.WriteLine($"Tu inicial es: {inicial}");
        }
        else
        {
            Console.WriteLine("No ingresaste un nombre válido.");
        }
    }
}
