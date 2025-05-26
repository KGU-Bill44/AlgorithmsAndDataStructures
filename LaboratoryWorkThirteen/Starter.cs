using LaboratoryWorkThirteen.WindowController;

namespace LaboratoryWorkThirteen;

public static class Starter
{
    public static readonly int COUNT_READ_CHAR = 1024;

    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainWindow(new MainWindowController()));
    }
}