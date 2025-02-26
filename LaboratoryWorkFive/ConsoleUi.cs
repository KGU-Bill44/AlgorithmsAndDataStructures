namespace LaboratoryWorkFive;

public class ConsoleUi
{
    public static void Run()
    {
        PrintWelcome();
        PrintInfoTask();

        QueueImplController<int> controller = new QueueImplController<int>();

        while (true)
        {
            char commandIndex = ReadCommand();
            bool isExit = false;
            int n = 0;
            int[] ints = null;

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
                        n = GetNumberFromConsole("размер очереди");
                        ints = ReadArrayBy(n);
                        controller.CreateQueue(ints);
                        break;
                    case '2':
                        n = GetNumberFromConsole("размер очереди, которую хотите проверить");
                        ints = ReadArrayBy(n);
                        Console.WriteLine(controller.Includes(ints));
                        break;
                    case '3':
                        n = GetNumberFromConsole("коэффициент увеличителя");
                        controller.Scale(n);
                        break;
                    case '4':
                        PrintQueue(controller);
                        break;
                    default:
                        PrintInfoTask();
                        break;
                }
            }
            catch (Exception e)
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
        Console.WriteLine("Приветсвую!");
    }

    private static void PrintInfoTask()
    {
        Console.Write("Программа читает команду:\n" +
                      "h - выводит справочную информацию\n" +
                      "1 - создает вводимую пользователем последовательность, для дальнейших действий\n" +
                      "2 - проверяет на равенство 2 последовательности: 1 - которая активна с новой \n" +
                      "3 - умножает элемент с числом вводимым из клавиатуры\n" +
                      "4 - выводит последовательность на экран\n" +
                      "0 - выходит из программы\n");
    }

    private static int GetNumberFromConsole(string nameForVarible)
    {
        Console.Write($"Введите {nameForVarible}: ");
        string anyString = Console.ReadLine();
        return int.Parse(anyString);
    }

    private static void PrintQueue(QueueImplController<int> controller)
    {
        string stackString = controller.GetStackContentString();
        Console.WriteLine(stackString);
    }
}