namespace LaboratoryWorkTwelve;

public class MooreStringSearch
{
    private Dictionary<int, int> search = new Dictionary<int, int>();

    public MooreStringSearch(char[] pattern, char[] fullString)
    {
        int startIndexOfFullString = 0;
        int currentPatternIndex = pattern.Length - 1;
        int currentFullStringIndex = startIndexOfFullString + currentPatternIndex;

        if (pattern.Length == 0 || pattern.Length > fullString.Length)
        {
            return;
        }

        while (startIndexOfFullString + pattern.Length - 1 < fullString.Length)
        {
            while (startIndexOfFullString <= currentFullStringIndex)
            {
                if (fullString[currentFullStringIndex] == pattern[currentPatternIndex])
                {
                    currentFullStringIndex = currentFullStringIndex - 1;
                    currentPatternIndex = currentPatternIndex - 1;
                    continue;
                }

                while (fullString[currentFullStringIndex] != pattern[currentPatternIndex])
                {
                    startIndexOfFullString = startIndexOfFullString + 1;
                    currentFullStringIndex = startIndexOfFullString + currentPatternIndex;

                    if (currentFullStringIndex == fullString.Length)
                    {
                        return;
                    }
                }

                currentPatternIndex = pattern.Length - 1;
                currentFullStringIndex = startIndexOfFullString + currentPatternIndex;
            }

            search.Add(startIndexOfFullString, pattern.Length);

            startIndexOfFullString = startIndexOfFullString + 1;
            currentPatternIndex = pattern.Length - 1;
            currentFullStringIndex = startIndexOfFullString + currentPatternIndex;
        }
    }

    public Dictionary<int, int> Searches => search;
}