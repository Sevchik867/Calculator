using System.Linq.Expressions;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lesson4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            taskCycle1();
            taskCycle2();
            taskCycle3();

            int columns, rows;
            bool succesColumn, succesRow;
            Random rnd = new Random();
            var counts = new Dictionary<int, int>();
            var list = new List<int>(3);
            HashSet<int> listHash = new HashSet<int>();

            Console.Write("Введите кол-во строк матрицы: ");
            succesColumn = int.TryParse(Console.ReadLine(), out columns);
            Console.Write("Введите кол-во столбцов матрицы: ");
            succesRow = int.TryParse(Console.ReadLine(), out rows);
            int[,] array = new int[columns, rows];
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    array[i, j] = rnd.Next(-9, 9);
                }
            }

            taskArray1(columns, rows, array);
            taskArray2(array);
            taskArray3(columns, rows, array);
            taskArray4(counts, array);

            taskList1(rnd, list);
            taskList2(list);
            taskList3(list);
            taskList4(list, listHash);
        }

        private static void taskList4(List<int> list, HashSet<int> listHash)
        {
            Console.WriteLine("\nЛисты. Задание 4.");
            listHash.UnionWith(list);
            foreach (int item in listHash)
            {
                Console.Write($"{item} ");
            }
        }

        private static void taskList3(List<int> list)
        {
            Console.WriteLine("\nЛисты. Задание 3.");
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0) { list[i] = list[i] * 2; }
                if (list[i] % 2 != 0) { list[i] = 0; }
            }
            foreach (int item in list)
            {
                Console.Write($"{item} ");
            }
        }

        private static void taskList2(List<int> list)
        {
            Console.WriteLine("\nЛисты. Задание 2.");
            list.Add(5);
            list.Remove(3);
            foreach (int item in list)
            {
                Console.Write($"{item} ");
            }
        }

        private static void taskList1(Random rnd, List<int> list)
        {
            Console.WriteLine("\nЛисты. Задание 1.");
            for (int i = 0; i < list.Capacity; i++)
            {
                int value = rnd.Next(10);
                list.Add(value);
            }
            foreach (int item in list)
            {
                Console.Write($"{item} ");
            }
        }

        private static void taskArray4(Dictionary<int, int> counts, int[,] array)
        {
            Console.WriteLine("\nМассивы. Задание 4.");
            foreach (var number in array)
            {
                if (!counts.ContainsKey(number)) counts.Add(number, 1);
                else counts[number] += 1;
            }
            foreach (var pair in counts)
            {
                Console.WriteLine(pair.Key + ": " + pair.Value);
            }
        }

        private static void taskArray3(int columns, int rows, int[,] array)
        {
            Console.WriteLine("\nМассивы. Задание 3.");
            for (int i = 0; i < columns; ++i)
            {
                if (i % 2 != 0)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        if (array[i, j] % 2 == 1)
                        {
                            Console.Write(array[i, j] + 1 + "\t");
                        }
                        else { Console.Write(array[i, j] + "\t"); }
                    }
                }
                if (i % 2 == 0)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        if (array[i, j] % 2 == 0)
                        {
                            Console.Write(array[i, j] + 1 + "\t");
                        }
                        else { Console.Write(array[i, j] + "\t"); }
                    }
                }
                Console.WriteLine("\n");
            }
        }

        private static void taskArray2(int[,] array)
        {
            Console.WriteLine("\nМассивы. Задание 2.");
            var countPlus = array.Cast<int>().Where(i => i > 0).Count();
            var countMinus = array.Cast<int>().Where(i => i < 0).Count();
            var countZero = array.Cast<int>().Where(i => i == 0).Count();
            Console.WriteLine("Количество положительных чисел: " + countPlus + "\nКоличество отрицательных чисел: " + countMinus +
                "\nКоличество нулей: " + countZero);
        }

        private static void taskArray1(int columns, int rows, int[,] array)
        {
            Console.WriteLine("\nМассивы. Задание 1.");
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
        }

        private static void taskCycle3()
        {
            Console.WriteLine("\nЦиклы. Задание 3.");
            int firstNumber = 0, secondNumber = 1, sum = 0;
            Console.Write($"{0} {1} ", firstNumber, secondNumber);
            for (int i = 0; i <= 10; i++)
            {
                sum = firstNumber + secondNumber;
                Console.Write(sum + " ");
                firstNumber = secondNumber;
                secondNumber = sum;
            }
            Console.Write("\n");
        }

        private static void taskCycle2()
        {
            Console.WriteLine("\nЦиклы. Задание 2.");
            bool succes;
            int number;
            inputNumberCycle(out succes, out number);
            if (succes)
            {
                for (int i = 1; i < 7; i++)
                {
                    Console.Write(number * i + " ");
                }
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }

        private static void taskCycle1()
        {
            Console.WriteLine("Циклы. Задание 1.");
            bool succes;
            int number;
            inputNumberCycle(out succes, out number);
            if (number < 0)
            {
                while (number < 0)
                {
                    Console.Write(number + " ");
                    number++;
                }
            }
            if (number > 0)
            {
                while (number > 0)
                {
                    Console.Write(number + " ");
                    number--;
                }
            }
            if (!succes)
            {
                Console.WriteLine("Неверный ввод");
            }
        }

        private static void inputNumberCycle(out bool succes, out int number)
        {
            Console.Write("Введите число N: ");
            succes = int.TryParse(Console.ReadLine(), out number);
        }

    }
}
