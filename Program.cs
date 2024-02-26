namespace ZADANIE_8
{
    internal class Program
    {
        static void Main()
        {
            bool exit = false;
            while (!exit)
            {
                VvodCoordinat();

                Console.WriteLine("Введите 'exit' для выхода:");
                string exitword = Console.ReadLine();
                if (exitword == "exit")
                    exit = true;
            }
        }

        // Функция рисования шахматной доски.
        static void DrawChessboard(int oneX, int oneY, int twoX, int twoY)
        {
            Console.WriteLine("  a b c d e f g h");
            for (int i = 8; i >= 1; i--)
            {
                Console.Write(i + " ");
                for (int j = 1; j <= 8; j++)
                {
                    if ((j == oneX && i == oneY) || (j == twoX && i == twoY))
                        Console.Write((j == oneX && i == oneY) ? "1 " : "2 ");
                    else
                        Console.Write((j + i) % 2 == 0 ? "- " : "/ ");
                }
                Console.WriteLine();
            }
        }

        // Функция ввода и проверки данных.
        static void VvodCoordinat()
        {
            bool vvod_reght;
            do
            {
                Console.Write("Введите координаты белой фигуры (XY) + " +
                    " черной фигуры (XY) + (итоговые XY) (например: ферзь a1 слон b3 f4): ");
                string[] coordinat = Console.ReadLine()?.Split(' ');

                vvod_reght = coordinat?.Length == 5
                    && coordinat[1] != coordinat[3]
                    && CorrectPosition(coordinat[1])
                    && CorrectPosition(coordinat[3])
                    && CorrectPosition(coordinat[4])
                    && CorrectFigura(coordinat[0])
                    && CorrectFigura(coordinat[2]);

                if (vvod_reght)
                    SameColor(coordinat[0], coordinat[1]);

            } while (!vvod_reght);
        }

        // Функция сравнения координат 1 и 2 позиции.
        static void SameColor(string first, string second)
        {
            int firstX = first[0] - 'a' + 1;
            int firstY = first[1] - '0';
            int secondX = second[0] - 'a' + 1;
            int secondY = second[1] - '0';

            DrawChessboard(firstX, firstY, secondX, secondY);

            Console.WriteLine((firstX + firstY) % 2 == (secondX + secondY) % 2
                ? "Выбранные поля одного цвета"
                : "Выбранные поля разных цветов");
        }

        // Функция проверки на правильность ввода.
        static bool CorrectPosition(string position)
        {
            if (position.Length != 2)
                return false;

            char bokva = position[0];
            char numer = position[1];

            return bokva >= 'a' && bokva <= 'h' && numer >= '1' && numer <= '8';
        }

        static bool CorrectFigura(string figura)
        {
            string[] figurs = { "ладья", "конь", 
                "слон", "ферзь", "король" };
            for (int i = 0; i < figurs.Length; i++)
            {
                if (figurs[i] == figura)
                    return true;
            }
            return false;
        }
    }
}