using System.Text;

namespace LaboratoryWorkFour;

public static class EnginController
{
    private static Engin engin;

    public static void CreateEngin(int length)
    {
        engin = Engin.CreateEngin();
        engin.FillStackRandomInts(length);
    }

    public static void PutMaximumAtEnd()
    {
        engin.PutMaximumAtEnd();
    }

    public static void PutMinMaxAtFirstEnd()
    {
        engin.PutMinimumAtFirst();
        engin.PutMaximumAtEnd();
    }

    public static string GetStackContentString()
    {
        int[] elements = engin.GetElementsOfStack();
        if (elements.Length > 0)
        {
            string startLine = "-----------\n";
            StringBuilder collect = new StringBuilder(startLine);

            foreach (int element in elements)
            {
                collect.Append($"|   {element}\t  |\n" +
                               "-----------\n");
            }

            return collect.ToString();
        }
        else
        {
            return String.Empty;
        }
    }
}