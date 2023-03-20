using Chapter6.HttpModel.Page2HttpModel;
using Chapter6.ViewModel.Page2ViewModel.ViewModelActivity;
using CommunityToolkit.Maui.Alerts;

namespace Chapter6.View.Page2View;

public partial class ActivityScreen : ContentPage
{
    private ActivityViewModel _activityViewModel;
    public ActivityScreen()
    {
        InitializeComponent();
        _activityViewModel = (ActivityViewModel)BindingContext;
        _ = GetActivityList();
        _activityViewModel.EditEvent += ActivityViewModelEditEvent;
        _activityViewModel.DeleteEventHandler += ActivityViewModelDeleteEventHandler;
    }

    private void ActivityViewModelDeleteEventHandler(object sender, Model.PageResult e)
    {
        if (e.IsSuccess)
        {
            Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
        else
        {
            Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }

    private async void ActivityViewModelEditEvent(object sender, EventArgs e)
    {
        ActivityDetail activityDetail = new()
        {
            Id = _activityViewModel.Id,
            Title = _activityViewModel.Name,
            DueDate = _activityViewModel.DueDate,
            Completed = _activityViewModel.Complete
        };
        await Navigation.PushAsync(new EditActivityScreen(activityDetail));
    }
    private async Task GetActivityList()
    {
        await _activityViewModel.GetActivityListAsync();
    }

    private async void AddButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddActivityScreen());
    }

}
