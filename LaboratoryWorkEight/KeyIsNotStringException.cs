namespace LaboratoryWorkEight;

public class KeyIsNotStringException() : Exception("Строка не символ")
{
    public static char ThrowIfStringIsNotChar(string anyString)
    {
        if (string.IsNullOrEmpty(anyString) || anyString.Length > 1)
        {
            throw new KeyIsNotStringException();
        }

        return char.Parse(anyString);
    }
}