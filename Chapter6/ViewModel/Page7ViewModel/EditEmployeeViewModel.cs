using Chapter6.HttpModel.Page7HttpModel;
using Chapter6.Model;
using Chapter6.Model.Page7Model;
using CommunityToolkit.Maui.Alerts;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chapter6.ViewModel.Page7ViewModel.ViewModelEditEmployee;

public class EditEmployeeViewModel:INotifyPropertyChanged
{
    public event EventHandler<PageResult> EditEmployeeEvent;
    private UpdateEmployeeModel _updateEmployeeModel;
  
    private EmployeeDetail _employeeDetail;
    public EmployeeDetail EmployeeDetail
    {
        get => _employeeDetail;
        set
        {
            _employeeDetail = value;
            OnPropertyChanged();
        }
    }

    public ICommand UpdateCommand { get; private set; }

    public EditEmployeeViewModel()
    {
        _updateEmployeeModel= new UpdateEmployeeModel();
        UpdateCommand = new Command(() => { _ = UpdateDetailAsync(EmployeeDetail); });
    }


    public async Task UpdateDetailAsync(EmployeeDetail employeeDetail)
    {
        var FirstName = employeeDetail.FirstName;
        var LastName = employeeDetail.LastName;
        var Email = employeeDetail.Email;
        if (string.IsNullOrWhiteSpace(FirstName) &&
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
        else if (Email.IndexOf("@") == 0 || Email.IndexOf("@") == 0 ||
                !Email.Contains("@") || !Email.Contains(".") ||
                Email.EndsWith("@") || Email.EndsWith(".") ||
                Email.IndexOf("@") > Email.IndexOf(".")
                )
        {
            _ = Toast.Make("Please Enter valid Email", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }

        else
        {
            _updateEmployeeModel.Id = employeeDetail.Id;
            _updateEmployeeModel.FirstName = FirstName;
            _updateEmployeeModel.LastName = LastName;
            _updateEmployeeModel.Email = Email;
            var result = await _updateEmployeeModel.UpdateEmployeeAsync();
            EditEmployeeEvent?.Invoke(this, result);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
