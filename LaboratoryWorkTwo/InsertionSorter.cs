namespace LaboratoryWorkTwo;

public class InsertionSorter
{
    private int[] sortableArray;

    public InsertionSorter(int[] sortableArray)
    {
        this.sortableArray = sortableArray;
    }

    public int[] Sort()
    {
        if (sortableArray.Length < 2)
        {
            return sortableArray;
        }

        for (int indexOfUnsortedElement = 0;
             indexOfUnsortedElement < sortableArray.Length - 1;
             indexOfUnsortedElement++)
        {
            int element = sortableArray[indexOfUnsortedElement];
            int sortIndex = indexOfUnsortedElement - 1;

            while (sortIndex >= 0 && sortableArray[sortIndex] > element)
            {
                sortableArray[sortIndex + 1] = sortableArray[sortIndex];
                sortIndex = sortIndex - 1;
            }

            sortableArray[sortIndex + 1] = element;
        }

        return sortableArray;
    }
}