namespace LaboratoryWorkTwelve
{
    public partial class WriteText : Form
    {
        public WriteText()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void reject_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public string TextResult => this.richTextBox1.Text; 
    }
}
