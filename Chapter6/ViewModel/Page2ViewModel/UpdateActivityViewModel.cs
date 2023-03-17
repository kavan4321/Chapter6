
using Chapter6.Model;
using Chapter6.Model.Psge2Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chapter6.ViewModel.Page2ViewModel.ViewModelUpdate;

public class UpdateActivityViewModel : INotifyPropertyChanged
{

    public event EventHandler<PageResult> UpdateEvent;
    private UpdateActivityModel _updateActivityModel;


    private int _id;
    private string _title;
    private DateTime _dueTime;
    private bool _complate;

    public int Id
    {
        get => _id;
        set
        {
            _id= value;
            OnPropertyChanged();
        }
    }
    public string Title
    {
        get => _title;
        set
        {
            _title= value;
            OnPropertyChanged();
        }
    }
    public DateTime DueDate
    {
        get => _dueTime;
        set
        {
            _dueTime = value;
            OnPropertyChanged();
        }
    }
    public bool Complate
    {
        get => _complate;
        set
        {
            _complate = value;
            OnPropertyChanged();
        }
    }

    public ICommand UpdateCommand { get;private set; }

    public UpdateActivityViewModel()
    {
        _updateActivityModel= new UpdateActivityModel();

    }

    public async Task UpdateDetailAsync()
    {
        _updateActivityModel.Id = Id;
        _updateActivityModel.Name = Title;
        _updateActivityModel.DueDate = DueDate;
        _updateActivityModel.Complete = Complate;
        var result = await _updateActivityModel.UpdateActivityDetailAsnyc();
        UpdateEvent?.Invoke(this, result);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
