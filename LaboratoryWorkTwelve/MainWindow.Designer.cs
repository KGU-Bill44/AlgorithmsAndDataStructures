namespace LaboratoryWorkTwelve;

partial class MainWindow
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        tableLayoutPanel1 = new TableLayoutPanel();
        patternStringTextBox = new TextBox();
        tableLayoutPanel2 = new TableLayoutPanel();
        findSubStringButton = new Button();
        OpenFileButton = new Button();
        button2 = new Button();
        ViewText = new RichTextBox();
        tableLayoutPanel1.SuspendLayout();
        tableLayoutPanel2.SuspendLayout();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 3;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        tableLayoutPanel1.Controls.Add(patternStringTextBox, 0, 0);
        tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
        tableLayoutPanel1.Controls.Add(ViewText, 2, 0);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 1;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.Size = new Size(800, 450);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // patternStringTextBox
        // 
        patternStringTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        patternStringTextBox.Location = new Point(10, 213);
        patternStringTextBox.Margin = new Padding(10);
        patternStringTextBox.Name = "patternStringTextBox";
        patternStringTextBox.Size = new Size(246, 23);
        patternStringTextBox.TabIndex = 0;
        // 
        // tableLayoutPanel2
        // 
        tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        tableLayoutPanel2.ColumnCount = 1;
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel2.Controls.Add(findSubStringButton, 0, 3);
        tableLayoutPanel2.Controls.Add(OpenFileButton, 0, 1);
        tableLayoutPanel2.Controls.Add(button2, 0, 2);
        tableLayoutPanel2.Location = new Point(269, 3);
        tableLayoutPanel2.Name = "tableLayoutPanel2";
        tableLayoutPanel2.RowCount = 5;
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
        tableLayoutPanel2.Size = new Size(260, 444);
        tableLayoutPanel2.TabIndex = 1;
        // 
        // findSubStringButton
        // 
        findSubStringButton.Dock = DockStyle.Fill;
        findSubStringButton.Location = new Point(10, 253);
        findSubStringButton.Margin = new Padding(10);
        findSubStringButton.Name = "findSubStringButton";
        findSubStringButton.Size = new Size(240, 24);
        findSubStringButton.TabIndex = 2;
        findSubStringButton.Text = "Показать подстроку";
        findSubStringButton.UseVisualStyleBackColor = true;
        findSubStringButton.Click += FindSubString;
        // 
        // OpenFileButton
        // 
        OpenFileButton.Dock = DockStyle.Fill;
        OpenFileButton.Location = new Point(10, 165);
        OpenFileButton.Margin = new Padding(10);
        OpenFileButton.Name = "OpenFileButton";
        OpenFileButton.Size = new Size(240, 24);
        OpenFileButton.TabIndex = 0;
        OpenFileButton.Text = "Файл";
        OpenFileButton.UseVisualStyleBackColor = true;
        OpenFileButton.Click += OpenFileButton_Click;
        // 
        // button2
        // 
        button2.Dock = DockStyle.Fill;
        button2.Location = new Point(10, 209);
        button2.Margin = new Padding(10);
        button2.Name = "button2";
        button2.Size = new Size(240, 24);
        button2.TabIndex = 1;
        button2.Text = "Ввести";
        button2.UseVisualStyleBackColor = true;
        button2.Click += FromKeyboard;
        // 
        // ViewText
        // 
        ViewText.Dock = DockStyle.Fill;
        ViewText.Location = new Point(542, 10);
        ViewText.Margin = new Padding(10);
        ViewText.Name = "ViewText";
        ViewText.ReadOnly = true;
        ViewText.Size = new Size(248, 430);
        ViewText.TabIndex = 2;
        ViewText.Text = "";
        // 
        // MainWindow
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(tableLayoutPanel1);
        Name = "MainWindow";
        Text = "MainWindow";
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        tableLayoutPanel2.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private TextBox patternStringTextBox;
    private TableLayoutPanel tableLayoutPanel2;
    private Button OpenFileButton;
    private Button button2;
    private RichTextBox ViewText;
    private Button findSubStringButton;
}