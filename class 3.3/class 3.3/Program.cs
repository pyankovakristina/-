using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите строку для преобразования:");
        string input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input))
        {
            string result = ShiftCharacters(input);
            Console.WriteLine($"Результат: {result}");
        }
        else
        {
            Console.WriteLine("Введена пустая строка");
        }
    }

    static string ShiftCharacters(string input)
    {
        char[] chars = input.ToCharArray();

        for (int i = 0; i < chars.Length; i++)
        {
            // Сдвиг на 1 символ вперед в русской раскладке
            if (chars[i] >= 'а' && chars[i] < 'я')
                chars[i] = (char)(chars[i] + 1);
            else if (chars[i] == 'я')
                chars[i] = 'а';
            else if (chars[i] >= 'А' && chars[i] < 'Я')
                chars[i] = (char)(chars[i] + 1);
            else if (chars[i] == 'Я')
                chars[i] = 'А';
            // Для английских букв
            else if (chars[i] >= 'a' && chars[i] < 'z')
                chars[i] = (char)(chars[i] + 1);
            else if (chars[i] == 'z')
                chars[i] = 'a';
            else if (chars[i] >= 'A' && chars[i] < 'Z')
                chars[i] = (char)(chars[i] + 1);
            else if (chars[i] == 'Z')
                chars[i] = 'A';
        }

        return new string(chars);
    }
}