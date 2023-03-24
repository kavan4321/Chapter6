
using Chapter6.Model;
using Chapter6.Model.Page6Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chapter6.ViewModel.Page6ViewModel.ViewModelERegister;

public class RegisterVieModel:INotifyPropertyChanged
{
    private RegisterModel _registerModel;
    public event EventHandler<PageResult> RegisterEvent;

    private string _name;
    private string _email;
    private string _password;

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
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
    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }

    public ICommand RegisterCommand { get; private set; }
    public RegisterVieModel()
    {
        _registerModel= new RegisterModel();
        RegisterCommand = new Command(() => { _ = RegisterDetails(); });
    }

    public async Task RegisterDetails()
    {
        _registerModel.Name = _name;
        _registerModel.Email = _email;
        _registerModel.Password = _password;
        var result = await _registerModel.RegisterDetailsAsync();
        RegisterEvent?.Invoke(this, result);
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
