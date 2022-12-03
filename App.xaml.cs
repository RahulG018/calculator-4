namespace Calculator;

public partial class App : Application
{
    public App()
    {

        InitializeComponent();

        MainPage = new AppShell();
        About = new AppShell();
    }

    public AppShell About { get; }
}
