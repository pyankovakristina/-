using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Пузырьковая сортировка массива");
        Console.WriteLine("==============================");

        // Ввод размера массива
        Console.Write("Введите размер массива: ");
        int n = int.Parse(Console.ReadLine());

        // Создание и заполнение массива
        int[] array = new int[n];
        Console.WriteLine("\nВведите элементы массива:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Элемент {i + 1}: ");
            array[i] = int.Parse(Console.ReadLine());
        }

        // Вывод исходного массива
        Console.WriteLine("\nИсходный массив:");
        PrintArray(array);

        // Пузырьковая сортировка
        BubbleSort(array);

        // Вывод отсортированного массива
        Console.WriteLine("\nОтсортированный массив:");
        PrintArray(array);
    }

    // Метод пузырьковой сортировки
    static void BubbleSort(int[] array)
    {
        int n = array.Length;

        // Делаем n проходов по массиву
        for (int i = 0; i < n; i++)
        {
            // Проходим по массиву, сравнивая соседние элементы
            for (int j = 0; j < n - 1; j++)
            {
                // Если порядок неправильный, меняем элементы местами
                if (array[j] > array[j + 1])
                {
                    // Обмен элементов
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }

            // Выводим состояние массива после каждого прохода
            Console.WriteLine($"После прохода {i + 1}: {string.Join(" ", array)}");
        }
    }

    // Метод для вывода массива
    static void PrintArray(int[] array)
    {
        Console.WriteLine(string.Join(" ", array));
    }
}