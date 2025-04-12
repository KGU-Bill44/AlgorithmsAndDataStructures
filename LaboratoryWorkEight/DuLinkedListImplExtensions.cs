namespace LaboratoryWorkEight;

public static class DuLinkedListImplExtensions
{
    public static bool ContainsAll<T>(this DuLinkedListImpl<T> list, IEnumerable<T> enumerable)
    {
        List<T> anes = enumerable.ToList();
        
        if (!anes.Any())
        {
            return true;
        }

        int index = list.FindIndex(anes.First());

        if (index == -1 || index + anes.Count > list.Count)
        {
            return false;
        }

        for (int i = 0; i < anes.Count(); i++)
        {
            if (!list[i + index].Equals(anes[i]))
            {
                return false;
            }
        }

        return true;
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