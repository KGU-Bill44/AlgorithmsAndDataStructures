using LaboratoryWorkFive;

namespace LaboratoryWorkSix;

public class ConsoleUi
{
    public static void Run()
    {
        PrintWelcome();
        PrintInfoTask();
        DequeImplController controller = new DequeImplController();

        while (true)
        {
            char commandIndex = ReadCommand();
            bool isExit = false;
            int n = 0;
            int[] ints;
            
            try
            {
                switch (commandIndex)
                {
                    case 'h':
                        PrintInfoTask();
                        break;
                    case '0':
                        isExit = true;
                        break;
                    case '1':
                        n = GetNumberFromConsole("размер дека");
                        ints = ReadArrayBy(n);
                        controller.CreateQueue(ints);
                        break;
                    case '2':
                        controller.Sort();
                        break;
                    case '3':
                        Console.WriteLine(controller.GroupingByDigit());
                        break;
                    case '4':
                        PrintQueue(controller);
                        break;
                    default:
                        PrintInfoTask();
                        break;
                }
            }
            catch (CollectionNullException ex)
            {
                Console.WriteLine(ex.Message);
                PrintInfoTask();
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка!");
                PrintInfoTask();
            }

            if (isExit)
            {
                break;
            }
        }
    }

    private static int[] ReadArrayBy(int lenght)
    {
        int[] ints = new int[lenght];
        for (int index = 0; index < lenght; index++)
        {
            ints[index] = GetNumberFromConsole($"{index} элемент массива");
        }

        return ints;
    }

    private static char ReadCommand()
    {
        Console.Write("Ожидание команды: ");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        Console.WriteLine();
        return keyInfo.KeyChar;
    }

    private static void PrintWelcome()
    {
        Console.WriteLine("Приветствую!");
    }

    private static void PrintInfoTask()
    {
        Console.Write("Программа читает команду:\n" +
                      "h - выводит справочную информацию\n" +
                      "1 - создает вводимую пользователем последовательность дека для дальнейших действий\n" +
                      "2 - сортировка дека \n" +
                      "3 - группировка дека\n" +
                      "4 - выводит дек на экран\n" +
                      "0 - выходит из программы\n");
    }

    private static int GetNumberFromConsole(string nameForVarible)
    {
        Console.Write($"Введите {nameForVarible}: ");
        string anyString = Console.ReadLine();
        return int.Parse(anyString);
    }

    private static void PrintQueue(DequeImplController controller)
    {
        string contentString = controller.GetContentString();
        Console.WriteLine(contentString);
    }
}