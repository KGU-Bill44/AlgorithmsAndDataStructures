namespace LaboratoryWorkOne;

public static class NumberUtil
{
    public static bool IsPowerOfTwo(int number)
    {
        if (number < 1)
        {
            throw new ArgumentException("Число не натуральнеое.");
        }
        
        if (number == 1)
        {
            return true;
        }

        if (number % 2 == 0)
        {
            return IsPowerOfTwo(number / 2);
        }
        else
        {
            return false;
        }
    }
}