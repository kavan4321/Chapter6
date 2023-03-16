using Chapter6.HttpModel;
using Chapter6.Model;
using Chapter6.Model.Psge2Model.ModelActivity;
using CommunityToolkit.Maui.Core.Extensions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chapter6.ViewModel.Page2ViewModel.ViewModelActivity;

public class ActivityViewModel : INotifyPropertyChanged
{
    public event EventHandler<PageResult> GetEventHandler;
    private GetActivityModel _getactivityModel;

    private ObservableCollection<ActivityDetail> _activityDetails;
    public ObservableCollection<ActivityDetail> ActivityDetails
    {
        get => _activityDetails;
        set
        {
            _activityDetails = value;
            OnPropertyChanged();
        }
    }


    public ActivityViewModel()
    {
        _getactivityModel=new GetActivityModel();
    }

    public async Task GetActivityListAsync()
    {
        var result = await _getactivityModel.GetActivityDetailsAsync();
        ActivityDetails=_getactivityModel.ActivityDetails.ToObservableCollection();
        GetEventHandler?.Invoke(this, result);
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
