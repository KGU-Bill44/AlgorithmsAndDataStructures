namespace LaboratoryWorkThirteen;

public class DemukronSorter : ISorterNetworkGraph
{
    private IList<GraphNode> originalGraph;
    private List<GraphSortingNode> networkGraph;
    private SortedDictionary<int, List<GraphSortingNode>> distributionOfNodesByLevels;
    private int level = 0;

    public DemukronSorter(IList<GraphNode> originalGraph)
    {
        this.originalGraph = originalGraph;
        distributionOfNodesByLevels = new SortedDictionary<int, List<GraphSortingNode>>();
        networkGraph = originalGraph.Select(ogn => new GraphSortingNode(ogn)).ToList();
    }

    public List<GraphNode> Sort()
    {
        level = 0;
        while (networkGraph.Any())
        {
            var vectorsOfLevel = Ordinal();
            distributionOfNodesByLevels.Add(vectorsOfLevel.Key, vectorsOfLevel.Value);
        }

        return distributionOfNodesByLevels.Values
            .SelectMany(sgn => sgn)
            .Select(sgn => sgn.Origin)
            .ToList();
    }

    private KeyValuePair<int, List<GraphSortingNode>> Ordinal()
    {
        List<GraphSortingNode> select = networkGraph.Where(sgn => sgn.DegIn == 0).ToList();

        select.ForEach(sgn =>
        {
            networkGraph.Remove(sgn);
            sgn.EraseArc();
        });

        KeyValuePair<int, List<GraphSortingNode>> result = new KeyValuePair<int, List<GraphSortingNode>>(level, select);
        level += 1;
        return result;
    }
}