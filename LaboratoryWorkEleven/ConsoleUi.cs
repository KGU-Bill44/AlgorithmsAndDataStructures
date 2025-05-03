using System.Text;
using System.Text.RegularExpressions;

namespace LaboratoryWorkEleven;

public class ConsoleUi
{
    public static void Run()
    {
        Console.WriteLine("Приветствую!");
        Console.WriteLine("Программа читает кириллический текстовый файл и выводит все слова и их анаграммы.");

        FileInfo fileForRead = GetFile("к файлу");
        Regex regex = new Regex("^[А-Яа-яёЁ]+$");
        Dictionary<string, List<string>> wordAndAnagrams = new Dictionary<string, List<string>>();

        if (!fileForRead.Exists)
        {
            Console.WriteLine("Ошибка: файла не существует.");
        }

        using (TextReader reader = fileForRead.OpenText())
        {
            string word = reader.ReadLine();
            while (!string.IsNullOrWhiteSpace(word) && regex.IsMatch(word))
            {
                wordAndAnagrams.Add(word, GetAnagrams(word));
                word = reader.ReadLine();
            }
        }

        StringBuilder builder = new StringBuilder();
        foreach (var pair in wordAndAnagrams)
        {
            builder.AppendLine($"{pair.Key} - {string.Join(' ', pair.Value)}");
        }

        Console.WriteLine(builder.ToString());
    }

    private static FileInfo GetFile(string desc)
    {
        Console.WriteLine("Введите полный путь " + desc + ":");
        return new FileInfo(Console.ReadLine() ?? string.Empty);
    }

    #region Trash

    public static List<string> GenerateAnagrams(string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            return new List<string> { "" };
        }

        char[] charArray = word.ToCharArray();
        Array.Sort(charArray);
        List<string> anagrams = new List<string>();
        GenerateAnagramsRecursive(charArray, 0, anagrams);
        return anagrams.Distinct().ToList();
    }

    private static void GenerateAnagramsRecursive(char[] chars, int startIndex, List<string> anagrams)
    {
        if (startIndex == chars.Length - 1)
        {
            anagrams.Add(new string(chars));
            return;
        }

        for (int i = startIndex; i < chars.Length; i++)
        {
            Swap(chars, startIndex, i);
            GenerateAnagramsRecursive(chars, startIndex + 1, anagrams);
            Swap(chars, startIndex, i);
        }
    }

    private static void Swap(char[] chars, int i, int j)
    {
        (chars[i], chars[j]) = (chars[j], chars[i]);
    }

    #endregion

    #region MyImpl

    private static List<string> GetAnagrams(string word)
    {
        List<string> resultAnagrams = new List<string>();
        List<char> chars = word.ToList();
        chars.Sort();

        GetAnagramsByChars(chars, new StringBuilder(), resultAnagrams);

        resultAnagrams.Sort();
        return resultAnagrams.Distinct().ToList();
    }

    private static void GetAnagramsByChars(List<char> chars, StringBuilder currentWord, List<string> resultAnagrams)
    {
        if (chars.Count == 0)
        {
            resultAnagrams.Add(currentWord.ToString());

            return;
        }

        for (int i = 0; i < chars.Count; i++)
        {
            char anyChar = chars[i];
            currentWord = currentWord.Append(anyChar);
            chars.Remove(anyChar);
            GetAnagramsByChars(new List<char>(chars), currentWord, resultAnagrams);
            currentWord = currentWord.Remove(currentWord.Length - 1, 1);
            chars.Insert(i, anyChar);
        }
    }

    #endregion
}