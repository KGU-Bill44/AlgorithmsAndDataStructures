using LaboratoryWorkThirteen.WindowController;

namespace LaboratoryWorkThirteen;

public static class Starter
{
    public readonly static int COUNT_READ_CHAR = 1024;

    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainWindow(new MainWindowController()));
    }
}