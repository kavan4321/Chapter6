using Chapter6.HttpModel.Page7HttpModel;
using Chapter6.Model;
using Chapter6.Model.Page7Model;
using CommunityToolkit.Maui.Core.Extensions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chapter6.ViewModel.Page7ViewModel.ViewModelEmployee;

public class EmployeeViewModel : INotifyPropertyChanged
{
    private GetEmployeeModel _getEmployeeModel;
    private DeleteEmployeeModel _deleteEmployeeModel;
   
    public event EventHandler<PageResult> GetEmployeeEvent;
    public event EventHandler<PageResult> DeleteEmployeeEvent;
    public event EventHandler EditEvent;
   
    
    private ObservableCollection<EmployeeDetail> _employeeDetails;
    public ObservableCollection<EmployeeDetail> EmployeeDetails
    {
        get => _employeeDetails;
        set
        {
            _employeeDetails = value;
            OnPropertyChanged();
        }
    }


    private bool _isloading;
    private bool _isShow;
    private int _id;
    private string _firstName;
    private string _lastName;
    private string _avatar;
    private string _email;

    public bool IsLoading
    {
        get => _isloading;
        set
        {
            _isloading = value;
            OnPropertyChanged();
        }
    }
    public bool IsShow
    {
        get => _isShow;
        set
        {
            _isShow = value;
            OnPropertyChanged();
        }
    }
    public int Id
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged();
        }
    }
    public string FirstName
    {
        get => _firstName;
        set
        {
            _firstName = value;
            OnPropertyChanged();
        }
    }
    public string LastName
    {
        get => _lastName;
        set
        {
            _lastName = value;
            OnPropertyChanged();
        }
    }
    public string Avatar
    {
        get => _avatar;
        set
        {
            _avatar = value;
            OnPropertyChanged();
        }
    }
    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged();
        }
    }

    public ICommand EditCommand { get;private set; }
    public ICommand DeleteCommand { get;private set; }
    public EmployeeViewModel()
    {
        _getEmployeeModel=new GetEmployeeModel();
        _deleteEmployeeModel = new DeleteEmployeeModel();    
        EditCommand = new Command<EmployeeDetail>(EditDetails);
        DeleteCommand = new Command<EmployeeDetail>( (EmployeeDetail) => { _ = DeleteEmployeeDetailAsync(EmployeeDetail); });
    }


    public async Task DeleteEmployeeDetailAsync(EmployeeDetail employeeDetail)
    {      
        _deleteEmployeeModel.Id =employeeDetail.Id;
        var result = await _deleteEmployeeModel.DeleteEmployeeAsync();
        DeleteEmployeeEvent?.Invoke(this,result);
    }


    public void EditDetails(EmployeeDetail employeeDetail)
    {
        Id=employeeDetail.Id;
        FirstName=employeeDetail.FirstName;
        LastName=employeeDetail.LastName;
        Avatar= employeeDetail.Avatar;
        Email=employeeDetail.Email;
        EditEvent?.Invoke(this,new EventArgs());
    }

    public async Task GetEmployeeListAsync()
    {
        IsLoading = true;
        IsShow = false;
        var result =await  _getEmployeeModel.GetEmployeeDetailAsync();
        EmployeeDetails = _getEmployeeModel.EmployeeDetails.ToObservableCollection();
        GetEmployeeEvent?.Invoke(this, result);
        IsLoading = false;
        IsShow = true;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
