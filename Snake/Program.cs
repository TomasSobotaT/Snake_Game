using Snake;

Had had = new Had();                                    // Instance hada
Potrava potrava = new Potrava();                        // Instance potravy
Hra hra = new Hra(had, potrava);                        // Instance hry


while (had.Zivy)                                        // Herní smyčka
{
    Console.Clear();                                    // Vymazání konzole

    try
    {
        had.Lez();                                          // Posun hada
        hra.KontrolaKolize();                               // Kontrola kolizí hada
        hra.VykresliMenu();                                 // Vykreslení menu a hrací lochy
        hra.Vykresli();                                     // Vykreslení hada
        hra.VykresliPotravu();                              // Vykreslí potravu
    }
    catch (Exception ex)
    {
        Console.WriteLine("Nastale chyba ve hře: "+ex.Message);
    }
   
    Thread.Sleep(150);                                  // Čekáme 150 milisekund = rychlost hry
    
    if (Console.KeyAvailable)                           // Pokud je stisknuta nějaká klávesa
    {
        ConsoleKeyInfo klavesa = Console.ReadKey();     // Načtení klávesy
        
        if (klavesa.Key == ConsoleKey.RightArrow)       // Reakce na jednotlivé klávesy
            had.Smer = 0;
        if (klavesa.Key == ConsoleKey.LeftArrow)
            had.Smer = 180;
        if (klavesa.Key == ConsoleKey.DownArrow)
            had.Smer = 270;
        if (klavesa.Key == ConsoleKey.UpArrow)
            had.Smer = 90;
    }
}

Console.ReadKey();