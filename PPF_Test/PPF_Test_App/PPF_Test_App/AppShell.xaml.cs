namespace PPF_Test_App;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(View.CanvasPage), typeof(View.CanvasPage));
    }
}
