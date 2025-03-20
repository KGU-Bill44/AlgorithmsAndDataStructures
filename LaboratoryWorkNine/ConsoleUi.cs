namespace LaboratoryWorkNine;

public static class ConsoleUi
{
    public static void Run()
    {
        PrintWelcome();
        PrintInfoTask();
        TreeImplController<int> controller = new TreeImplController<int>();

        while (true)
        {
            char commandIndex = ReadCommand();
            bool isExit = false;

            try
            {
                TreeBranch[] path;
                switch (commandIndex)
                {
                    case 'h':
                        PrintInfoTask();
                        break;
                    case '0':
                        isExit = true;
                        break;
                    case '1':
                        controller.CreateTree();
                        break;
                    case '2': 
                        path = ReadPath();
                        TreeBranch setNode = ReadNodeDirection();
                        int content = GetNumberFromConsole("значение ноды");
                        controller.SetContent(content, setNode, path);
                        break;
                    case '3':
                        path = ReadPath();
                        controller.DeleteNode(path);
                        break;
                    case '4':
                        
                        break;
                    case '5':
                        
                        break;
                    case '6':
                        PrintQueue(controller);
                        break;
                    default:
                        PrintInfoTask();
                        break;
                }
            }
            catch (TreeNullException ex)
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

    private static TreeBranch ReadNodeDirection()
    {
        Console.WriteLine("Вввдениет П - правйы узел или Л - левый узел. Иначе ошибка.");
        string? nodeS = Console.ReadLine();
        if (nodeS != null) return CharConvert(nodeS);

        throw new EmptyStringException();
    }

    private static TreeBranch CharConvert(string nodeS)
    {
        if (string.IsNullOrWhiteSpace(nodeS) 
            || nodeS.Length > 1)
        {
            throw new StringNotCharException();
        }

        char pathAsChar = char.ToUpper(nodeS[0]);

        return pathAsChar switch
        {
            'Л' => TreeBranch.Left,
            'П' => TreeBranch.Right,
            _ => throw new ArgumentException()
        };
    }

    private static TreeBranch[] ReadPath()
    {
        Console.WriteLine(
            "Для построения пути к узнул, необходимо поочережно, перез пробел вводить П - правйы узел или Л - левый узел.\n"
        );

        string? anyString = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(anyString))
        {
            throw new EmptyStringException();
        }

        List<string> pathAsString = new List<string>(anyString.Split(" "));
        return pathAsString.ConvertAll(CharConvert).ToArray();
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

    private static int GetNumberFromConsole(string nameForVariable)
    {
        try
        {
            Console.Write($"Введите {nameForVariable}: ");
            string? anyString = Console.ReadLine();
            return int.Parse(anyString);
        }
        catch (Exception)
        {
            throw new Exception("Не получилось преобразовать сторку в число");
        }
    }

    private static void PrintQueue<T>(TreeImplController<T> controller)
    {
        string contentString = controller.GetContentString();
        Console.WriteLine(contentString);
    }
}