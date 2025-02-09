namespace LaboratoryWorkTwo;

public class TimSorter
{
    private List<int> sortableArray;
    private int minrun;
    private List<List<int>> runs = new List<List<int>>();

    private const int UPPER_BOUND_OF_UNCOMPUTABLE_N = 64;

    public TimSorter(int[] sortableArray)
    {
        this.sortableArray = new List<int>(sortableArray);
    }

    public int[] Sort()
    {
        if (sortableArray.Count < 2)
        {
            return sortableArray.ToArray();
        }

        minrun = CalculateMinrun();
        runs = SplittingAnArray();
        List<List<int>> replateRuns = ResizeByMinrun();
        runs = InsertionSort(replateRuns);


        return UnionByMin();
    }

    private int CalculateMinrun()
    {
        int length = sortableArray.Count;

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

    private List<List<int>> SplittingAnArray()
    {
        List<List<int>> runs = new List<List<int>>();
        SortingMode currentSortMode = SortingMode.UNCLEAR;
        int currentRunStart = 0;

        for (int currentElementIndex = 1;
             currentElementIndex < sortableArray.Count;
             currentElementIndex++)
        {
            SortingMode nextMode = GetSortingModeBy(sortableArray, currentElementIndex - 1, currentElementIndex);
            bool isEnd = currentElementIndex >= sortableArray.Count - 1;
            if (currentSortMode == SortingMode.UNCLEAR)
            {
                currentSortMode = nextMode;
                currentRunStart = currentElementIndex - 1;
            }

            if (currentSortMode == nextMode)
            {
                if (isEnd)
                {
                    List<int> runInner =
                        sortableArray.GetRange(currentRunStart, currentElementIndex + 1 - currentRunStart);
                    if (currentSortMode == SortingMode.DECREASING)
                    {
                        runInner.Reverse();
                    }

                    runs.Add(runInner);
                }

                continue;
            }

            List<int> run = sortableArray.GetRange(currentRunStart, currentElementIndex - currentRunStart);

            if (currentSortMode == SortingMode.DECREASING)
            {
                run.Reverse();
            }

            runs.Add(run);

            if (isEnd)
            {
                runs.Add(new List<int>(sortableArray.ElementAt(currentElementIndex)));
            }

            currentSortMode = SortingMode.UNCLEAR;
        }

        return runs.FindAll(r => r.Count > 0);
    }

    private SortingMode GetSortingModeBy(List<int> array, int firstIndex, int secondIndex)
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

            int missingDimension = minrun - currentRun.Count;

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

    private List<List<int>> InsertionSort(List<List<int>> replateRuns)
    {
        return replateRuns.ConvertAll(rr =>
            new List<int>(new InsertionSorter(rr.ToArray()).Sort()));
    }

    private int[] UnionByMin()
    {
        List<int> sortList = new List<int>();
        List<int> owner = null;
        int currentMin = 0;
        bool isFind = false;

        while (true)
        {
            for (int rcount = 0; rcount < runs.Count; rcount++)
            {
                List<int> potentialOwner = runs[rcount];
                
                if (potentialOwner.Count <= 0) continue;
                if (!isFind)
                {
                    currentMin = potentialOwner[0];
                    owner = potentialOwner;
                    isFind = true;
                    continue;
                }

                int potentialMin = potentialOwner[0];
                if (currentMin <= potentialMin) continue;
                currentMin = potentialMin;
                owner = potentialOwner;
            }

            if (isFind)
            {
                sortList.Add(owner[0]);
                owner.RemoveAt(0);
                isFind = false;
                owner = null;
            }
            else
            {
                break;
            }
        }

        return sortList.ToArray();
    }

    private enum SortingMode
    {
        UNCLEAR,
        INCREASING,
        DECREASING
    }
}