using System;

namespace viselica
{
    class Program
    {
        static string word;
        const int maxTrying = 11;

        static void Main(string[] args)
        {
            while (true)
            {
                do
                {
                    Console.WriteLine("Загадайте слово");
                    word = Console.ReadLine();
                } while (word.Length==0||word.Contains(' '));
                Console.Clear();
                Console.WriteLine("Игра началась!");

                for (int i = maxTrying; i > 0; i--)
                {
                     char c = ReadCharFromConsole();
                    
                    Console.WriteLine("Количество оставшихся попыток:" + (i-1)); 
                    //Console.WriteLine(c); 
                }

                Console.WriteLine("Проигрыш");
                Console.WriteLine("Загаданное слово:" + word);
                Console.ReadLine();

            }
        }

        static char ReadCharFromConsole()
        {
            Console.WriteLine("Введите символ:");
            char c = (char)0;
            do
            {
                string str = Console.ReadLine();
                if (str.Length != 1)
                {
                    Console.WriteLine("Введите один символ:");
                }
                else
                {
                    c = str[0];
                }
            } while (c == 0);

            return c;
        }
    }
}
