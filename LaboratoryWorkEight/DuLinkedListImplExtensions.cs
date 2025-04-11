namespace LaboratoryWorkEight;

public static class DuLinkedListImplExtensions
{
    public static bool ContainsAll<T>(this DuLinkedListImpl<T> list, IEnumerable<T> enumerable)
    {
        return enumerable.All(list.Contains);
    }

    public static void Sort<T>(this DuLinkedListImpl<T> list) where T : IComparable
    {
        int index = 0;
        

        while (index < list.Count)
        {
            T element = list[index];
            
            int lestIndex = 0;
            while (lestIndex < index)
            {
                if (list[lestIndex].CompareTo(element) < 0)
                {
                    lestIndex = lestIndex + 1;
                    continue;
                }
                list.InsertBefore(element, lestIndex);
                list.RemoveAfter(index);
                break;
            }

            index = index + 1;
        }
    }
}