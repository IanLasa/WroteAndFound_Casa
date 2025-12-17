class Autoria
{
    public static void MiAutoria()
    {
        Console.Clear();
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("");
        }

        Console.WriteLine("Programa hecho sin dormir por Ian Lasa.");
        Console.WriteLine("");
        Console.WriteLine("Finalizado el proyecto el 14/11/2025 a las 10:04");
        Console.WriteLine("");

        int nota = pedirNumero("¿Que nota le das a este fabuloso proyecto?", 10, 11, false);
        Console.Clear();

        Console.Clear();
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("");
        }
        Console.WriteLine($"¡Gracias por el merecido {nota}!");
        Console.ReadKey();
    }
}