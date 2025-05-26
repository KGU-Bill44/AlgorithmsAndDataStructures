using System.Text;
using LaboratoryWorkThirteen.Engine;
using LaboratoryWorkThirteen.WindowController;

namespace LaboratoryWorkThirteen;

public partial class MainWindow : Form
{
    private readonly MainWindowController controller;

    private readonly Font nodeFont = new Font("Arial", 20);
    private readonly SolidBrush textBrush = new SolidBrush(Color.Black);
    private readonly SolidBrush nodeBrush = new SolidBrush(Color.Yellow);
    private readonly Pen edgePen = new Pen(Color.Brown, 5);
    private readonly int radiusNode = 20;

    public MainWindow(MainWindowController controller)
    {
        InitializeComponent();
        this.controller = controller;
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint,
            true);
    }

    private void LoadFile(object sender, EventArgs e)
    {
        try
        {
            if (ReadStringFromFile(out string resultString))
            {
                controller.SortGraph(resultString);
                graphPanel.Invalidate();
                sortedListPanel.Invalidate();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
        }
    }

    private bool ReadStringFromFile(out string resultString)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.ShowHiddenFiles = true;
        openFileDialog.Filter = "| *.txt";
        openFileDialog.Multiselect = false;
        openFileDialog.CheckFileExists = true;
        openFileDialog.CheckPathExists = true;
        StringBuilder stringFromFile = new StringBuilder();
        resultString = string.Empty;

        if (openFileDialog.ShowDialog(this) == DialogResult.OK)
        {
            using TextReader reader = new StreamReader(openFileDialog.OpenFile());

            char[] bytes = new char[Starter.COUNT_READ_CHAR];
            int lastRead = 1;

            while (lastRead > 0)
            {
                lastRead = reader.Read(bytes, 0, bytes.Length);
                stringFromFile.Append(bytes, 0, lastRead);
            }

            resultString = stringFromFile.ToString();
            return true;
        }

        return false;
    }

    private void GraphPanelPaint(object sender, PaintEventArgs e)
    {
        if (controller.Sorter?.NodesDistributedByLevels == null ||
            controller.Sorter.NodesDistributedByLevels.Count == 0)
        {
            return;
        }

        int levelSpacing = Math.Max(graphPanel.Width / (controller.Sorter.NodesDistributedByLevels.Count + 1), 135);
        var dictionary = controller.Sorter.NodesDistributedByLevels.OrderBy(p => p.Key);
        Dictionary<GraphNode, PointF> nodePositions = CalculatePosition(e, dictionary, levelSpacing);

        DrawLevels(e, dictionary, levelSpacing);
        DrawEdge(e, dictionary, nodePositions);
        DrawNode(e, dictionary, nodePositions);
    }

    private void DrawLevels(PaintEventArgs e, IOrderedEnumerable<KeyValuePair<int, IEnumerable<GraphNode>>> dictionary,
        int levelSpacing)
    {
        Pen levelPen = new Pen(Color.Gray, 1);

        foreach (var level in dictionary)
        {
            int levelNumber = level.Key;
            e.Graphics.DrawLine(levelPen, levelSpacing * levelNumber, 0, levelSpacing * levelNumber, graphPanel.Height);
            e.Graphics.DrawString($"Уровень {levelNumber}", nodeFont, textBrush, levelSpacing * levelNumber, 10);
        }
    }

    private Dictionary<GraphNode, PointF> CalculatePosition(PaintEventArgs e,
        IOrderedEnumerable<KeyValuePair<int, IEnumerable<GraphNode>>> dictionary,
        int levelSpacing)
    {
        Dictionary<GraphNode, PointF> nodePositions = new Dictionary<GraphNode, PointF>();

        foreach (var level in dictionary)
        {
            int levelNumber = level.Key;
            int indexNode = 1;
            float heightStep = Math.Max(graphPanel.Height / (level.Value.Count() + 1), 60);

            foreach (GraphNode node in level.Value)
            {
                float xPosition = levelSpacing * levelNumber + levelNumber / 2 + levelSpacing / 2;

                float yPosiotion = heightStep * indexNode;
                nodePositions.Add(node, new PointF(xPosition, yPosiotion));
                indexNode = indexNode + 1;
            }
        }

        return nodePositions;
    }

    private void DrawEdge(PaintEventArgs e,
        IOrderedEnumerable<KeyValuePair<int, IEnumerable<GraphNode>>> dictionary,
        Dictionary<GraphNode, PointF> nodePositions)
    {
        foreach (var level in dictionary)
        {
            foreach (GraphNode sourceNode in level.Value)
            {
                foreach (GraphNode targetNode in sourceNode.DegOut)
                {
                    if (nodePositions.TryGetValue(sourceNode, out var sourcePoint) &&
                        nodePositions.TryGetValue(targetNode, out var targetPoint))
                    {
                        e.Graphics.DrawLine(edgePen, sourcePoint, targetPoint);
                    }
                }
            }
        }
    }

    private void DrawNode(PaintEventArgs e,
        IOrderedEnumerable<KeyValuePair<int, IEnumerable<GraphNode>>> dictionaryNode,
        Dictionary<GraphNode, PointF> nodePositions)
    {
        foreach (var level in dictionaryNode)
        {
            foreach (GraphNode sourceNode in level.Value)
            {
                if (nodePositions.TryGetValue(sourceNode, out PointF location))
                {
                    location = location - new Size(radiusNode, radiusNode);
                    e.Graphics.FillEllipse(nodeBrush, location.X, location.Y, radiusNode * 2, radiusNode * 2);
                    e.Graphics.DrawString($"{sourceNode.Number}", nodeFont, textBrush, location.X, location.Y);
                }
            }
        }
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        graphPanel.Invalidate();
        sortedListPanel.Invalidate();
    }

    private void SortedListPanelPrint(object sender, PaintEventArgs e)
    {
        if (controller.SortList == null || controller.SortList.Count == 0)
        {
            return;
        }

        float nodeStep = Math.Max(sortedListPanel.Width / (controller.SortList.Count + 1), 55);
        float yPosition = sortedListPanel.Height / 2;
        int maxValueRandom = Math.Max((int)yPosition - radiusNode, 1);
        Dictionary<GraphNode, float> nodePosition = new Dictionary<GraphNode, float>();
        Random random = new Random();

        for (int i = 1; i <= controller.SortList.Count; i++)
        {
            GraphNode node = controller.SortList[i - 1];
            nodePosition.Add(node, nodeStep * i);
        }

        foreach (GraphNode source in controller.SortList)
        {
            float xSourcePosition = nodePosition[source];
            for (int i = 0; i < source.DegOut.Count; i++)
            {
                float randomSeed = random.Next(1, maxValueRandom);
                float yAcrPosition = Math.Max(yPosition - randomSeed, 1);

                GraphNode target = source.DegOut[i];
                float xTargetPosition = nodePosition[target];
                float angil = 180 * (i % 2);
                Pen arcPen =
                    new Pen(
                        Color.FromArgb((int)xTargetPosition % 255, (target.Number + source.Number) * 25 % 255,
                            (int)(yAcrPosition * i) % 255), 5);

                e.Graphics.DrawArc(arcPen,
                    new RectangleF(xSourcePosition + radiusNode, yAcrPosition + radiusNode,
                        xTargetPosition - xSourcePosition, randomSeed * 2), angil, 180);
            }
        }

        for (int i = 1; i <= controller.SortList.Count; i++)
        {
            e.Graphics.FillEllipse(nodeBrush, nodeStep * i, yPosition, radiusNode * 2, radiusNode * 2);
            e.Graphics.DrawString($"{controller.SortList[i - 1].Number}", nodeFont, textBrush, nodeStep * i, yPosition);
        }
    }
}