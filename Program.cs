/* Задача 1: Напишите программу, которая на вход принимает позиции 
элемента в двумерном массиве, и возвращает значение этого элемента 
или же указание, что такого элемента нет.

Задача 2: Задайте двумерный массив. Напишите программу, 
которая поменяет местами первую и последнюю строку массива.

Задача 3: Задайте прямоугольный двумерный массив. 
Напишите программу, которая будет находить строку с 
наименьшей суммой элементов.

Задача 4*(не обязательная): Задайте двумерный массив из целых чисел. 
Напишите программу, которая удалит строку и столбец, на пересечении которых 
расположен наименьший элемент массива. Под удалением понимается создание 
нового двумерного массива без строки и столбца. */


using System.Data;

namespace Tasks
{
    static class Program
    {
        public static void Main (string [] args)
        {
            Console.Clear();
            string stringLoad = "Введите номер задачи (от 1 до 4) => ";
            System.Console.Write(stringLoad);
            Tasks(NumberInTerminal(4,stringLoad));
        }
        static void Tasks(int num)
        {
            switch (num)
            {
                case 1:
                {
                    Console.WriteLine("Задача 1: Напишите программу, которая на вход принимает позиции");
                    Console.WriteLine("элемента в двумерном массиве, и возвращает значение этого элемента");
                    Console.WriteLine("или же указание, что такого элемента нет.");
                    Task1();
                    break;
                }
                case 2:
                {
                    Console.WriteLine("Задайте двумерный массив. Напишите программу,");
                    Console.WriteLine("которая поменяет местами первую и последнюю строку массива.");
                    Task2();
                    break;
                }
                case 3:
                {
                    Console.WriteLine("Задача 3: Задайте прямоугольный двумерный массив.");
                    Console.WriteLine("Напишите программу, которая будет находить строку с");
                    Console.WriteLine("наименьшей суммой элементов.");
                    Task3();
                    break;
                }
                case 4:
                {
                    Console.WriteLine("Задайте двумерный массив из целых чисел.");
                    Console.WriteLine("Напишите программу, которая удалит строку и столбец, на пересечении которых");
                    Console.WriteLine("расположен наименьший элемент массива. Под удалением понимается создание");
                    Console.WriteLine("нового двумерного массива без строки и столбца.");
                    Task4();
                    break;
                }
                default:
                {
                    Console.WriteLine("Какая то ошибка в номере вводимой задачи");
                    break;
                }

            }
        }
        static void Task1()
        {
            string repeatStringRows = "Введите номер строки (до 999999)";
            string repeatStringCols = "Введите номер столбца (до 999999)";
            Console.WriteLine("Массив из чисел от 1 до 100 => ");
            int [,] array = CreateArray(5,5,1,100);
            PrintArray(array);
            Console.WriteLine(repeatStringRows);
            int rows = NumberInTerminal(999999,repeatStringRows);
            Console.WriteLine(repeatStringCols);
            int cols = NumberInTerminal(999999,repeatStringCols);
            if (rows >= array.GetLength(0) || cols >= array.GetLength(1))
            {
                Console.WriteLine($"Элемента array[{rows},{cols}] нет в массиве");
            }
            else 
            {
                Console.WriteLine($"Элемент array[{rows},{cols}] = {array[rows,cols]}");
            }
        }
        static void Task2()
        {
            Console.WriteLine("Массив из чисел от 1 до 100 => ");
            int [,] array = CreateArray(5,5,1,100);
            PrintArray(array);
            Console.WriteLine("Массив модифицированный => ");
            PrintArray(ModArray(array));
        }
        static void Task3()
        {
            Console.WriteLine("Прямоугольный Массив 5х5 из чисел от 1 до 100 => ");
            int [,] array = CreateArray(5,5,1,10);
            PrintArray(array);
            Console.WriteLine($"Строка с наименьшей суммой элементов => {FindMinSumRow(array)}");
        }

        static void Task4()
        {
            Console.WriteLine("Массив из целых чисел от 1 до 100 => ");
            int [,] array = CreateArray(5,5,1,100);
            PrintArray(array);  

        }

        static int [,] FindMinItemArray(int [,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            int [,] modArray = new int [rows-1,cols-1];
            int minItem = array[0,0];
            int [] item = new int [2];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (array[i,j] < minItem)
                    {
                        minItem = array[i,j];
                        item[0] = i;
                        item[1] = j;
                    }
                }
            }
            // Нашли координаты минимального числа в массиве

        }

        static int FindMinSumRow(int [,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            int [] sum = new int [cols];
            int minSum = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sum[i] += array[i,j];
                }
            }
//            Console.WriteLine("Суммы строк");
//            for (int i = 0; i < sum.Length; i++)
//            {
//                Console.Write(sum[i] + " ");
//            }
//            Console.WriteLine();
            minSum = sum[0];
            int index = 0;
            for (int i = 1; i < cols; i++)
            {
                if (sum[i] < minSum)
                {
                    index = i;
                    minSum = sum[i];
                }
            }
            return index+1;
        }
        static int [,] ModArray(int [,] array)
        {
            
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            int value = 0;
            for (int j = 0; j < cols; j++)
                {
                    value = array[0,j];
                    array[0,j] = array[rows-1,j];
                    array[rows-1,j] = value;
                }
            return array; 
        }
        static int [,] CreateArray(int rows, int cols, int min, int max)
        {
            int [,] array = new int [rows,cols];
            Random rand = new();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i,j] = rand.Next(min, max+1);    
                }
                
            }
            return array;
        }
        static void PrintArray(int [,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                Console.Write("[");
                for (int j = 0; j < cols; j++)
                {
                Console.Write(array[i,j]);
                if (j < cols - 1){Console.Write(", ");}  
                }
                Console.WriteLine("]");
            }
        }
        /*Функция ввода чисел в терминале*/
        public static int NumberInTerminal(int numberDigits, string repeatString)
        {
            string ? numString = Console.ReadLine();
            int numInt = 0;
            while ((!Int32.TryParse(numString,out numInt)) 
                    || !(numInt > 0) 
                    || !(numInt <= numberDigits)
                  )
            {
                System.Console.WriteLine("Ошибка ввода, повторите");
                System.Console.Write(repeatString);
                numString = Console.ReadLine(); 
            }
            return numInt;
        }        
    }
}