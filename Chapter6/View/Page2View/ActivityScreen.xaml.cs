using Chapter6.ViewModel.Page2ViewModel.ViewModelActivity;

namespace Chapter6.View.Page2View;

public partial class ActivityScreen : ContentPage
{
	private ActivityViewModel _activityViewModel;
	public ActivityScreen()
	{
		InitializeComponent();
		_activityViewModel=(ActivityViewModel)BindingContext;
		_=GetActivityList();
	}

	private async Task GetActivityList()
	{
	  await	_activityViewModel.GetActivityListAsync();
	}

    private async void AddButtonClicked(object sender, EventArgs e)
    {
	  await	Navigation.PushAsync(new AddActivityScreen());
    }
}