using System.Text.RegularExpressions;

namespace LaboratoryWorkTen;

public class Regal
{
    public string CalculateCyrillic(string s)
    {
        SortedDictionary<char, int> chars = new SortedDictionary<char, int>();
        Regex regex = new Regex("[А-Яа-яёЁ]");
        foreach (Match match in regex.Matches(s))
        {
            char kirChar = match.Value[0];
            if (!chars.TryAdd(kirChar, 1))
            {
                chars[kirChar] = chars[kirChar] + 1;
            }
        }

        return string.Join('\n', chars.Select(c => $"{c.Key} - {c.Value}"));
    }

    public string ReplaceDate(string s)
    {
        Regex regex = new Regex(@"(\d\d)\/(\d\d)\/\d\d(\d\d)");
        return regex.Replace(s, "$1:$2:$3");
    }
}