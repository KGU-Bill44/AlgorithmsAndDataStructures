namespace LaboratoryWorkFour;

public class ConsoleUi
{
    public static void Run()
    {
        PrintWelcome();
        PrintInfoTask();

        while (true)
        {
            char commandIndex = ReadCommand();
            bool isExit = false;

            switch (commandIndex)
            {
                case 'h':
                    PrintInfoTask();
                    break;
                case '0':
                    isExit = true;
                    break;
                case '1':
                    int n = GetNumberFromConsole("размер стека");
                    EnginController.CreateEngin(n);
                    break;
                case '2':
                    EnginController.PutMaximumAtEnd();
                    break;
                case '3':
                    EnginController.PutMinMaxAtFirstEnd();
                    break;
                case '4':
                    PrintStack();
                    break;
                default:
                    PrintInfoTask();
                    break;
            }

            if (isExit)
            {
                break;
            }
        }
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
        Console.WriteLine("Приветсвую!");
    }

    private static void PrintInfoTask()
    {
        Console.Write("Программа читает команду:\n" +
                      "h - выводит справочную информацию\n" +
                      "1 - создает пустой стек и заполняет его случайными числам\n" +
                      "2 - переставляет максимальный элемент в конец стека\n" +
                      "3 - переставляет максимальный и минимальный элементы в конец и начало стека соответсвенно\n" +
                      "4 - вывести стек на экран\n" +
                      "0 - выходит из программы\n");
    }

    private static int GetNumberFromConsole(string nameForVarible)
    {
        Console.Write($"Введите {nameForVarible}: ");
        string anyString = Console.ReadLine();
        return int.Parse(anyString);
    }

    private static void PrintStack()
    {
        string stackString = EnginController.GetStackContentString();
        Console.WriteLine(stackString);
    }
}