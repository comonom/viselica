using System;
using System.Threading;

namespace viselica
{
    struct Game
    {
        public string word;
        public char[] stars;
        public int count;

       internal class Program
    {
            private static Game game;
            static void Main(string[] args)
        {
                const int maxCount = 15;

                Console.Write("Введите слово:");
                string str = Console.ReadLine().ToLower();
                game.word = str;
                game.stars = new string('*', str.Length).ToCharArray();

                char symbol = ' ';
                Thread th = new Thread(() =>
                {
                    while (true)
                    {
                        Console.WriteLine(new string('-', 30));
                        NewWord(symbol);
                        Console.WriteLine("Загаданное слово " + string.Join("", game.stars));
                        Console.WriteLine(new string('-', 30));
                        Console.WriteLine("Количество попыток {0},У Вас еще осталось {1}", game.count, maxCount - game.count);
                        if (game.word.Equals(string.Join("", game.stars)))
                        {
                            Console.WriteLine("You are win!");
                            return;

                        }
                        if (game.count == maxCount)
                        {
                            Console.WriteLine("You are lose!");
                            return;
                        }

                        Thread.Sleep(200);
                        Console.Clear();
                    }
                });
                th.Start();
                Thread th2 = new Thread(() =>
                {
                    while (true)
                    {
                        symbol = (Char.ToLower(Console.ReadKey().KeyChar));
                        game.count++;
                        Thread.Sleep(300);
                    }
                });
                th2.IsBackground = true;
                th2.Start();
                Console.ReadKey(true);

            }

            static void NewWord(char s)
            {

                for (int i = 0; i < game.word.Length; i++)
                {
                    if (game.word[i] == s)
                    {
                        game.stars[i] = s;
                    }
                }
            }
        }
    }
}
    

