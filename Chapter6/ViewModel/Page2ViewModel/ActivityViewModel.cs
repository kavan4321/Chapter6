using Chapter6.HttpModel.Page2HttpModel;
using Chapter6.Model;
using Chapter6.Model.Psge2Model.ModelActivity;
using CommunityToolkit.Maui.Core.Extensions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

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


    private int _id;
    private string _name;
    private DateTime _dueDate;
    private bool _complete;

    public int Id
    {
        get => _id;
        set
        {
            _id=value;
            OnPropertyChanged();
        }
    }
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }
    public DateTime DueDate
    {
        get => _dueDate;
        set
        {
            _dueDate = value;
            OnPropertyChanged();
        }
    }
    public bool Complete
    {
        get => _complete;
        set
        {
            _complete = value;
            OnPropertyChanged();
        }
    }


    public ICommand DeleteCommand { get;private set; }
    public ICommand EditCommand {  get;private set; }
    public event EventHandler EditEvent;

    public ActivityViewModel()
    {
        _getactivityModel=new GetActivityModel();
        EditCommand = new Command<ActivityDetail>(EditDetails);
        DeleteCommand = new Command<ActivityDetail>(DeleteDetails);
    }



    public void EditDetails(ActivityDetail activityDetail)
    {
        Id = activityDetail.Id;
        Name = activityDetail.Title;
        DueDate=activityDetail.DueDate;
        Complete = activityDetail.Completed;
        EditEvent?.Invoke(this, new EventArgs());
    }


    public void DeleteDetails(ActivityDetail activityDetails)
    {
        ActivityDetails.Remove(activityDetails);
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
