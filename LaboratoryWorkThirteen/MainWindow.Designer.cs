namespace LaboratoryWorkThirteen;

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
        loadFileButton = new Button();
        graphPanel = new PictureBox();
        sortedListPanel = new PictureBox();
        tableLayoutPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)graphPanel).BeginInit();
        ((System.ComponentModel.ISupportInitialize)sortedListPanel).BeginInit();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 1;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.Controls.Add(loadFileButton, 0, 0);
        tableLayoutPanel1.Controls.Add(graphPanel, 0, 1);
        tableLayoutPanel1.Controls.Add(sortedListPanel, 0, 2);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 3;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
        tableLayoutPanel1.Size = new Size(800, 450);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // loadFileButton
        // 
        loadFileButton.Location = new Point(5, 5);
        loadFileButton.Margin = new Padding(5);
        loadFileButton.Name = "loadFileButton";
        loadFileButton.Size = new Size(123, 30);
        loadFileButton.TabIndex = 0;
        loadFileButton.Text = "Загрузить граф";
        loadFileButton.UseVisualStyleBackColor = true;
        loadFileButton.Click += LoadFile;
        // 
        // graphPanel
        // 
        graphPanel.Dock = DockStyle.Fill;
        graphPanel.Location = new Point(3, 43);
        graphPanel.Name = "graphPanel";
        graphPanel.Size = new Size(794, 281);
        graphPanel.TabIndex = 1;
        graphPanel.TabStop = false;
        graphPanel.Paint += GraphPanelPaint;
        // 
        // sortedListPanel
        // 
        sortedListPanel.Dock = DockStyle.Fill;
        sortedListPanel.Location = new Point(3, 330);
        sortedListPanel.Name = "sortedListPanel";
        sortedListPanel.Size = new Size(794, 117);
        sortedListPanel.TabIndex = 2;
        sortedListPanel.TabStop = false;
        sortedListPanel.Paint += SortedListPanelPrint;
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
        ((System.ComponentModel.ISupportInitialize)graphPanel).EndInit();
        ((System.ComponentModel.ISupportInitialize)sortedListPanel).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private Button loadFileButton;
    private PictureBox graphPanel;
    private PictureBox sortedListPanel;
}