using LaboratoryWorkThirteen.Engine;
using LaboratoryWorkThirteen.WindowController;
using System.Text;

namespace LaboratoryWorkThirteen;

public partial class MainWindow : Form
{
    private MainWindowController controller;

    public MainWindow(MainWindowController controller)
    {
        InitializeComponent();
        this.controller = controller;
    }

    private void LoadFile(object sender, EventArgs e)
    {
        if (ReadStringFromFile(out string resultString))
        {
            List<GraphNode> graphNodes = controller.SortGraph(resultString);
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
}