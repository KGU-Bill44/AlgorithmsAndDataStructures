namespace LaboratoryWorkTwo;

public class InsertionSorter
{
    private int[] sortableArray;

    private int overwrittenElement;
    private int overwrittenElementIndex;

    public InsertionSorter(int[] sortableArray)
    {
        this.sortableArray = sortableArray;
        ResetOverwrittenElement();
    }

    public int[] Sort()
    {
        if (sortableArray.Length < 2)
        {
            return sortableArray;
        }

        for (int indexOfUnsortedElement = 0; indexOfUnsortedElement < sortableArray.Length; indexOfUnsortedElement++)
        {
            IfLessInsertAndMove(indexOfUnsortedElement);
        }

        return sortableArray;
    }

    private void IfLessInsertAndMove(int indexOfMovedElement)
    {
        int movedElement = sortableArray[indexOfMovedElement];
        InsertIfLess(movedElement, indexOfMovedElement);
        ShiftTo(indexOfMovedElement);
        ResetOverwrittenElement();
    }

    private void InsertIfLess(int movedElement, int endIndexSearch)
    {
        for (int index = 0; index <= endIndexSearch; index++)
        {
            if (sortableArray[index] > movedElement)
            {
                overwrittenElement = sortableArray[index];
                overwrittenElementIndex = index;
                sortableArray[index] = movedElement;
                break;
            }
        }
    }

    private void ShiftTo(int indexOfMovedElement)
    {
        if (overwrittenElementIndex == -1) return;

        int lostElement = overwrittenElement;

        for (int index = overwrittenElementIndex + 1; index <= indexOfMovedElement; index++)
        {
            (sortableArray[index], lostElement) = (lostElement, sortableArray[index]);
        }
    }

    private void ResetOverwrittenElement()
    {
        overwrittenElement = -1;
        overwrittenElementIndex = -1;
    }
}