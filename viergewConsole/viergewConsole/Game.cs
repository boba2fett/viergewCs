using System;

namespace viergewConsole
{
    class Game
    {
        private readonly VierGame vier;

        private Game()
        {
            vier = new VierGame(7, 6);
        }
        static void Main()
        {
            Console.WriteLine("Hello World!");
            Game g = new Game();
            g.Start();
        }

        private void Start()
        {
            Console.WriteLine("Willkommen\n('x' beendet immer)");
            int sp;
            do
            {
                sp = NumIn("KI ist Spieler 1 oder 2 oder KI spielt nicht mit: 0?");
            } while (sp < 0 || sp > 2);
            do
            {
                vier.Out();
                Console.WriteLine("0123456");
                //System.out.println("ai: "+vier.ai());//Ai hints
                int num;
                do
                {
                    Console.WriteLine(vier.Turn % 2 + 1 == 1 ? 'X' : 'O');
                    if (vier.Turn % 2 + 1 == sp)
                    {
                        num = 0;
                        //num = vier.ai();
                        //Console.WriteLine(": " + num);
                    }
                    else
                    {
                        num = NumIn("Worauf setzen?");
                    }
                } while (vier.SetPos(num) == -1);
                vier.SetOn(num);
                Console.WriteLine();
            } while (vier.Checkwinner() == -1);
            vier.Out();
            Console.WriteLine("0123456");
            if (vier.Checkwinner() == 0)
            {
                Console.WriteLine("Unentschieden");
            }
            else
            {
                Console.WriteLine("Spieler " + vier.Checkwinner() + " hat gewonnen");
            }
        }

        private bool IsNum(string num)
        {
            try
            {
                Convert.ToInt32(num);
                return true;
            }
            catch (FormatException)
            {
                Console.WriteLine("bitte eine zahl verwenden");
                return false;
            }
        }

        private int NumIn(string output)
        {
            string inp;
            Console.WriteLine(output);
            do
            {
                inp = Console.ReadLine();
                if (inp.IndexOf('x') != -1)
                {
                    Console.WriteLine("Bye Bye!");
                    Environment.Exit(0);
                }
            } while (!IsNum(inp));
            return Convert.ToInt32(inp);
        }
    }
}
