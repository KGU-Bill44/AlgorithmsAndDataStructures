using System.Text;

namespace LaboratoryWorkTwelve;

public partial class MainWindow : Form
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OpenFileButton_Click(object sender, EventArgs e)
    {
        OpenFileDialog dlg = new OpenFileDialog
        {
            Filter = "| *.txt"
        };

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            StringBuilder builder = new StringBuilder();
            using (StreamReader reader = new StreamReader(dlg.OpenFile(), Encoding.Default))
            {
                while (!reader.EndOfStream)
                {
                    builder.AppendLine(reader.ReadLine());
                }
            }

            ViewText.Text = builder.ToString();
        }
    }

    private void FromKeyboard(object sender, EventArgs e)
    {
        WriteText writeText = new WriteText();
        if (writeText.ShowDialog() == DialogResult.OK)
        {
            ViewText.Text = writeText.TextResult;
        }
    }

    private void FindSubString(object sender, EventArgs e)
    {
        FindSubString();
    }

    private void FindSubString()
    {
        ViewText.SelectAll();
        ViewText.SelectionBackColor = ViewText.BackColor;

        var mooreStringSearch = new MooreStringSearch(patternStringTextBox.Text.ToArray(), ViewText.Text.ToArray());

        foreach (var search in mooreStringSearch.Searches)
        {
            ViewText.Select(search.Key, search.Value);
            ViewText.SelectionBackColor = Color.Yellow;
        }
    }

    private void TextChanged(object sender, EventArgs e)
    {
        FindSubString();
    }
}