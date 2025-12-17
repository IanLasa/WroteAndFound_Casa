class Prestamo
{






    // Coger prestado un libro
    public static void CogerPrestadoLibro()
    {
        Console.Clear();
        if (hayUsuarioActual == false)
        {
            Console.WriteLine("");
            Console.WriteLine("No estás iniciado como un usario, por favor crea uno o cambia a uno");
            Console.ReadKey();
        }
        else
        {
            while (!salir)
            {
                Console.Clear();
                if (hayLibros())
                {
                    menuListaDeListas("LIBROS", Libros, 0, "Escribe el número del libro que quieres coger prestado", 0, Libros.Count, 50);
                    if (opcion != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("");
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("");
                        bool tieneElLibro = false;

                        // Si tiene el libro
                        for (int i = 2; i < Usuarios[numUsuarioActual].Count; i++)
                        {
                            if (Usuarios[numUsuarioActual][i] == Libros[opcion - 1][0])
                            {
                                tieneElLibro = true;
                            }
                        }
                        if (tieneElLibro)
                        {
                            Console.Clear();
                            Console.WriteLine("Ya tienes este libro prestado...");
                            Console.ReadKey();
                        }

                        // Si tiene 3 libros ya prestados
                        else if (Usuarios[numUsuarioActual].Count == 5)
                        {
                            Console.Clear();
                            Console.WriteLine("Ya tienes 3 libros prestados, devuelve alguno anda...");
                            Console.ReadKey();
                        }

                        // Si lo tiene prestado otro usuario
                        else if (Libros[opcion - 1][4] == "No Disponible")
                        {
                            Console.Clear();
                            Console.WriteLine("Este libro lo tiene prestado otro usuario...");
                            Console.ReadKey();
                        }

                        // Si puede coger coger prestado el libro
                        else
                        {
                            Console.Clear();
                            Libros[opcion - 1][4] = "No Disponible";
                            Usuarios[numUsuarioActual].Add(Libros[opcion - 1][0]);
                            salir = true;
                            Console.WriteLine("¡Libro cogido prestado correctamente!");
                            Console.ReadKey();
                        }
                    }
                    salir = true;
                }
            }
            salir = false;
        }

    }

    // Función para devolver un libro prestado
    public static void DevolverLibro()
    {
        Console.Clear();
        if (hayUsuarioActual == false)
        {
            Console.WriteLine("");
            Console.WriteLine("No estás iniciado como un usario, por favor crea uno o cambia a uno");
            Console.ReadKey();
        }
        else
        {
            while (!salir)
            {
                Console.Clear();
                if (hayLibros())
                {
                    // Muestra los libros que puede devolver
                    if (Usuarios[numUsuarioActual].Count > 2)
                    {
                        Console.WriteLine("----------------------------------------------------");
                        for (int i = 2; i < Usuarios[numUsuarioActual].Count; i++)
                        {
                            Console.WriteLine("");
                            Console.WriteLine($"   {i - 1}. {Usuarios[numUsuarioActual][i]}");

                        }
                        Console.WriteLine("----------------------------------------------------");
                        Console.WriteLine("");
                        pedirNumero("Que libro quieres devolver", 1, Usuarios[numUsuarioActual].Count - 2, false);
                        Console.Clear();
                        Console.WriteLine("");

                        // Si decide devolver un libro
                        for (int i = 0; i < Libros.Count; i++)
                        {
                            if (Libros[i][0] == Usuarios[numUsuarioActual][opcion])
                            {
                                Libros[i][4] = "Disponible";
                            }
                        }
                        Usuarios[numUsuarioActual].RemoveAt(opcion);
                        Console.WriteLine("¡Muy bien, ya se ha devuelto el libro!");
                        salir = true;
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("No tienes Libros prestados, ve y toma uno prestado...");
                        salir = true;
                        Console.ReadKey();
                    }
                }

            }
            salir = false;
        }
    }

    // Función para saber que libros prestados tiene el usuario actual
    public static void LibrosPrestados()
    {
        Console.Clear();
        if (hayUsuarioActual == false)
        {
            Console.WriteLine("");
            Console.WriteLine("No estás iniciado como un usario, por favor crea uno o cambia a uno");
            Console.ReadKey();
        }
        else
        {
            while (!salir)
            {
                Console.Clear();
                if (hayLibros())
                {
                    if (Usuarios[numUsuarioActual].Count > 2)
                    {
                        Console.WriteLine("----------------------------------------------------");
                        for (int i = 2; i < Usuarios[numUsuarioActual].Count; i++)
                        {
                            Console.WriteLine("");
                            Console.WriteLine($"   {i - 1}. {Usuarios[numUsuarioActual][i]}");

                        }
                        Console.WriteLine("----------------------------------------------------");
                        Console.WriteLine("");
                        Console.WriteLine("Presiona una tecla para volver");
                        salir = true;
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("No tienes Libros prestados, ve y toma uno prestado...");
                        salir = true;
                        Console.ReadKey();
                    }
                }

            }
            salir = false;
        }

    }

}