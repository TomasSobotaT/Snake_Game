using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Had
    {
        public List<Souradnice> TeloHada { get; set; }         //Kolekce souřadnic těla hada
        public bool Zivy { get; set; } = true;                  //Jestli je had naživu nebo ne

        public int Smer { get; set; }                            //Smer jakým had poleze



        public Had()
            {
                TeloHada = new List<Souradnice>();
                TeloHada.Add(new Souradnice(10, 10));
                TeloHada.Add(new Souradnice(9, 10));
                TeloHada.Add(new Souradnice(8, 10));
            }


        /// <summary>
        /// Posun hada daným směrem
        /// </summary>
        public void Lez() 
        {
            switch (Smer)
            {
                case 0:
                    TeloHada.Insert(0, new Souradnice(TeloHada[0].X + 1, TeloHada[0].Y));
                    TeloHada.Remove(TeloHada[TeloHada.Count()-1]);
                    break;

                case 180:
                    TeloHada.Insert(0, new Souradnice(TeloHada[0].X - 1, TeloHada[0].Y));
                    TeloHada.Remove(TeloHada[TeloHada.Count() - 1]);
                    break;

                case 270:
                    TeloHada.Insert(0, new Souradnice(TeloHada[0].X, TeloHada[0].Y + 1));
                    TeloHada.Remove(TeloHada[TeloHada.Count() - 1]);
                    break;

                case 90:
                    TeloHada.Insert(0, new Souradnice(TeloHada[0].X, TeloHada[0].Y -1));
                    TeloHada.Remove(TeloHada[TeloHada.Count() - 1]);
                    break;
            }


        
        }

       





    }
}
