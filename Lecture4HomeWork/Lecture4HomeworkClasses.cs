using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lecture4HomeWorkClasses
{
    public class Task1
    {
        private int[] arr { get; set; }

        public Task1()
        {
            arr = new int[20];
            Random rnd = new Random();

            for (int i = 0; i < 20; i++)
            {
                arr[i] = rnd.Next(-10000, 10000);
            }
        }

        public int[] GetArray()
        {
            return arr;
        }

        public int FindPairValuesMod3()
        {
            int pairCount = 0;

            for (int i = 0; i < 19; i++)
            {
                if (arr[i] % 3 == 0 && arr[i + 1] % 3 == 0)
                {
                    pairCount++;
                }
            }
            return pairCount;
        }

    }

    public class Task2
    {
        private int[] arr;
        private int arrLength;
        private int arrStartValue;
        private int arrValueStep;

        private Task2()
        { }

        public Task2(int arrLength, int arrStartValue, int arrValueStep)
        {
            this.arrLength = arrLength;
            this.arrValueStep = arrValueStep;
            this.arrStartValue = arrStartValue;

            this.arr = new int[this.arrLength];
            this.arr[0] = this.arrStartValue;

            for (int i = 1; i < this.arrLength; i++)
            { 
                this.arrStartValue += this.arrValueStep;
                this.arr[i] = this.arrValueStep;
            }
        }

        public Task2(string inputFilePath)
        {
            List<string> inputArr = File.ReadAllLines(inputFilePath).ToList();
            this.arr = new int[inputArr.Count];
            this.arrLength = inputArr.Count;

            for (int i = 0; i < inputArr.Count; i++)
            {
                this.arr[i] = int.Parse(inputArr[i]);
            }
        }

        public int[] GetArray()
        {
            return arr;
        }

        public string MaxCount()
        {
            this.arr = this.arr.OrderByDescending(x => x).ToArray();
            int maxVal = arr[0];
            int countMaxVal = 0;

            for (int i = 1; i < this.arrLength; i++)
            {
                if (maxVal == arr[i])
                {
                    countMaxVal++;
                }
            }

            string outputStr = "Максимальное значение в массиве: " + maxVal + " и встречается в количестве: " + countMaxVal + " раз.";
            return outputStr;
        }

        public int Summ()
        {
            int summ = 0;

            for (int i = 0; i < this.arrLength; i++)
            {
                summ += this.arr[i];
            }

            return summ;
        }

        public void Inverse()
        {
            for (int i = 0; i < this.arrLength; i++)
            {
                this.arr[i] *= -1;
            }
        }

        public void Multi(int value)
        {
            for (int i = 0; i < this.arrLength; i++)
            {
                this.arr[i] *= value;
            }
        }

        public void OutputToFile(string outputFilePath)
        {
            string[] strArr = new string[this.arrLength];

            for (int i = 0; i < this.arrLength; i++)
            {
                strArr[i] = this.arr[i].ToString();
            }

            File.WriteAllLines(outputFilePath, strArr);
        }

    }

    public static class Task3
    {
        /// <summary>
        /// Метод проверки введенных данных пользователя на корректность.
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns></returns>
        /// 

        private static string[,] logPassArray;
        private static string inputLogPassTextFilePath = @"C:\logPass.txt";
        private static int arrLength;

        static Task3()
        {
            string[] strArr = File.ReadAllLines(inputLogPassTextFilePath);
            logPassArray = new string[2, strArr.Length];
            arrLength = strArr.Length;

            for (int i = 0; i < strArr.Length; i++)
            {
                string[] tempArr = strArr[i].Split(' ').Where(x => x != "").ToArray();
                logPassArray[0, i] = tempArr[0]; //Логин
                logPassArray[1, i] = tempArr[1]; //Ппроль
            }
        }

        private static bool Validation(string login, string password)
        {
            bool valid = false;

            for (int i = 0; i < arrLength; i++)
            {
                if (login.Equals(logPassArray[0, i]) && password.Equals(logPassArray[1, i]))
                {
                    valid = true;
                }
            }
            return valid;
        }

        /// <summary>
        /// Метод предоставляющий интерфейс для ввода данных пользователя (логина и пароля)
        /// </summary>
        public static void LoginPasswordValidation()
        {
            int i = 0;
            bool result = false;

            do
            {
                Console.Write("Логин: ");
                string login = Console.ReadLine();
                Console.Write("Пароль: ");
                string password = Console.ReadLine();
                if (Task3.Validation(login, password) == false)
                {
                    Console.WriteLine("Введен неверный логин или пароль. У вас осталось {0} попытки(а).", 2 - i);
                }
                else
                {
                    result = true;
                    Console.WriteLine("Добро пожаловать в систему, root!");
                    break;
                }
                i++;
            } while (i < 3 || result != true);

            if (result == false) { Console.WriteLine("Доступ в систему заблокирован."); }
            Console.ReadKey();
        }
    }

    public class Task4
    {
        private int[,] arr;
        private int maxVal;
        private int minVal;


        private Task4()
        { }

        public Task4(string pathFileWithValues)
        {
            string[] strInput = File.ReadAllLines(pathFileWithValues);

            if (strInput.Length > 0)
            {
                int lengthColumns = strInput[0].Split(' ').Length;
                int lengthRows = strInput.Length;
                this.arr = new int[lengthColumns, lengthRows];

                for (int i = 0; i < lengthColumns; i++)
                {
                    string[] currentRowArr = strInput[i].Split(' ');
                    for (int j = 0; j < lengthRows; j++)
                    {
                        this.arr[i, j] = Convert.ToInt32(currentRowArr[j]);
                    }
                }
            }
        }

        public Task4(int lengthColumns, int lengthRows)
        {
            this.arr = new int[lengthColumns, lengthRows];
            Random rnd = new Random();
            this.maxVal = 0;
            this.minVal = 0;

            for (int i = 0; i < lengthColumns; i++)
            {
                for (int j =  0; j < lengthRows; j++)
                {
                    this.arr[i, j] = rnd.Next(-100, 100);
                    if (this.maxVal < this.arr[i, j]) { this.maxVal = this.arr[i, j]; }
                    if (this.minVal > this.arr[i, j]) { this.minVal = this.arr[i, j]; }
                }
            }
        }

        public int Summ()
        {
            int summ = 0;
            for (int i = 0; i < this.arr.GetLength(0); i++)
            {
                for (int j = 0; j < this.arr.GetLength(1); j++)
                {
                    summ += this.arr[i, j];
                }
            }

            return summ;
        }

        public int Summ(int startValue)
        {
            int summ = 0;
            for (int i = 0; i < this.arr.GetLength(0); i++)
            {
                for (int j = 0; j < this.arr.GetLength(1); j++)
                {
                    if (this.arr[i, j] > startValue)
                    {
                        summ += this.arr[i, j];
                    }
                }
            }

            return summ;
        }

        public int[] FindMaxValCoordinates()
        {
            int[] outputVal = new int[2];
            for (int i = 0; i < this.arr.GetLength(0); i++)
            {
                for (int j = 0; j < this.arr.GetLength(1); j++)
                {
                    if (this.maxVal == this.arr[i, j])
                    {
                        outputVal[0] = i;
                        outputVal[1] = j;
                    }
                }
            }
            return outputVal;
        }

        public void ArrToFile(string outputFilePath)
        {
            string[] outputStr = new string[this.arr.GetLength(1)];
            for (int i = 0; i < this.arr.GetLength(0); i++)
            {
                string tempStr = String.Empty;
                for (int j = 0; j < this.arr.GetLength(1); j++)
                {
                    tempStr += this.arr[i, j] + " ";
                }
                outputStr[i] = tempStr;
                tempStr = String.Empty;
            }
            File.WriteAllLines(outputFilePath, outputStr);
        }

        public int[,] GetArray()
        {
            return arr;
        }

        public int GetMin()
        {
            return minVal;
        }

        public int GetMax()
        {
            return maxVal;
        }
    }
}
