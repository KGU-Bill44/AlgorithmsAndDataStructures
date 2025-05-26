namespace LaboratoryWorkThirteen.Engine;

public class DemukronUnsavingSorter : IDemukronSorter
{
    private MatrixOfNetworkGraph matrixOfNetworkGraph;
    private List<int> distributionOfNodesByLevels;
    private IEnumerable<GraphNode> currentNodes;
    private NetworkGraph graph;

    public DemukronUnsavingSorter(MatrixOfNetworkGraph matrixOfNetworkGraph)
    {
        this.matrixOfNetworkGraph = matrixOfNetworkGraph;
    }

    public List<GraphNode> Sort()
    {
        distributionOfNodesByLevels = new List<int>();
        graph = matrixOfNetworkGraph.GetGraph();
        currentNodes = graph.GetNodes().Where(n => n.DegIn == 0);

        while (currentNodes.Any())
        {
            IEnumerable<int> nodesNumber = Ordinal();
            distributionOfNodesByLevels.AddRange(nodesNumber);
        }

        NetworkGraph newGraph = matrixOfNetworkGraph.GetGraph();
        List<GraphNode> nodes = newGraph.GetNodes().ToList();
        return distributionOfNodesByLevels.Select(c => nodes.Find(n => n.Number == c)).ToList();
    }

    private IEnumerable<int> Ordinal()
    {
        List<GraphNode> list = currentNodes.ToList();

        list.ForEach(n => graph.RemoveNode(n));
        currentNodes = graph.GetNodes().Where(n => n.DegIn == 0);

        return list.Select(l => l.Number);
    }
}