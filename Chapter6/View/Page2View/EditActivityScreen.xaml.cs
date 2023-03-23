using Chapter6.HttpModel.Page2HttpModel;
using Chapter6.ViewModel.Page2ViewModel.ViewModelEdit;
using CommunityToolkit.Maui.Alerts;

namespace Chapter6.View.Page2View;

public partial class EditActivityScreen : ContentPage
{
    private EditActivityViewModel _viewModel;
    public EditActivityScreen(ActivityDetail activityDetail)
    {
        InitializeComponent();
        _viewModel = (EditActivityViewModel)BindingContext;
        _viewModel.ActivityDetail = activityDetail;
        BindEvent();
    }

    private void BindEvent()
    {
        _viewModel.UpdateEvent += UpdateActivityViewModelUpdateEvent;
    }
    private async void UpdateActivityViewModelUpdateEvent(object sender, Model.PageResult e)
    {
        if (e.IsSuccess)
        {
            _ = Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            await Navigation.PopAsync();
        }
        else
        {
            _ = Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }
}