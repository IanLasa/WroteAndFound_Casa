class Usuario
{











    // Opción crear cuenta de usuario
    public static void CrearUsuario()
    {
        Console.Clear();
        Console.WriteLine("        ╔════════════════════════╗");
        Console.WriteLine("        ║    [ CREAR CUENTA ]    ║");
        Console.WriteLine("        ╚════════════════════════╝");
        Console.WriteLine("");
        opcionString2 = pedirString("    👤  Nombre (max 10 characteres)", 10);

        // Crea una nueva lista dentro de Listas
        Usuarios.Add(new List<string>() { opcionString2 });
        Console.WriteLine("");
        pedirString("    🔒  Contraseña", 10);

        // Añade a la creada anteriormente
        Usuarios[Usuarios.Count - 1].Add(opcionString);
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("");
        Console.WriteLine("¡Usuario Creado Correctamente!");
        usuarioActual = opcionString2;
        numUsuarioActual = Usuarios.Count - 1;
        hayUsuarioActual = true;
        Console.WriteLine("");
        Console.WriteLine("Presiona una tecla para volver al menú...");
        Console.ReadKey();
    }





    // Opción cambiar de usuario
    public static void CambiarUsuario()
    {
        Console.Clear();
        if (!hayUsuarios())
        {
            // Si no hay usuarios
            Console.WriteLine("");
            Console.WriteLine("No hay usuarios creados, ve y crea uno...");
            Console.WriteLine("");
            Console.ReadKey();
        }
        else
        {
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("        ╔══════════════════════════════╗");
                Console.WriteLine("        ║    [ Cambiar de Usuario ]    ║");
                Console.WriteLine("        ╚══════════════════════════════╝");
                Console.WriteLine("");
                opcionString2 = pedirString("    👤  Nombre del usuario", 10);
                pedirString("    🔒  Contraseña", 10);
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("");
                if (opcionString2 == usuarioActual)
                {
                    // Si intenta cambiar al actual.
                    Console.WriteLine("Ya estas iniciado en este usuario, prueba con otro...");
                    Console.ReadKey();
                }
                else
                {
                    // Si funciona.
                    for (int i = 0; i < Usuarios.Count; i++)
                    {
                        if (opcionString2 == Usuarios[i][0] && opcionString == Usuarios[i][1])
                        {
                            usuarioActual = opcionString2;
                            hayUsuarioActual = true;
                            numUsuarioActual = i;
                            Console.WriteLine("¡Usuario cambiado correctamente!");
                            Console.WriteLine("");
                            Console.WriteLine("Presiona una tecla para volver al menú...");
                            Console.ReadKey();
                            salir = true;
                        }
                    }
                    if (!salir)
                    {
                        // Si no existiese
                        Console.WriteLine("El usuario que has introducido no existe. \n \nOh la contraseña no es correcta");
                        Console.WriteLine("");
                        pedirString("Escribe \"salir\" para volver al menú", 10);
                        if (opcionString == "salir")
                        {
                            salir = true;
                        }
                    }
                }
            }
            salir = false;
        }
    }





    // Opción eliminar usuario
    public static void EliminarUsuario()
    {
        Console.Clear();
        if (!hayUsuarios())
        {
            Console.WriteLine("");
            Console.WriteLine("No hay usuarios creados, ve y crea uno...");
            Console.WriteLine("");
            Console.ReadKey();
        }
        else
        {
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("        ╔══════════════════════════════╗");
                Console.WriteLine("        ║    [ Eliminar un Usuario ]   ║");
                Console.WriteLine("        ╚══════════════════════════════╝");
                Console.WriteLine("");
                opcionString2 = pedirString("    👤  Nombre del usuario", 10);
                pedirString("    🔒  Contraseña", 10);
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("");

                // Si funcioa
                for (int i = 0; i < Usuarios.Count; i++)
                {
                    if (opcionString2 == Usuarios[i][0] && opcionString == Usuarios[i][1])
                    {
                        Usuarios.RemoveAt(i);
                        Console.WriteLine("¡Usuario borrado correctamente!");
                        if (opcionString2 == usuarioActual)
                        {
                            hayUsuarioActual = false;
                            numUsuarioActual = -1;
                        }
                        Console.WriteLine("");
                        Console.WriteLine("Presiona una tecla para volver al menú...");
                        Console.ReadKey();
                        salir = true;
                    }
                }
                if (!salir)
                {
                    // Si no funciona
                    Console.WriteLine("El usuario que has introducido no existe. \n \nOh la contraseña no es correcta");
                    Console.WriteLine("");
                    pedirString("Escribe \"salir\" para volver al menú", 10);
                    if (opcionString == "salir")
                    {
                        salir = true;
                    }
                }
            }
            salir = false;
        }
    }




    // Te muestra cual es el usuario actual
    public static void ActualUsuario()
    {
        Console.Clear();
        if (hayUsuarioActual == false)
        {

            Console.WriteLine("");
            Console.WriteLine("No estás iniciado como un usario, por favor crea uno o cambia a uno");
            Console.WriteLine("");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine($"Actualmente estas iniciado como {usuarioActual}");
            Console.WriteLine("");
            Console.WriteLine("Presiona una tecla para volver");
            Console.ReadKey();
        }
    }
}