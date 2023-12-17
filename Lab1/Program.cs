using ConsoleIOLib;

namespace Lab1
{
    public class Program
    {
        public static void Main()
        {
            Task1();
            Task2();
            Task3();
        }

        public static void Task1()
        {
            ConsoleIO.WriteLine("\nЗадание 1\n");

            var m = ConsoleIO.Input<int>("Введите число m: ");
            var n = ConsoleIO.Input<int>("Введите число n: ", (v) => v == 1 ? "" : null);


            --n; // "--n++" ввести невозможно, компилятор жалуется на отсутствие операнда
            var result1 = m / n++;          // m/--n++
            var result2 = m / n < n--;      // m/n<n--
            var result3 = m + n++ > n + m;  // m+n++>n+m

            ConsoleIO.WriteLine($"m = {m}; n = {n}; m/--n++ = {result1}");
            ConsoleIO.WriteLine($"m = {m}; n = {n}; m/n<n-- = {result2}");
            ConsoleIO.WriteLine($"m = {m}; n = {n}; m+n++>n+m = {result3}");


            var x = ConsoleIO.Input<double>("Введите число x: ");

            var result = Math.Pow(x, 5) * Math.Sqrt(Math.Abs(x - 1)) + Math.Abs(25 - Math.Pow(x, 5));

            ConsoleIO.WriteLine($"x = {x}; (x^5) * ((|x - 1|)^.5) + (|25 - x^5|) = {result:E}");
        }

        public static void Task2()
        {
            ConsoleIO.WriteLine("\nЗадание 2\n");

            // (-7, 0); (0, 0), (0, -1)
            const int triangleX1 = -7, triangleX2 = 0, triangleX3 = 0,
                      triangleY1 = 0, triangleY2 = 0, triangleY3 = -1;

            var pointX = ConsoleIO.Input<double>("Введите x точки: ");
            var pointY = ConsoleIO.Input<double>("Введите y точки: ");

            // (-7,0) -> (0,0)
            var top = (triangleX1 - pointX) * (triangleY2 - triangleY1) - (triangleX2 - triangleX1) * (triangleY1 - pointY);
            // (0,0) -> (0,-1)
            var right = (triangleX2 - pointX) * (triangleY3 - triangleY2) - (triangleX3 - triangleX2) * (triangleY2 - pointY);
            // (0,-1) -> (-7,0)
            var diagonal = (triangleX3 - pointX) * (triangleY1 - triangleY3) - (triangleX1 - triangleX3) * (triangleY3 - pointY);

            // Одинаковый знак или один из == 0 - принадлежит или лежит на грани
            var result = (top >= 0 && right >= 0 && diagonal >= 0) || (top <= 0 && right <= 0 && diagonal <= 0);
            var pref = result ? " " : "не ";

            ConsoleIO.WriteLine($"Точка ({pointX}, {pointY}) {pref}принадлежит заштрихованной области.");
        }

        public static void Task3()
        {
            ConsoleIO.WriteLine("\nЗадание 3\n");

            {
                const float a = 1000;
                const float b = .0001f;

                var tmp1 = (float)Math.Pow(a + b, 2);
                var tmp2 = (float)Math.Pow(a, 2);
                var tmp3 = 2 * a * b;
                var tmp4 = tmp2 + tmp3;
                var tmp5 = tmp1 - tmp4;
                var tmp6 = (float)Math.Pow(b, 2);
                var result = tmp5 / tmp6;

                ConsoleIO.WriteLine($"Результат с переменными a и b типа float: {result}");
            }
            {
                const double a = 1000;
                const double b = .0001;

                var tmp1 = Math.Pow(a + b, 2);
                var tmp2 = Math.Pow(a, 2);
                var tmp3 = 2 * a * b;
                var tmp4 = tmp2 + tmp3;
                var tmp5 = tmp1 - tmp4;
                var tmp6 = Math.Pow(b, 2);
                var result = tmp5 / tmp6;

                ConsoleIO.WriteLine($"Результат с переменными a и b типа double: {result}");
            }
        }
    }
}