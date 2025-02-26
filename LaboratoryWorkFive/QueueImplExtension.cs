using System.Numerics;

namespace LaboratoryWorkFive;

public static class QueueImplExtension
{
    public static bool Includes<T>(this QueueImpl<T> first, QueueImpl<T> second)
    {
        T[] arrayByFirst = first.ToArray();
        T[] arrayBySecond = second.ToArray();
        int indexOfMatches = 0;

        foreach (T elementF in arrayByFirst)
        {
            if (indexOfMatches >= arrayBySecond.Length)
            {
                return true;
            }

            if (arrayBySecond[indexOfMatches].Equals(elementF))
            {
                indexOfMatches = indexOfMatches + 1;
            }
            else
            {
                indexOfMatches = 0;
            }
        }

        return indexOfMatches == arrayBySecond.Length;
    }

    public static void Scale<T>(this QueueImpl<T> first, T scale) where T : IMultiplyOperators<T, T, T>
    {
        int count = first.Count;

        for (int iter = 0; iter < count; iter++)
        {
            first.Push(first.Take() * scale);
        }
    }
}