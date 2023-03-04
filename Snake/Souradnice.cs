using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    /// <summary>
    /// // souradnice pro clanky hada (naplní se jimi List<Souradnice> tela hada)
    /// </summary>
    public class Souradnice
    {
        public int X { get;  private set; }
        public int Y { get; private set; }


        public Souradnice(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

   

}
