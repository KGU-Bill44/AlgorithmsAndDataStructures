namespace LaboratoryWorkThree;

internal class ConsoleUi
{
    /// <summary>
    /// Вход в консолное прилоджение.
    /// </summary>
    public static void Run()
    {
        try
        {
            int number = GetNumberFromConsole("длину массива");
            int[] sortArray = CreateSortedArrayByLenght(number);
            FibonacciSearch search = new FibonacciSearch(sortArray);
            int desiredNumber = GetNumberFromConsole("число, которое хотите найти");
            int desiredNumberIndex = search.FindIndex(desiredNumber);

            if (desiredNumberIndex == -1)
            {
                Console.WriteLine("Числа нет в списке");
            }
            else
            {
                Console.WriteLine("Оно находится на позиции: " + desiredNumberIndex);
            }
        }
        catch (FormatException e)
        {
            Console.WriteLine("Введенная строка не соответствует формату числа");
        }
        catch (OverflowException e)
        {
            Console.WriteLine("Число вышло за рамки допустимых значений");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }

    private static int[] CreateSortedArrayByLenght(int lenght)
    {
        int[] sortArray = new int[lenght];

        for (int i = 0; i < lenght; i++)
        {
            sortArray[i] = i + 1;
        }

        return sortArray;
    }

    private static void PrintWelcome()
    {
        Console.WriteLine("Приветствую!");
    }
    
    private static int GetNumberFromConsole(string nameForVarible)
    {
        Console.Write($"Введите {nameForVarible}: ");
        string anyString = Console.ReadLine();
        return int.Parse(anyString);
    }
}