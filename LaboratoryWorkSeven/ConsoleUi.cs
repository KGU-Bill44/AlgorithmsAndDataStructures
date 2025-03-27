namespace LaboratoryWorkSeven;

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
                    case '4':
                        PrintList(controller);
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
                        index = GetNumberFromConsole("индекс элемента, после которого хотите удалить элемент");
                        controller.RemoveBefore(index);
                        break;
                    case 'a':
                        index = GetNumberFromConsole("индекс элемента, перед которого хотите удалить элемент");
                        controller.RemoveAfter(index);
                        break;
                    case 't':
                        number = GetNumberFromConsole("число, которое хотите вставить в середину");
                        controller.InsertIfEven(number);
                        break;
                    case 'n':
                        controller.RemoveEqualNeighbors();
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

    private static void PrintList<T>(LinkedListImplController<T> controller)
    {
        Console.WriteLine(controller.GetListString());
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
            "1 - создает однонаправленный массив\n" +
            "2 - добавляет в начало вводимое пользователем число\n" +
            "3 - добавляет в конец вводимое пользователем число\n" +
            "4 - выводит список на экран\n" +
            "5 - проверяет, содержится ли вводимый элемент в списке\n" +
            "6 - выводит содержимое списка по указанному индексу\n" +
            "7 - вставляет элемент перед индексом\n" +
            "8 - вставляет элемент после индекса\n" +
            "f - удаляет первое первый элемент из списка\n" +
            "l - удаляет последний первый элемент из списка\n" +
            "a - удаляет элемент перед указанным индексом\n" +
            "b - удаляет элемент после указанного индекса\n" +
            "t - вставляет элемент в середину если количество элементов четное\n" +
            "n - удаляет соседние элементы\n" +
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
}