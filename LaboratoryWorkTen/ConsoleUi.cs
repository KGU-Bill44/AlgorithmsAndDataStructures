namespace LaboratoryWorkTen;

public static class ConsoleUi
{
    private static readonly ConsoleKey ExitCommandKey = ConsoleKey.D0;

    public static void Run()
    {
        PrintWelcome();
   
        ConsoleKey commandKey = default;
        Regal regal = new Regal();

        do
        {
            PrintInfoTask();
            try
            {
                commandKey = ReadKey();
                switch (commandKey)
                {
                    case ConsoleKey.C:
                        FileInfo fileForRead = GetFile("к файлу для чтения");
                        DirectoryInfo directoryForWrite = GetDirectory("к директории для записи");

                        if (!fileForRead.Exists || !directoryForWrite.Exists)
                        {
                            Console.WriteLine("Пути не существует!");
                            break;
                        }

                        StreamReader reader = fileForRead.OpenText();
                        string textInFile = reader.ReadToEnd();
                        reader.Close();
                        
                        string result = regal.CalculateCyrillic(textInFile);
                        textInFile = regal.ReplaceDate(textInFile);
                        
                        FileInfo info = new FileInfo(Path.Combine(directoryForWrite.FullName, "result.txt"));
                        TextWriter stream = info.CreateText();
                        stream.Write(result);
                        stream.Close();

                        TextWriter writer = fileForRead.CreateText();
                        writer.Write(textInFile);
                        writer.Close();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
                break;
            }
            Console.Clear();
        } while (!ExitCommandKey.Equals(commandKey));
    }

    private static FileInfo GetFile(string desc)
    {
        Console.WriteLine("Введите путь " + desc + ":");
        return new FileInfo(Console.ReadLine() ?? string.Empty);
    }

    private static DirectoryInfo GetDirectory(string desc)
    {
        Console.WriteLine("Введите путь " + desc + ":");
        return new DirectoryInfo(Console.ReadLine() ?? string.Empty);
    }

    private static void PrintWelcome()
    {
        Console.WriteLine("Приветствую!");
    }

    private static void PrintInfoTask()
    {
        Console.Write(
            "Программа читает команду:\n" +
            "C - полный путь к файлу и путь директории для результата. В файле result - будут подчитаны все символы " +
            "кириллицы, а в исходном файле заменены даты с \\ на : .\n");
    }

    private static ConsoleKey ReadKey()
    {
        Console.Write("Ожидает команду: ");
        ConsoleKey key = Console.ReadKey().Key;
        Console.WriteLine();
        return key;
    }
}