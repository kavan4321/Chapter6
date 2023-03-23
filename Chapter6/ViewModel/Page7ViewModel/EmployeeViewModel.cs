using Chapter6.HttpModel.Page7HttpModel;
using Chapter6.Model;
using Chapter6.Model.Page7Model;
using CommunityToolkit.Maui.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chapter6.ViewModel.Page7ViewModel.ViewModelEmployee;

public class EmployeeViewModel : INotifyPropertyChanged
{
    private GetEmployeeModel _getEmployeeModel;
    public event EventHandler<PageResult> GetEmployeeEvent;
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

    private int _id;
    private string _firstName;
    private string _lastName;
    private string _avatar;
    private string _email;

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
        EditCommand = new Command<EmployeeDetail>(EditDetails);
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
        var result =await  _getEmployeeModel.GetEmployeeDetailAsync();
        EmployeeDetails = _getEmployeeModel.EmployeeDetails.ToObservableCollection();
        GetEmployeeEvent?.Invoke(this, result);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
