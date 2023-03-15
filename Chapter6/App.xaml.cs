using Chapter6.View.Page1View;

namespace Chapter6;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new RecipeScreen()); ;
	}
}
