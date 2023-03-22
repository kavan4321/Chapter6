using Chapter6.HttpModel.Page4HttpModel;
using Chapter6.View.Page1View;
using Chapter6.View.Page2View;
using Chapter6.View.Page3View;
using Chapter6.View.Page4View;
using Chapter6.View.Page5View;

namespace Chapter6;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new QuotesDisplayScreen());
		//{ BarBackgroundColor = Colors.White }; 
		//{ BarBackgroundColor = Color.FromArgb("#075E30") };
    }
}
