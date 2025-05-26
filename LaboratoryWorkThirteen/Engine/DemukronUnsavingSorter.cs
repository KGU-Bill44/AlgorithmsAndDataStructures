using System.Collections.ObjectModel;

namespace LaboratoryWorkThirteen.Engine;

public class DemukronUnsavingSorter : IDemukronSorter
{
    private MatrixOfNetworkGraph matrixOfNetworkGraph;
    private List<int> sortedListIndex;
    private IEnumerable<GraphNode> currentNodes;
    private NetworkGraph graph;
    private Dictionary<int, IEnumerable<GraphNode>> distributionOfNodesByLevels;
    private int level;

    public DemukronUnsavingSorter(MatrixOfNetworkGraph matrixOfNetworkGraph)
    {
        this.matrixOfNetworkGraph = matrixOfNetworkGraph;
        distributionOfNodesByLevels = new Dictionary<int, IEnumerable<GraphNode>>();
        level = 0;
    }

    public IDictionary<int, IEnumerable<GraphNode>> NodesDistributedByLevels => new ReadOnlyDictionary<int, IEnumerable<GraphNode>>(distributionOfNodesByLevels);

    public List<GraphNode> Sort()
    {
        sortedListIndex = new List<int>();
        graph = matrixOfNetworkGraph.GetGraph();
        currentNodes = graph.GetNodes().Where(n => n.DegIn == 0);
        distributionOfNodesByLevels.Clear();

        while (currentNodes.Any())
        {
            IEnumerable<int> nodesNumber = Ordinal();
            sortedListIndex.AddRange(nodesNumber);
        }

        NetworkGraph newGraph = matrixOfNetworkGraph.GetGraph();
        List<GraphNode> nodes = newGraph.GetNodes().ToList();
        return sortedListIndex.Select(c => nodes.Find(n => n.Number == c)).ToList();
    }

    private IEnumerable<int> Ordinal()
    {
        List<GraphNode> list = currentNodes.ToList();
        distributionOfNodesByLevels.Add(level, list);

        list.ForEach(n => graph.RemoveNode(n));
        currentNodes = graph.GetNodes().Where(n => n.DegIn == 0);
        level++;

        return list.Select(l => l.Number);
    }
}