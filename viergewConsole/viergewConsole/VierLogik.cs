using System;
using System.Collections.Generic;
using System.Text;

namespace viergewConsole
{
    public class Vierlogik
    {
        protected int[,] game;
        protected int turn;
        public int Turn
        {
            get
            {
                return turn;
            }
        }

        public Vierlogik(int w, int h)
        {
            game = new int[w, h];
        }

        public bool SetOn(int num)
        {
            int pos = SetPos(num);
            if (pos != -1)//if possible
            {
                game[num,pos] = Turn % 2 + 1;
                turn++;
                return true;//it worked
            }
            return false;//it didn't worked
        }

        public int SetPos(int num)//calculate y-position for given x when set on
        {
            if (num < 0 || num > game.GetLength(0) - 1)//not in range
            {
                return -1;
            }
            bool wasZero = false;//until there is a zero it should fall down (higher numbers in the array)
            for (int i = 0; i < game.GetLength(1); i++)
            {
                if (wasZero && game[num,i] != 0)
                {
                    return i - 1;
                }
                wasZero = (game[num,i] == 0);
            }
            if (wasZero)
            {
                return game.GetLength(1) - 1;
            }
            return -1;//if no zero in row=> not possible
        }

        public int Checkwinner()//check who has won
        {
            for (int sp = 1; sp <= 2; sp++)
            {
                for (int x = 0; x < game.GetLength(0); x++)
                {
                    for (int y = 0; y < game.GetLength(1); y++)
                    {
                        if (CheckLines(x, y, sp) || CheckRows(x, y, sp) || CheckBackslash(x, y, sp) || CheckSlash(x, y, sp))
                        {
                            return sp;
                        }
                    }
                }
            }
            if (Nozero())//when there is no zero and no winner => a tie
            {
                return 0;
            }
            return -1;
        }

        private bool Nozero()//check for a full field
        {
            for (int i = 0; i < game.GetLength(0); i++)
            {
                if (SetPos(i) != -1)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckLines(int x, int y, int sp)// -
        {
            if (x + 4 > game.GetLength(0))
            {
                return false;
            }
            for (int i = 0; i < 4; i++)
            {
                if (game[x + i,y] != sp)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckRows(int x, int y, int sp)// |
        {
            if (y + 4 > game.GetLength(1))
            {
                return false;
            }
            for (int i = 0; i < 4; i++)
            {
                if (game[x,y + i] != sp)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckSlash(int x, int y, int sp)// /
        {
            if (x + 4 > game.GetLength(0) || y + 4 > game.GetLength(1))
            {
                return false;
            }
            for (int i = 0; i < 4; i++)
            {
                if (game[x + i,y + i] != sp)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckBackslash(int x, int y, int sp)// \
        {
            if (x + 4 > game.GetLength(0) || y - 3 < 0)
            {
                return false;
            }
            for (int i = 0; i < 4; i++)
            {
                if (game[x + i,y - i] != sp)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
