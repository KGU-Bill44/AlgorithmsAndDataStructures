using LaboratoryWorkThirteen.GraphException;

namespace LaboratoryWorkThirteen;

public class MatrixOfGraph
{
    private List<GraphNode> nodes;

    public MatrixOfGraph(int[,] matrixGraph)
    {
        if (matrixGraph.GetLength(0) != matrixGraph.GetLength(1))
        {
            throw new NotSquareMatrixGraphException();
        }

        SetNodes(matrixGraph);
        SetGraph(matrixGraph);
    }

    protected virtual void SetGraph(int[,] matrixGraph)
    {
        for (int x = 0; x < matrixGraph.GetLength(0); x++)
        {
            for (int y = 0; y < matrixGraph.GetLength(1); y++)
            {
                if (matrixGraph[x, y] != 0)
                {
                    nodes[x].DegOut.Add(nodes[y]);
                    nodes[y].DegIn++;
                }
            }
        }
    }

    private void SetNodes(int[,] matrixGraph)
    {
        List<GraphNode> nodes = new List<GraphNode>();

        for (int number = 0; number < matrixGraph.GetLength(0); number++)
        {
            nodes.Add(new GraphNode(number));
        }

        this.nodes = nodes;
    }

    public IEnumerable<GraphNode> GetGraph()
    {
        return nodes;
    }
}