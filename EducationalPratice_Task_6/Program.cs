using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPratice_Task_6
{
    class Program
    {
        /*
         * 10.	Ввести а1, а2, а3, N.
         * Построить последовательность чисел ак = 13* ак–1 – 10* ак-2 + ак–3.
         * Построить N элементов последовательности проверить, образуют ли элементы, стоящие на четных местах, возрастающую подпоследовательность.
         */
        static void checkMas(int[] mas)
        {
            int number = mas[0];
            bool status = true;
            for (int i = 1; i < mas.Length; i++)
                if (mas[i] > number)
                    number = mas[i];
                else
                {
                    status = false;
                    break;
                }

            Console.WriteLine(status ? "Последовательность возрастает" : "Последовательность убывает");
        }

		/// <summary>
        /// Функция вычисления последовательности 
        /// </summary>
        /// <param name="a1"> первое число</param>
        /// <param name="a2">второе число</param>
        /// <param name="a3">третье число</param>
        /// <param name="size">размер</param>
        /// <param name="counter">счетчик</param>
        /// <param name="mas">массив для добавления элементов</param>
        static void SequencePoint(int a1, int a2, int a3, int size, ref int counter, ref int[] mas)
        {
            if (size != counter)
            {
                int end = a3 * 13 - 10 * a2 * a1;
                mas[counter] = end;
                counter++;
                SequencePoint(a2, a3, end, size, ref counter, ref mas);
            }
            else
                Console.WriteLine("Последовательность закончена");
        }
		
        /// <summary>
        /// Вычисление значение под четными номерами
        /// </summary>
        /// <param name="mas"></param>
        static List<int> BuildSequence(int[] mas)
        {
            List<int> check = new List<int>();//Список для записи значений под четными номерами
            for (var index = 0; index < mas.Length; index++)
            {
                if (index % 2 != 0)
                    check.Add(mas[index]);
                Console.Write($"{mas[index]} ");
            }
            Console.WriteLine("\n-----");
            //Печать последовательности
            foreach (int value in check)
                Console.Write($" {value} ");

            Console.WriteLine();
            return check;//Возращение списка для проверки
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 1 член последовательности");
            int a1 = MyLibary.Input.Int();
            Console.WriteLine("Введите 2 член последовательности");
            int a2 = MyLibary.Input.Int();
            Console.WriteLine("Введите 3 член последовательности");
            int a3 = MyLibary.Input.Int();
            Console.WriteLine("Введите размер последовательности");
            int N = MyLibary.Input.Int();
            Console.WriteLine($"Последовательность  {a1}    {a2}    {a3} ");
            int counter = 0;
            int[] mas = new int[N];//Массив для элементов под последовательности
            SequencePoint(a1, a2, a3, N, ref counter, ref mas);//Рекурсивное нахождение членов последовательности
            BuildSequence(mas);//Печать и проверка последовательности
            checkMas(mas);
            Console.Read();
        }
    }
}
