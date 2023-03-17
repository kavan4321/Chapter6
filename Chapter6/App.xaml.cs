using Chapter6.View.Page1View;
using Chapter6.View.Page2View;

namespace Chapter6;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new ActivityScreen())
		{ BarBackgroundColor = Colors.White }; 
	}
}
