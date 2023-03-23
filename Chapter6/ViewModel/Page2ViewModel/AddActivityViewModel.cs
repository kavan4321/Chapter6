using Chapter6.Model;
using Chapter6.Model.Psge2Model;
using CommunityToolkit.Maui.Alerts;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chapter6.ViewModel.Page2ViewModel.ViewModelAddActivity;

public class AddActivityViewModel:INotifyPropertyChanged
{
    private AddActivityModel _addActivityModel;
    public ICommand AddCommand { get;private set; }
    
    public event EventHandler<PageResult> AddEvent;

    private string _name;
    private DateTime _dueDate=DateTime.Now;
    private bool _complete;

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
            _dueDate=value;
            OnPropertyChanged();
        }
    }
    public bool Complete 
    {
        get => _complete;
        set
        {
            _complete=value;
            OnPropertyChanged();
        }
    }

    public AddActivityViewModel()
    {
        _addActivityModel = new AddActivityModel(); 
        AddCommand = new Command(() => { _ = AddActivityDetails(); });
    }

    public async Task AddActivityDetails()
    {

        if(string.IsNullOrWhiteSpace(Name)) 
        {
            _ = Toast.Make("Please Enter Activity Name", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
        else
        {
            _addActivityModel.Name = Name;
            _addActivityModel.DueDate = DueDate;
            _addActivityModel.Complete = Complete;
            var result = await _addActivityModel.AddActivityDetailsAsync();
            AddEvent?.Invoke(this, result);

        }
        
    }


    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
