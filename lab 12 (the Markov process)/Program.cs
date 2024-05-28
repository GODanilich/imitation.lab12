

namespace lab_12__the_Markov_process_
{
    public class Program
    {
        public static readonly double[,] matrix = new double[3, 3]
        {
            { 0.3, 0.25, 0.45 },
            { 0.1, 0.7, 0.2 },
            { 0.6, 0.1, 0.3 }
        };
        public static readonly int startPos = 0;
        public static readonly Random random = new();
        public static int currentPoint = startPos;
        public static int i;

        public static int NextMarkovProcessPoint()
        {
            var randomNumber = random.NextDouble();
            if (randomNumber < matrix[currentPoint, 0])
            {
                return 0;
            }
            randomNumber -= matrix[currentPoint, 1];
            if (randomNumber < matrix[currentPoint, 1])
            {
                return 1;
            }
            return 2;
        }
        public static void ImpericalP()
        {
            int[] p = new int[3];
            for (int i = 0; i < 10000; i++)
            {
                for (int j = 0; j < 10000; j++)
                {
                    currentPoint = NextMarkovProcessPoint();
                }
                if(i % 1000 == 0)
                {
                    Console.WriteLine($" Моделирование завершено на: {i / 100}%");
                }
                p[currentPoint]++;
            }
            Console.WriteLine(
                $"p0 = {p[0] / 10000.0};\n" +
                $"p1 = {p[1] / 10000.0};\n" +
                $"p2 = {p[2] / 10000.0};\n");
        }
        public static void Main()
        {
            Console.WriteLine("Симуляция марковской цепи.");
            Console.WriteLine($"Симуляция начинается с точки {startPos}");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        ImpericalP();
                        break;

                    case ConsoleKey.P:
                        i++;
                        currentPoint = NextMarkovProcessPoint();
                        Console.WriteLine($"Шаг {i}. Новое состояние: {currentPoint}");
                        break;

                    case ConsoleKey.Escape:
                        // Закрытие программы при нажатии клавиши ESC
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }
            }
        }
    }
}