namespace LaboratoryWorkSix;

public static class DequeImplExtended
{
    public static void Sort<T>(this DequeImpl<T> queue, IComparer<T> comparer)
    {
        T[] array = queue.ToArray();
        Array.Sort(array, comparer);
        queue.Clear();
        queue.ToAccept(array);
    }

    public static GroupedDeque<int> GroupingByDigit(this DequeImpl<int> queue)
    {
        DequeImpl<int> singleDigitNumbers = new DequeImpl<int>();
        DequeImpl<int> twoDigitNumbers = new DequeImpl<int>();
        DequeImpl<int> remainingNumbers = new DequeImpl<int>();

        foreach (int number in queue)
        {
            if (number / 10 == 0)
            {
                singleDigitNumbers.InsertLast(number);
            }
            else if (number / 100 == 0)
            {
                twoDigitNumbers.InsertLast(number);
            }
            else
            {
                remainingNumbers.InsertLast(number);
            }
        }

        return new GroupedDeque<int>(singleDigitNumbers, twoDigitNumbers, remainingNumbers);
    }
}