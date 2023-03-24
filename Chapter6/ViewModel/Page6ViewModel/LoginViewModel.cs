
using Chapter6.Model;
using Chapter6.Model.Page6Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chapter6.ViewModel.Page6ViewModel.ViewModelLogin;

public class LoginViewModel:INotifyPropertyChanged
{
    private LoginModel _loginModel;
    public event EventHandler<PageResult> LoginEvent;
   
    private string _email;
    private string _password;
    public string Email
    {
        get => _email;
        set
        {
            _email= value;
            OnPropertyChanged();
        }
    }
    public string Password
    {
        get => _password;
        set
        {
            _password= value;
            OnPropertyChanged();
        }
    }

    public ICommand LoginCommand { get;private set; }
    public LoginViewModel()
    {
        _loginModel = new LoginModel();
        LoginCommand = new Command(() => { _ = LoginDetails(); });
    }

    public async Task LoginDetails()
    {
        _loginModel.Email = _email;
        _loginModel.Password = _password;
        var result =await _loginModel.LoginDetailsAsync();
        LoginEvent?.Invoke(this, result);
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
