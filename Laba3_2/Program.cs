using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3_2
{
    internal class Program
    {
        // Ввод массива с клавиатуры
        static int[] ReadArray(string name)
        {
            Console.Write($"Введите размер массива {name}: ");
            int n = int.Parse(Console.ReadLine());
            if (n <= 0)
                throw new ArgumentException("Размер массива должен быть положительным.");

            int[] arr = new int[n];
            Console.WriteLine($"Введите {n} элементов массива {name}:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{name}[{i}] = ");
                arr[i] = int.Parse(Console.ReadLine());
            }
            return arr;
        }

        // Подсчёт количества нечётных элементов
        static int CountOdd(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] % 2 != 0) // нечётный
                    count++;
            return count;
        }

        // Вывод одного элемента (с окрашиванием или без)
        static void PrintElement(int value, bool highlight)
        {
            if (highlight && value % 2 != 0)
            {
                Console.ForegroundColor = ConsoleColor.Green; // зелёный для нечётных
                Console.Write(value);
                Console.ResetColor(); // возвращаем обычный цвет
            }
            else
            {
                Console.Write(value);
            }
        }

        // Вывод массива; если highlightOdd = true — нечётные элементы зелёные
        static void PrintArray(int[] arr, string name, bool highlightOdd)
        {
            Console.Write($"{name} = {{ ");
            for (int i = 0; i < arr.Length; i++)
            {
                PrintElement(arr[i], highlightOdd);
                if (i < arr.Length - 1)
                    Console.Write(", ");
            }
            Console.WriteLine(" }");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            try
            {
                // Ввод массивов
                int[] a = ReadArray("A");
                int[] b = ReadArray("B");

                // Подсчёт нечётных элементов
                int countA = CountOdd(a);
                int countB = CountOdd(b);

                Console.WriteLine($"\nКоличество нечётных в A: {countA}");
                Console.WriteLine($"Количество нечётных в B: {countB}");

                // Определяем, в каком массиве нечётных больше
                bool highlightA = countA > countB;
                bool highlightB = countB > countA;

                Console.WriteLine("\nВывод массивов:");
                PrintArray(a, "A", highlightA);
                PrintArray(b, "B", highlightB);

                // Пояснение
                if (countA == countB)
                    Console.WriteLine("\nКоличество нечётных элементов одинаково — подсветка не выполняется.");
                else if (highlightA)
                    Console.WriteLine("\nБольше нечётных в массиве A — они выделены зелёным.");
                else
                    Console.WriteLine("\nБольше нечётных в массиве B — они выделены зелёным.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: введено не целое число.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка: число слишком большое.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
