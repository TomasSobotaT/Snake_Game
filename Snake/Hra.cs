using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Snake
{
    public class Hra
    {
        private Had had;                    // instance hada
        private Potrava potrava;            // instance potrava
        private int Score = 0;              // počet sebrané potravy
        private DateTime casStart;          // čas startu hry

        public Hra(Had had, Potrava potrava)
        {
            this.had = had;
            this.potrava = potrava;
            casStart = DateTime.Now;
        }



        /// <summary>
        /// Vykreslení hada
        /// </summary>
        public void Vykresli()
        {
            for (int i = 0; i < had.TeloHada.Count(); i++)
            {
                Console.CursorVisible = false;

               // nesmí být minusová hodnota
                Console.CursorLeft = (had.TeloHada[i].X * 2 < 0) ? 0 : had.TeloHada[i].X * 2;
                Console.CursorTop = had.TeloHada[i].Y;

               
                if (i == 0)      //hlava hada
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    if (!had.Zivy)
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                }
                else             //tělo hada
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    if (!had.Zivy)
                        Console.BackgroundColor = ConsoleColor.Red;


                }
                Console.Write("  ");
                Console.ResetColor();
            }


        }

        /// <summary>
        /// Vykresli potravu 
        /// </summary>
        public void VykresliPotravu()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            if (!had.Zivy)
                Console.BackgroundColor = ConsoleColor.Red;

            Console.CursorLeft = potrava.X * 2;
            Console.CursorTop = potrava.Y;
            Console.Write("  ");
            Console.ResetColor();
        }

        /// <summary>
        /// Kontrola kolize hlavy hada se zdí, potravou a se svým tělem
        /// </summary>
        public void KontrolaKolize()
        {
            for (int i = 1; i < had.TeloHada.Count(); i++)
            {
                // kdyz had naboura sam do sebe
                if (had.TeloHada[0].X == had.TeloHada[i].X && had.TeloHada[0].Y == had.TeloHada[i].Y)
                {
                    had.Zivy = false;
                    break;
                }

            }
            // když hlava hada mimo hrací pole
            if (had.TeloHada[0].X * 2 < 0 || had.TeloHada[0].Y < 3 || had.TeloHada[0].X > 25 || had.TeloHada[0].Y > 15)
            {
                had.Zivy = false;
            }

            // když hlava hada = potrava
            if (had.TeloHada[0].X == potrava.X && had.TeloHada[0].Y == potrava.Y)
            {
                had.TeloHada.Add(new Souradnice(potrava.X, potrava.Y));
                ZmenLokaciPotravy();
                Score++;
            }




        }

        /// <summary>
        /// Změní lokaci potravy po sežrání hadem + lokace nesmí být v těle hada
        /// </summary>
        public void ZmenLokaciPotravy()
        {
            potrava.NastavNoveSouradnicePotravy();

            foreach (var clanek in had.TeloHada)

                if (clanek.X == potrava.X && clanek.Y == potrava.Y)
                {
                    ZmenLokaciPotravy();
                }

        }


        /// <summary>
        ///  //Vykreslí menu na hrací ploše
        /// </summary>
        public void VykresliMenu()
        {

            TimeSpan casSec = DateTime.Now - casStart;             // sekund = ted - start
            DateTime cas = Convert.ToDateTime(casSec.ToString());  // zpatky do DateTimu

            Console.ForegroundColor = ConsoleColor.White;
            if (!had.Zivy) Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.Write(" Skóre: " + Score + "\t");           // sežraná potrava
            Console.Write("   HAD 1.0\t\t");
            Console.Write("Čas: " + cas.ToString("mm:ss"));      // čas ve formatu min:sec
            Console.WriteLine();
            Console.WriteLine("____________________________________________________");
            for (int i = 0; i < 13; i++)
            {
                Console.Write("                                                    |");
                Console.WriteLine();
            }

            Console.WriteLine("----------------------------------------------------");
        }

       
    }
}
