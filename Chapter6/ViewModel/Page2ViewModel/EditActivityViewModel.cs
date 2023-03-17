using Chapter6.HttpModel.Page2HttpModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chapter6.ViewModel.Page2ViewModel.ViewModelEdit;

public class EditActivityViewModel : INotifyPropertyChanged
{

    private ActivityDetail _activityDetail;
    public ActivityDetail ActivityDetail
    {
        get => _activityDetail;
        set
        {
            _activityDetail = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
