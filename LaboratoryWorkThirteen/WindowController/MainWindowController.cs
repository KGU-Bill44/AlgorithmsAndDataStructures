using LaboratoryWorkThirteen.Engine;

namespace LaboratoryWorkThirteen.WindowController
{
    public class MainWindowController
    {
        public int[,] ParseMatrixFromString(string matrixString)
        {
            if (string.IsNullOrEmpty(matrixString))
            {
                throw new ArgumentNullException(nameof(matrixString), "Строка не может быть пустой.");
            }

            string[] rows = matrixString.Split(new[] { Environment.NewLine, "\n", "\r" },
                StringSplitOptions.RemoveEmptyEntries);

            if (rows.Length == 0)
            {
                throw new FormatException("Строковая матрица не имеет строк.");
            }

            int numRows = rows.Length;
            int numCols = rows[0].Length;

            if (rows.Any(row => row.Length != numCols))
            {
                throw new FormatException("Строковая матрица не квадратная.");
            }

            int[,] matrix = new int[numRows, numCols];

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    char c = rows[i][j];

                    if (c == '0')
                    {
                        matrix[i, j] = 0;
                    }
                    else if (c == '1')
                    {
                        matrix[i, j] = 1;
                    }
                    else
                    {
                        throw new FormatException(
                            $"На позиции {i + 1}, {j + 1} встретился отличнвй от 0 или 1 символ {c}.");
                    }
                }
            }

            return matrix;
        }

        public List<GraphNode> SortGraph(string anyMatrixString)
        {
            int[,] adjacencyMatrix = ParseMatrixFromString(anyMatrixString);
            IDemukronSorter sorterNetwork = new DemukronUnsavingSorter(new MatrixOfNetworkGraph(adjacencyMatrix));

            return sorterNetwork.Sort();
        }
    }
}