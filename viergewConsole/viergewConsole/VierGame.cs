using System;
using System.Collections.Generic;
using System.Text;

namespace viergewConsole
{
    public class VierGame : Vierlogik
    {
        public VierGame(int w, int h) : base(w, h)
        {

        }

        public void Out()//output for console game
        {
            for (int y = 0; y < game.GetLength(1); y++)
            {
                for (int x = 0; x < game.GetLength(0); x++)
                {
                    Console.Write(game[x,y] == 0 ? '-' : game[x,y] == 1 ? 'X' : 'O');
                }
                Console.WriteLine();
            }
        }
    }
}
