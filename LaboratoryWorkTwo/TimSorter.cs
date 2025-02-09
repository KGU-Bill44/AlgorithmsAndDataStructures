namespace LaboratoryWorkTwo;

public class TimSorter
{
    private int[] sortableArray;
    private int minrun;
    private List<int[]> runs = new List<int[]>();

    private const int UPPER_BOUND_OF_UNCOMPUTABLE_N = 64;

    public TimSorter(int[] sortableArray)
    {
        this.sortableArray = sortableArray;
    }

    public int[] Sort()
    {
        if (sortableArray.Length < 2)
        {
            return sortableArray;
        }

        minrun = CalculateMinrun();
        runs = SplittingAnArray();
        List<List<int>> replateRuns = ResizeByMinrun();
        runs = InsertionSort(replateRuns);
        

        return DistributeTreeAndAssembleSinglePiece();;
    }

    private int CalculateMinrun()
    {
        int length = sortableArray.Length;

        if (length < UPPER_BOUND_OF_UNCOMPUTABLE_N)
        {
            return length;
        }

        int additionalUnit = 0;
        while (length >= UPPER_BOUND_OF_UNCOMPUTABLE_N)
        {
            additionalUnit = additionalUnit | (length & 1);
            length = length >> 1;
        }

        return length + additionalUnit;
    }

    private List<int[]> SplittingAnArray()
    {
        List<int[]> runs = new List<int[]>();
        SortingMode currentSortMode = SortingMode.UNCLEAR;
        int currentRunStart = 0;

        for (int currentElementIndex = 1;
             currentElementIndex < sortableArray.Length;
             currentElementIndex++)
        {
            SortingMode nextMode = GetSortingModeBy(sortableArray, currentElementIndex - 1, currentElementIndex);
            bool isEnd = currentElementIndex >= sortableArray.Length - 1;
            if (currentSortMode == SortingMode.UNCLEAR)
            {
                currentSortMode = nextMode;
                currentRunStart = currentElementIndex - 1;
            }

            if (currentSortMode == nextMode)
            {
                if (isEnd)
                {
                    int[] run2 = sortableArray[currentRunStart..(currentElementIndex + 1)];
                    if (currentSortMode == SortingMode.DECREASING)
                    {
                        run2 = run2.Reverse().ToArray();
                    }

                    runs.Add(run2);
                }

                continue;
            }

            int[] run = sortableArray[currentRunStart..(currentElementIndex)];

            if (currentSortMode == SortingMode.DECREASING)
            {
                run = run.Reverse().ToArray();
            }

            runs.Add(run);

            if (isEnd)
            {
                runs.Add(new int[] { sortableArray[currentElementIndex] });
            }

            currentSortMode = SortingMode.UNCLEAR;
        }

        return runs;
    }

    private SortingMode GetSortingModeBy(int[] array, int firstIndex, int secondIndex)
    {
        return array[firstIndex] > array[secondIndex] ? SortingMode.DECREASING : SortingMode.INCREASING;
    }

    private List<List<int>> ResizeByMinrun()
    {
        List<List<int>> replateRuns = runs.Select(run => run.ToList()).ToList();

        int indexCurrentRun = 0;
        List<int> currentRun = replateRuns[indexCurrentRun];
        List<int> nextRun = replateRuns[indexCurrentRun + 1];

        while (true)
        {
            if (indexCurrentRun + 1 >= replateRuns.Count)
            {
                break;
            }
            
            if (currentRun.Count >= minrun)
            {
                indexCurrentRun = indexCurrentRun + 1;
                currentRun = replateRuns[indexCurrentRun];
            }
            
            nextRun = replateRuns[indexCurrentRun + 1];

            int missingDimension =  minrun - currentRun.Count;

            if (missingDimension >= nextRun.Count)
            {
                currentRun.AddRange(nextRun);
                replateRuns.Remove(nextRun);
            }
            else
            {
                currentRun.AddRange(nextRun.GetRange(0, missingDimension));
            }
        }

        return replateRuns;
    }

    private List<int[]> InsertionSort(List<List<int>> replateRuns)
    {
        return replateRuns.ConvertAll(rr => new InsertionSorter(rr.ToArray()).Sort());
    }

    private int[] DistributeTreeAndAssembleSinglePiece()
    {
        DistributedTree tree = new DistributedTree();
        
        runs.ForEach(run => tree.Add(run));
        return tree.UnionByMin();
    }

    private enum SortingMode
    {
        UNCLEAR,
        INCREASING,
        DECREASING
    }
}