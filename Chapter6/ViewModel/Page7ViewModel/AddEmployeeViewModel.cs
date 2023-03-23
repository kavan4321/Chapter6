
using Chapter6.Model;
using Chapter6.Model.Page7Model;
using CommunityToolkit.Maui.Alerts;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chapter6.ViewModel.Page7ViewModel.ViewModelAddEmployee;

public class AddEmployeeViewModel:INotifyPropertyChanged
{
    private AddEmployeeModel _addEmployeeModel;

    private string _firstName;
    private string _lastName;
    private string _email;
    private string _avatar;
    public string FirstName
    {
        get => _firstName;
        set
        {
            _firstName=value;
            OnPropertyChanged();
        }
    }
    public string LastName
    {
        get => _lastName;
        set
        {
            _lastName=value; 
            OnPropertyChanged();
        }
    }
    public string Email
    {
        get => _email;
        set
        {
            _email=value;
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

    public ICommand AddCommand { get; private set; }
    public event EventHandler<PageResult> AddEmployeeEvent;

    public AddEmployeeViewModel()
    {
        _addEmployeeModel=new AddEmployeeModel();
        AddCommand = new Command(() => { _ = AddEmployeeDetail(); });
    }

    public async Task AddEmployeeDetail()
    {
        if( string.IsNullOrWhiteSpace(FirstName) && 
            string.IsNullOrWhiteSpace(LastName) && 
            string.IsNullOrWhiteSpace(Email))
        {
            _ = Toast.Make("Please Enter values", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
        else if (string.IsNullOrWhiteSpace(FirstName))
        {
            _ = Toast.Make("Please Enter FirstName", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
        else if (string.IsNullOrWhiteSpace(LastName))
        {
            _ = Toast.Make("Please Enter LastName", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
        else if (string.IsNullOrWhiteSpace(Email))
        {
            _ = Toast.Make("Please Enter Email", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
        else if( Email.IndexOf("@") ==0  || Email.IndexOf("@") == 0 ||  
                !Email.Contains("@") || !Email.Contains(".") || 
                Email.EndsWith("@")  || Email.EndsWith(".")  ||
                Email.IndexOf("@") > Email.IndexOf(".")
                )
        {
            _ = Toast.Make("Please Enter valid Email", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
        
        /*else if(Email.IndexOf("@") != 0 && Email.IndexOf("@") != 0 &&
                Email.Contains("@") && Email.Contains(".") &&
                !Email.EndsWith("@") && !Email.EndsWith(".") &&
                Email.IndexOf("@") < Email.IndexOf(".") )
        { }*/
        else
        {
            _addEmployeeModel.FirstName = FirstName;
            _addEmployeeModel.LastName = LastName;
            _addEmployeeModel.Email = Email;
            var result = await _addEmployeeModel.AddEmployeeDetailsAsync();
            AddEmployeeEvent?.Invoke(this, result);
        }
    }
   

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
