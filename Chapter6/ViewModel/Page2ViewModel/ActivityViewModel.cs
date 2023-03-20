using Chapter6.HttpModel.Page2HttpModel;
using Chapter6.Model;
using Chapter6.Model.Psge2Model;
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
    public event EventHandler<PageResult> DeleteEventHandler;
    public event EventHandler EditEvent;

    private DeleteActivityModel _deleteActivityModel;
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
    private Color _boxColor;
    private bool _activityShow=true;
    private bool _collectionShow=false;

    public int Id
    {
        get => _id;
        set
        {
            _id = value;
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
    public Color BoxColor
    {
        get => _boxColor;
        set
        {
            _boxColor = value;
            OnPropertyChanged();
        }
    }
    public bool ActivityShow
    {
        get => _activityShow;
        set
        {
            _activityShow = value;
            OnPropertyChanged();
        }
    }
    public bool CollectionShow
    {
        get => _collectionShow;
        set
        {
            _collectionShow = value;
            OnPropertyChanged();
        }
    }


    public ICommand DeleteCommand { get; private set; }
    public ICommand EditCommand { get; private set; }

    

    public ActivityViewModel()
    {
        _getactivityModel = new GetActivityModel();
        _deleteActivityModel = new DeleteActivityModel();
        EditCommand = new Command<ActivityDetail>(EditDetails);
        DeleteCommand = new Command(() => { _ = DeleteDetaliAsync(); }); 
    }



    public void EditDetails(ActivityDetail activityDetail)
    {
        Id = activityDetail.Id;
        Name = activityDetail.Title;
        DueDate = activityDetail.DueDate;
        Complete = activityDetail.Completed;
        EditEvent?.Invoke(this, new EventArgs());
    }

    public async Task DeleteDetaliAsync()
    {
        _deleteActivityModel.Id = Id;
        var result = await _deleteActivityModel.DeleteActivityAsync();
        DeleteEventHandler?.Invoke(this, result);
    }
    public async Task GetActivityListAsync()
    {
        ActivityShow = true;
        CollectionShow = false;
        var result = await _getactivityModel.GetActivityDetailsAsync();
        ActivityDetails = _getactivityModel.ActivityDetails.ToObservableCollection();
        GetEventHandler?.Invoke(this, result);
        ActivityShow = false;
        CollectionShow = true;
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
