using Chapter6.HttpModel.Page2HttpModel;
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
        _activityViewModel.EditEvent += ActivityViewModelEditEvent;
	}

    private async void ActivityViewModelEditEvent(object sender, EventArgs e)
    {
		ActivityDetail activityDetail = new()
		{
			Id = _activityViewModel.Id,
			Title = _activityViewModel.Name,
			DueDate= _activityViewModel.DueDate,
			Completed=_activityViewModel.Complete
		};
        await Navigation.PushAsync(new EditActivityScreen(activityDetail));
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