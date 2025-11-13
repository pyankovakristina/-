using System;
using System.IO;
using System.Globalization;

class Program
{
    static void Main()
    {
        // Устанавливаем культуру для корректного отображения десятичных разделителей
        CultureInfo culture = CultureInfo.InvariantCulture;

        // Создаем или перезаписываем файл "f.txt"
        using (StreamWriter writer = new StreamWriter("f.txt"))
        {
            // Записываем заголовок
            writer.WriteLine("x\tsin(x)");

            // Записываем значения x и sin(x) от 0 до 1 с шагом 0.1
            for (double x = 0; x <= 1.0; x += 0.1)
            {
                // Округляем x до одного знака после запятой для избежания ошибок округления
                double roundedX = Math.Round(x, 1);
                double sinX = Math.Sin(roundedX);

                // Записываем значения в файл, используя точку как разделитель
                writer.WriteLine($"{roundedX.ToString("F1", culture)}\t{sinX.ToString("F6", culture)}");
            }
        }

        Console.WriteLine("Файл 'f.txt' успешно создан!");
    }
}