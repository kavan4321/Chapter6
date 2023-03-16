
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chapter6.ViewModel.Page2ViewModel.ViewModelAddActivity;

public class AddActivityViewModel:INotifyPropertyChanged
{

    public string Name { get; set; }
    public DateTime DueDate { get; set; }
    public bool Complete { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
