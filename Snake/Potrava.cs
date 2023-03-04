using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    /// <summary>
    /// potrava pro hada
    /// </summary>
    public class Potrava
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        Random random   = new Random();


        public Potrava()
        {
            NastavNoveSouradnicePotravy();
        }


        public void NastavNoveSouradnicePotravy()
        { 
            X = random.Next(26);
            Y = random.Next(3,15);    
          
        }

    }





}
