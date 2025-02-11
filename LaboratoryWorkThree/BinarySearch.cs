namespace LaboratoryWorkThree;

public class BinarySearch
{
    private int[] sortArray;

    public BinarySearch(int[] sortArray)
    {
        this.sortArray = sortArray;
    }

    public int FindIndex(int element)
    {
        uint lenghtOfArray = (uint)sortArray.Length;
        uint middle = lenghtOfArray / 2;
        uint leftIndex = 0;
        uint rightIndex = lenghtOfArray - 1;

        while (leftIndex <= rightIndex)
        {
            if (sortArray[middle] == element) return (int)middle;
            int elementByMiddle = sortArray[middle];
            if (elementByMiddle > element)
            {
                rightIndex = middle;
            }
            else
            {
                leftIndex = middle;
            }

            middle = leftIndex + ((rightIndex - leftIndex) >> 1);
        }

        return -1;
    }
}