using System;

public class NumberValidator
{
    public static int ValidateAndParse(string input)
    {
        // Проверка на пустую строку или null
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Входная строка не может быть пустой или null");

        // Проверка, является ли строкой числа
        if (!IsNumericString(input))
            throw new FormatException("Введенная строка не является числом");

        // Попытка преобразования с обработкой переполнения
        try
        {
            int result = int.Parse(input);
            return result;
        }
        catch (OverflowException)
        {
            // Определяем, положительное или отрицательное переполнение
            if (IsPositiveOverflow(input))
                throw new OverflowException("Введено слишком большое число (больше 2,147,483,647)");
            else
                throw new OverflowException("Введено слишком маленькое число (меньше -2,147,483,648)");
        }
    }

    private static bool IsNumericString(string input)
    {
        // Удаляем пробелы в начале и конце
        input = input.Trim();

        // Проверяем первый символ (может быть минусом)
        if (input.Length == 0) return false;

        int startIndex = 0;
        if (input[0] == '-')
        {
            if (input.Length == 1) return false; // Только минус
            startIndex = 1;
        }

        // Проверяем, что все остальные символы - цифры
        for (int i = startIndex; i < input.Length; i++)
        {
            if (!char.IsDigit(input[i]))
                return false;
        }

        return true;
    }

    private static bool IsPositiveOverflow(string input)
    {
        input = input.Trim();

        // Если число отрицательное, то переполнение отрицательное
        if (input[0] == '-')
            return false;

        // Сравниваем с максимальным значением int
        string maxInt = "2147483647";

        // Если длина больше, точно переполнение
        if (input.Length > maxInt.Length)
            return true;

        // Если длина равна, сравниваем посимвольно
        if (input.Length == maxInt.Length)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > maxInt[i])
                    return true;
                if (input[i] < maxInt[i])
                    break;
            }
        }

        return false;
    }
}

// Основная программа
class Program
{
    static void Main()
    {
        Console.WriteLine("Валидатор целых чисел");
        Console.WriteLine("=====================");

        while (true)
        {
            Console.Write("\nВведите число (или 'exit' для выхода): ");
            string input = Console.ReadLine();

            if (input?.ToLower() == "exit")
                break;

            try
            {
                int number = NumberValidator.ValidateAndParse(input);
                Console.WriteLine($"✅ Успешно: {number}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"❌ Ошибка: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"❌ Ошибка формата: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"❌ Ошибка переполнения: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Неожиданная ошибка: {ex.Message}");
            }
        }
    }
}