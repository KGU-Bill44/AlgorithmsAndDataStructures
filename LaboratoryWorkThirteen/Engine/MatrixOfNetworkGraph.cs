using LaboratoryWorkThirteen.GraphException;

namespace LaboratoryWorkThirteen.Engine;

public class MatrixOfNetworkGraph
{
    private NetworkGraph graph;
    private int[,] matrixGraph;

    public MatrixOfNetworkGraph(int[,] matrixGraph)
    {
        if (matrixGraph.GetLength(0) != matrixGraph.GetLength(1))
        {
            throw new NotSquareMatrixGraphException();
        }

        this.matrixGraph = matrixGraph;
    }

    public NetworkGraph GetGraph()
    {
        graph = new NetworkGraph();

        SetNodes(matrixGraph);
        SetGraph(matrixGraph);

        return graph;
    }

    private void SetNodes(int[,] matrixGraph)
    {
        for (int number = 1; number <= matrixGraph.GetLength(0); number++)
        {
            graph.AddNode(new GraphNode(number));
        }
    }

    protected virtual void SetGraph(int[,] matrixGraph)
    {
        for (int x = 0; x < matrixGraph.GetLength(0); x++)
        {
            for (int y = 0; y < matrixGraph.GetLength(1); y++)
            {
                if (matrixGraph[x, y] != 0)
                {
                    graph.AddEdge(graph[x], graph[y]);
                }
            }
        }
    }
}