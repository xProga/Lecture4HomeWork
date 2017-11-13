using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Lecture4HomeWorkClasses;

namespace Lecture4HomeWork
{
    class Task2UserInterface
    {
        public static void MainWindow()
        {
            ConsoleKeyInfo selectedTask;
            var rule = @"[1-2]";
            Task2 t2;

            Console.WriteLine("Уважаемый пользователь, вы хотите сгенерировать массив или загрузить его из файла?");
            Console.WriteLine("\t1. Сгенерировать.");
            Console.WriteLine("\t2. Загрузить из файла.");
            selectedTask = Console.ReadKey(true);
            if (Regex.IsMatch(selectedTask.KeyChar.ToString(), rule))
            {
                switch (selectedTask.KeyChar)
                {
                    case '1':
                        t2 = GenerateArray();
                        Actions(t2);
                        break;
                    case '2':
                        t2 = LoadFromFile();
                        Actions(t2);
                        break;
                }
            }
        }

        private static void GetArrayOnScreen(Task2 t2)
        {
            int[] arr = t2.GetArray();
            string arrStr = String.Empty;

            for (int i = 0; i < arr.Length; i++)
            {
                arrStr += arr[i] + " ";
            }
            Console.WriteLine(arrStr);
            Console.ReadKey();
        }

        private static Task2 GenerateArray()
        {
            Console.Write("Введите размерность массива, начальное значение, а так же шаг приращения, через запятую: ");
            string[] inputString = Console.ReadLine().Split(' ', ',').Where(x => x != "").ToArray(); 
            Task2 t2 = new Task2(int.Parse(inputString[0]), int.Parse(inputString[1]), int.Parse(inputString[2]));

            GetArrayOnScreen(t2);

            return t2;
        }

        private static Task2 LoadFromFile()
        {
            Task2 t2 = new Task2(@"C:\arr.txt");

            GetArrayOnScreen(t2);

            return t2;
        }

        private static void Actions(Task2 t2)
        {
            ConsoleKeyInfo selectedTask;
            var rule = @"[1-5]";

            Console.WriteLine("Уважаемый пользователь, какую операцию вы хотите проделать с массивом?");
            Console.WriteLine("\t1. Вернуть сумму элементов массива.");
            Console.WriteLine("\t2. Изменить знаки у всех элементов массива.");
            Console.WriteLine("\t3. Умножить каждый элемент массива на заданное число.");
            Console.WriteLine("\t4. Узнать максимальный элемент и количество таковых в массиве.");
            Console.WriteLine("\t5. Записать массив в файл.");
            selectedTask = Console.ReadKey(true);
            if (Regex.IsMatch(selectedTask.KeyChar.ToString(), rule))
            {
                switch (selectedTask.KeyChar)
                {
                    case '1':
                        Console.WriteLine("Сумма элементов массива равна: " + t2.Summ());
                        break;
                    case '2':
                        t2.Inverse();
                        Console.WriteLine("Знаки элементов массива изменены!");
                        GetArrayOnScreen(t2);
                        break;
                    case '3':
                        Console.Write("Укажите на какое число необходимо умножить элементы массива?");
                        t2.Multi(int.Parse(Console.ReadLine()));
                        GetArrayOnScreen(t2);
                        break;
                    case '4':
                        string outputStr = t2.MaxCount();
                        Console.WriteLine(outputStr);
                        Console.ReadKey();
                        break;
                    case '5':
                        Console.Write("Укажите путь до файла, в который необходимо сохранить массив: ");
                        t2.OutputToFile(Console.ReadLine());
                        break;
                }
            }
        }
    }

    class Task4UserInterface
    {
        public static void MainWindow()
        {
            ConsoleKeyInfo selectedTask;
            var rule = @"[1-2]";
            Task4 t4;

            Console.WriteLine("Уважаемый пользователь, вы хотите сгенерировать массив или загрузить его из файла?");
            Console.WriteLine("\t1. Сгенерировать.");
            Console.WriteLine("\t2. Загрузить из файла.");
            selectedTask = Console.ReadKey(true);
            if (Regex.IsMatch(selectedTask.KeyChar.ToString(), rule))
            {
                switch (selectedTask.KeyChar)
                {
                    case '1':
                        t4 = GenerateArray();
                        Actions(t4);
                        break;
                    case '2':
                        t4 = LoadFromFile();
                        Actions(t4);
                        break;
                }
            }
        }

        private static void GetArrayOnScreen(Task4 t4)
        {
            int[,] arr = t4.GetArray();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                string outputStr = String.Empty;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    outputStr += arr[i, j] + " ";
                }
                Console.WriteLine(outputStr);
            }
            Console.ReadKey();
        }

        private static Task4 GenerateArray()
        { 
            Task4 t4;
            Console.Write("Введите размерность массива по-горизонтали и по-вертикали, через запятую: ");
            string[] inputVal = Console.ReadLine().Split(' ', ',').Where(x => x != "").ToArray();

            t4 = new Task4(int.Parse(inputVal[0]), int.Parse(inputVal[1]));

            GetArrayOnScreen(t4);

            return t4;
        }

        private static Task4 LoadFromFile()
        {
            Task4 t4;
            Console.Write("Укажите путь к файлу из которого необходимо загрузить массив: ");
            t4 = new Task4(Console.ReadLine());

            GetArrayOnScreen(t4);

            return t4;
        }

        private static void Actions(Task4 t4)
        {
            ConsoleKeyInfo selectedTask;
            var rule = @"[1-2]";

            Console.WriteLine("Уважаемый пользователь, какую операцию вы хотите проделать с массивом?");
            Console.WriteLine("\t1. Вернуть сумму элементов массива.");
            Console.WriteLine("\t2. Вернуть сумму элементов массива при значениях больше указанного.");
            Console.WriteLine("\t3. Получить минимальный элемент массива.");
            Console.WriteLine("\t4. Получить максимальный элемент массива.");
            Console.WriteLine("\t5. Записать массив в файл.");
            selectedTask = Console.ReadKey(true);
            if (Regex.IsMatch(selectedTask.KeyChar.ToString(), rule))
            {
                switch (selectedTask.KeyChar)
                {
                    case '1':
                        Console.WriteLine("Сумма элементов массива равна: " + t4.Summ());
                        break;
                    case '2':
                        Console.Write("Укажите значение при котором все элементы больше оного будут суммироваться: ");
                        int summ = t4.Summ(int.Parse(Console.ReadLine()));
                        Console.WriteLine("Сумма значений при заданном условии: " + summ);
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.Write("Минимальный элемент массива: " + t4.GetMin());
                        Console.ReadKey();
                        break;
                    case '4':
                        int[] outputValMaxCoord = t4.FindMaxValCoordinates();
                        Console.Write("Максимальный элемент массива: " + t4.GetMax() + " и находится на позиции с координатами: x = " + outputValMaxCoord[0] + " y = " + outputValMaxCoord[1]);
                        Console.ReadKey();
                        break;
                    case '5':
                        Console.Write("Укажите путь до файла, в который необходимо сохранить массив: ");
                        t4.ArrToFile(Console.ReadLine());
                        break;
                }
            }
        }
    }

    class Program
    {
        public static void TaskN1()
        {
            Task1 t1 = new Task1();
            int[] arr = t1.GetArray();
            Console.WriteLine("Созданный массив:");

            for (int i = 0; i < 20; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Количество парных элементов с делителем 3 найдено: " + t1.FindPairValuesMod3());
            Console.ReadKey();
        }

        public static void TaskN2()
        {
            Task2UserInterface.MainWindow();
        }

        public static void TaskN3()
        {
            Task3.LoginPasswordValidation();
        }

        public static void TaskN4()
        {
            Task4UserInterface.MainWindow();
        }

        static void Main(string[] args)
        {
            ConsoleKeyInfo selectedTask;
            var rule = @"[1-4]";

            Console.WriteLine("Добрый день, уважаемый пользователь. Демонстрацию работы какой программы вы бы хотели увидеть?");
            Console.WriteLine("\t1. Программа нахождения пар чисел в линейном массиве.");
            Console.WriteLine("\t2. Программа работы с одномерным массивом.");
            Console.WriteLine("\t3. Программа проверки логинов/паролей с возможностью подгрузки оных из файла.");
            Console.WriteLine("\t4. Программа работы с двумерным массивом.");
            selectedTask = Console.ReadKey(true);
            if (Regex.IsMatch(selectedTask.KeyChar.ToString(), rule))
            {
                switch (selectedTask.KeyChar)
                {
                    case '1':
                        TaskN1();
                        break;
                    case '2':
                        TaskN2();
                        break;
                    case '3':
                        TaskN3();
                        break;
                    case '4':
                        TaskN4();
                        break;
                }
            }
        }
    }
}
