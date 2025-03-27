namespace LaboratoryWorkSeven;

public static class LinkedListImplExtension
{
    public static void InsertIfEven<T>(this LinkedListImpl<T> list, T element)
    {
        int halfSize = list.Count / 2;

        if (list.Count % 2 == 0)
        {
            list.InsertBefore(element, halfSize);
        }
    }
}