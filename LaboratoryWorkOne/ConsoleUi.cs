namespace LaboratoryWorkOne;

internal class ConsoleUi
{
    /// <summary>
    /// Вход в консолное прилоджение.
    /// </summary>
    public static void Run()
    {
        try
        {
            PrintWelcome();
            PrintInfoTask();

            int number = GetNumberFromConsole("число");
            
            Console.WriteLine("Вывод: " + NumberUtil.IsPowerOfTwo(number));
        }
        catch (FormatException e)
        {
            Console.WriteLine("Введеная строка не соответсвует формату числа");
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
    
    private static void PrintWelcome()
    {
        Console.WriteLine("Приветсвую!");
    }
    
    private static void PrintInfoTask()
    {
        Console.Write("Программа проверяет степень двойки.\n");
    }
    
    private static int GetNumberFromConsole(string nameForVarible)
    {
        Console.Write($"Введите {nameForVarible}: ");
        string anyString = Console.ReadLine();
        return int.Parse(anyString);
    }
}