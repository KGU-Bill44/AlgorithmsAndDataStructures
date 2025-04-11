namespace LaboratoryWorkEight;

public static class ConsoleUi
{
    private static char ExitCommandKey = '0';

    public static void Run()
    {
        PrintWelcome();
        PrintInfoTask();
        LinkedListImplController<int> controller = new LinkedListImplController<int>();
        char commandKey = default;
        int number;
        int index;

        do
        {
            try
            {
                commandKey = ReadKey();
                switch (commandKey)
                {
                    case 'h':
                        PrintInfoTask();
                        break;
                    case '1':
                        controller.CreateList();
                        break;
                    case '2':
                        number = GetNumberFromConsole("число");
                        controller.AddElementFirst(number);
                        break;
                    case '3':
                        number = GetNumberFromConsole("число");
                        controller.AddElementLast(number);
                        break;
                    case 'p':
                        PrintList(controller);
                        break;
                    case 'r':
                        PrintReversList(controller);
                        break;
                    case '5':
                        number = GetNumberFromConsole("число, которое хотите найти");
                        PrintBoolResult(controller.Contains(number));
                        break;
                    case '6':
                        index = GetNumberFromConsole("индекс элемента");
                        Console.WriteLine($"Результат поиска: {controller.GetAt(index)}");
                        break;
                    case '7':
                        index = GetNumberFromConsole("индекс элемента, перед которыми хотите вставить число");
                        number = GetNumberFromConsole("число, которое хотите вставить");
                        controller.InsertBefore(number, index);
                        break;
                    case '8':
                        index = GetNumberFromConsole("индекс элемента, после которыми хотите вставить число");
                        number = GetNumberFromConsole("число, которое хотите вставить");
                        controller.InsertAfter(number, index);
                        break;
                    case 'f':
                        controller.RemoveFirst();
                        break;
                    case 'l':
                        controller.RemoveLast();
                        break;
                    case 'b':
                        index = GetNumberFromConsole("индекс элемента, перед которого хотите удалить элемент");
                        controller.RemoveBefore(index);
                        break;
                    case 'a':
                        index = GetNumberFromConsole("индекс элемента, после которого хотите удалить элемент");
                        controller.RemoveAfter(index);
                        break;
                    case 't':
                        List<int> ints = ReadInts("целых числил");
                        bool result = controller.ContainsAll(ints);
                        PrintBoolResult(result);
                        break;
                    case 'n':
                        controller.Sort();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
                PrintInfoTask();
            }
        } while (!ExitCommandKey.Equals(commandKey));
    }

    private static void PrintBoolResult(bool contains)
    {
        Console.WriteLine(contains ? "Да" : "Нет");
    }

    private static void PrintList<T>(LinkedListImplController<T> controller) where T : IComparable
    {
        Console.WriteLine(controller.GetListString());
    }

    private static void PrintReversList<T>(LinkedListImplController<T> controller) where T : IComparable
    {
        Console.WriteLine(controller.GetReversListString());
    }

    private static void PrintWelcome()
    {
        Console.WriteLine("Приветствую!");
    }

    private static void PrintInfoTask()
    {
        Console.Write(
            "Программа читает команду:\n" +
            "h - выводит справочную информацию\n" +
            "1 - создает двунаправленный список массив\n" +
            "2 - добавляет в начало вводимое пользователем число\n" +
            "3 - добавляет в конец вводимое пользователем число\n" +
            "p - выводит список на экран\n" +
            "r - выводит список на экран в обратном порядке\n" +
            "5 - проверяет, содержится ли вводимый элемент в списке\n" +
            "6 - выводит содержимое списка по указанному индексу\n" +
            "7 - вставляет элемент перед индексом\n" +
            "8 - вставляет элемент после индекса\n" +
            "f - удаляет первый элемент из списка\n" +
            "l - удаляет последний элемент из списка\n" +
            "a - удаляет элемент после указанного индекса\n" +
            "b - удаляет элемент перед указанным индексом удаляет\n" +
            "t - является ли массив, подмассивом в листе\n" +
            "n - сортирует массив\n" +
            "0 - выходит из программы\n");
    }

    private static char ReadKey()
    {
        Console.Write("Ожидает команду: ");
        char key = KeyIsNotStringException.ThrowIfStringIsNotChar(Console.ReadLine());

        return key;
    }

    private static int GetNumberFromConsole(string nameForVariable)
    {
        Console.Write($"Введите {nameForVariable}: ");
        string anyString = Console.ReadLine();
        return int.Parse(anyString);
    }

    private static List<int> ReadInts(string arrayNumberName)
    {
        Console.Write($"Введите массив {arrayNumberName}: ");
        List<int> ints = new List<int>();

        bool isStringEmpty = true;

        do
        {
            try
            {
                string anyString = Console.ReadLine();
                isStringEmpty = string.IsNullOrWhiteSpace(anyString);
                if (!isStringEmpty)
                {
                    ints.Add(int.Parse(anyString));
                }
            }
            catch
            {
                Console.WriteLine("Ошибка, не число!");
            }
        } while (!isStringEmpty);

        return ints;
    }
}