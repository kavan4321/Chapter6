
using Chapter6.Model.Page3Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chapter6.ViewModel.Page3ViewModel.ViewModelContact;

public class ContactViewModel:INotifyPropertyChanged
{
    public ObservableCollection<ContactModel> ContactDetails { get; set; }

    public ContactViewModel()
    {
       ContactDetails = new ObservableCollection<ContactModel>
       {
           new ContactModel()
           {
               Name="Virat kohli",
               UserImage="user3",
               Stutus="Hey there I am using WhatsApp",
           },
           new ContactModel()
           {
               Name="Elon Musk",
               UserImage="user5",
               Stutus="CEO of Tesla",
           },
            new ContactModel()
           {
               Name="Rohit Sharma",
               UserImage="user1",
               Stutus="Captain of Indian cricket team",
           },
            new ContactModel()
           {
               Name="Smriti Mandhana",
               UserImage="user4",
               Stutus="Urgent Call Only",
           },
       };
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
