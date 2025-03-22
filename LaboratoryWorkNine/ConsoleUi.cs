using System.Numerics;

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
                        PrintUnbalancedTree(controller);
                        break;
                    case '5':
                        PrintSum(controller);
                        break;
                    case '6':
                        PrintTree(controller);
                        break;
                    case '7':
                        controller.Swap();
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

    private static void PrintSum<T>(TreeImplController<T> controller) where T : IAdditionOperators<T, T, T>
    {
        Console.WriteLine("Сумма элементов: " + controller.GetSum());
    }

    private static void PrintUnbalancedTree<T>(TreeImplController<T> controller) where T : IAdditionOperators<T, T, T>
    {
        Console.WriteLine("Содержимое не сбалансированных узлов: " + controller.GetUnbalancedData());
    }

    private static TreeBranch ReadNodeDirection()
    {
        Console.WriteLine("Вввдениет П - правйы узел или Л - левый узел, для создания " +
                          "элемента узла. Пустая строка - корень дерева. " +
                          "Иначе ошибка.");
        string? nodeS = Console.ReadLine();
        return !string.IsNullOrWhiteSpace(nodeS) ? CharConvert(nodeS) : TreeBranch.This;
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
            _ => throw new ArgumentException("Сивол не Л и не П.")
        };
    }

    private static TreeBranch[] ReadPath()
    {
        Console.WriteLine(
            "Для построения пути к узнул, необходимо поочережно, " +
            "перез пробел вводить П - правйы узел или Л - левый узел. " +
            "Пустая строка воспринимается как корень дерева."
        );

        string? anyString = Console.ReadLine();

        List<string> pathAsString = !string.IsNullOrWhiteSpace(anyString)
            ? new List<string>(anyString.Split(" "))
            : new List<string>();
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
                      "1 - создает дерево\n" +
                      "2 - задает значение ноды по вводимому пути (сам путь, выбрать сторону дерева, значение)\n" +
                      "3 - удаление значение ноды по вводимиму пути \n" +
                      "4 - выводит значение несбалансированных узлов дерева\n" +
                      "5 - выводит сумму элементов дерева\n" +
                      "6 - выводит дерево на экран\n" +
                      "7 - инвертироует дерево\n" +
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

    private static void PrintTree<T>(TreeImplController<T> controller) where T : IAdditionOperators<T, T, T>
    {
        string contentString = controller.GetContentString();
        Console.WriteLine(contentString);
    }
}