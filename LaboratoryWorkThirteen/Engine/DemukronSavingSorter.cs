namespace LaboratoryWorkThirteen.Engine;

public class DemukronSavingSorter : ISorterNetworkGraph
{
    private NetworkGraph originalGraph;
    private int level = 0;
    private List<GraphNode> previouslyVisited;
    private IEnumerable<GraphNode> currentNodes;

    public DemukronSavingSorter(NetworkGraph graph)
    {
        this.originalGraph = graph;
        this.previouslyVisited = new List<GraphNode>();
    }

    public List<GraphNode> Sort()
    {
        level = 0;
        previouslyVisited.Clear();
        Dictionary<int, List<GraphNode>> distributionOfNodesByLevels = new Dictionary<int, List<GraphNode>>();
        currentNodes = originalGraph.GetNodes().Where(n => n.DegIn == 0);


        while (currentNodes.Any())
        {
            var vectorsOfLevel = Ordinal();
            distributionOfNodesByLevels.Add(vectorsOfLevel.Key, vectorsOfLevel.Value);
        }

        return distributionOfNodesByLevels.Values
            .SelectMany(sgn => sgn)
            .ToList();
    }

    private KeyValuePair<int, List<GraphNode>> Ordinal()
    {
        List<GraphNode> list = currentNodes.ToList();
        KeyValuePair<int, List<GraphNode>> result = new KeyValuePair<int, List<GraphNode>>(level, list);
        previouslyVisited.AddRange(currentNodes);

        currentNodes = list.SelectMany(n => n.DegOut)
            .Where(n => !previouslyVisited.Contains(n)
                        && previouslyVisited.SelectMany(node => node.DegOut)
                            .Count(ndo => n.Number == ndo.Number) == n.DegIn).ToList().Distinct();
        level += 1;
        return result;
    }
}