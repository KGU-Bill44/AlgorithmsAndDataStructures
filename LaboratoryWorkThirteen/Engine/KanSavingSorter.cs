using System.Collections.ObjectModel;

namespace LaboratoryWorkThirteen.Engine;

public class KanSavingSorter : IGraphSorter
{
    private NetworkGraph originalGraph;
    private int level = 0;
    private List<GraphNode> previouslyVisited;
    private IEnumerable<GraphNode> currentNodes;
    private Dictionary<int, IEnumerable<GraphNode>> distributionOfNodesByLevels;

    public KanSavingSorter(NetworkGraph graph)
    {
        this.originalGraph = graph;
        this.previouslyVisited = new List<GraphNode>();
        distributionOfNodesByLevels = new Dictionary<int, IEnumerable<GraphNode>>();
    }

    public IDictionary<int, IEnumerable<GraphNode>> NodesDistributedByLevels => new ReadOnlyDictionary<int, IEnumerable<GraphNode>>(distributionOfNodesByLevels);

    public List<GraphNode> Sort()
    {
        level = 0;
        previouslyVisited.Clear();
        distributionOfNodesByLevels.Clear();
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