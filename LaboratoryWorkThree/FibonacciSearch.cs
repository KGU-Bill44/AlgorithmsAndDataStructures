namespace LaboratoryWorkThree;

public class FibonacciSearch
{
    private int[] sortArray;

    public FibonacciSearch(int[] sortArray)
    {
        this.sortArray = sortArray;
    }

    public int FindIndex(int element)
    {
        int leftIndexElement = 0;
        int rightIndexElement = 1;

        while (sortArray.Length - 1 > rightIndexElement
               && sortArray[rightIndexElement] <= element)
        {
            (leftIndexElement, rightIndexElement) = (rightIndexElement, leftIndexElement + rightIndexElement);
        }

        if (rightIndexElement < sortArray.Length)
        {
            for (int returnElementIndex = leftIndexElement;
                 returnElementIndex <= rightIndexElement;
                 returnElementIndex++)
            {
                if (sortArray[returnElementIndex] == element)
                {
                    return returnElementIndex;
                }
            }
        }

        return -1;
    }
}