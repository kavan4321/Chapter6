using Chapter6.HttpModel.Page2HttpModel;
using Chapter6.Model;
using Chapter6.Model.Psge2Model;
using CommunityToolkit.Maui.Alerts;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
namespace Chapter6.ViewModel.Page2ViewModel.ViewModelEdit;

public class EditActivityViewModel : INotifyPropertyChanged
{
    public event EventHandler<PageResult> UpdateEvent;
    private UpdateActivityModel _updateActivityModel;

    private ActivityDetail _activityDetail;
    public ActivityDetail ActivityDetail
    {
        get => _activityDetail;
        set
        {
            _activityDetail = value;
            OnPropertyChanged();
        }
    }
    public ICommand UpdateCommand { get; private set; }




    public EditActivityViewModel()
    {
        _updateActivityModel = new UpdateActivityModel();
        UpdateCommand = new Command(() => { _ = UpdateDetailAsync(ActivityDetail); });
    }

    public async Task UpdateDetailAsync(ActivityDetail activityDetail)
    {
        if (string.IsNullOrWhiteSpace(activityDetail.Title))
        {
            _ = Toast.Make("Please Enter Activity Name", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
        else
        {
            _updateActivityModel.Id = activityDetail.Id;
            _updateActivityModel.Name = activityDetail.Title;
            _updateActivityModel.DueDate = activityDetail.DueDate;
            _updateActivityModel.Complete = activityDetail.Completed;
            var result = await _updateActivityModel.UpdateActivityDetailAsnyc();
            UpdateEvent?.Invoke(this, result);
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}