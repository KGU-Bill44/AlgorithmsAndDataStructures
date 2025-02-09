namespace LaboratoryWorkTwo;

internal class ConsoleUi
{
    /// <summary>
    /// Вход в консолное прилоджение.
    /// </summary>
    public static void Run()
    {
        try
        {
            int number = GetNumberFromConsole("количество элементов в массиве");
            if (number < 0) throw new Exception("Количество элементов не может быть меньше нуля");
            int[] unsortArray = FillRandomArray(number);
            Print(unsortArray);
            int[] sortArray = new TimSorter(unsortArray).Sort();
            Print(sortArray);
        }
        catch (FormatException e)
        {
            Console.WriteLine("Введеная строка не соответсвует формату числа");
        }
        catch (OverflowException e)
        {
            Console.WriteLine("Число вышло за рамки допустимых значений");
        }
    }

    private static void Print(int[] sortArray)
    {
        Console.WriteLine(string.Join(", ", sortArray));
        Console.WriteLine();
    }

    private static int GetNumberFromConsole(string nameForVarible)
    {
        Console.Write($"Введите {nameForVarible}: ");
        string anyString = Console.ReadLine();
        return int.Parse(anyString);
    }

    private static int[] FillRandomArray(int number)
    {
        int[] array = new int[number];
        Random random = new Random();

        for (int i = 0; i < number; i++)
        {
            array[i] = random.Next(100, 200);
        }
        
        return array;
    }
}