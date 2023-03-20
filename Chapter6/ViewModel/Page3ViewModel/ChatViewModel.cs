using Chapter6.Model.Page3Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chapter6.ViewModel.Page3ViewModel.ViewModelChat;

public class ChatViewModel:INotifyPropertyChanged
{

    public  ObservableCollection<WhatsAppModel> ChatDetails { get; set; }


    public ChatViewModel()
    {
        ChatValues()
    }

    public void ChatValues()
    {
        ChatDetails = new ObservableCollection<WhatsAppModel>
        {
            new WhatsAppModel()
            {
                Type=Types.Group,
                Name="Whitemans Chat",
                ImageSource="user1",
                Message="Yeah, I think I know what",
                UnseenMsg=2,
                MsgDate= new DateTime(2023,03,04)
            },
             new WhatsAppModel()
            {
                Type=Types.Private,
                Name="Alice Whiteman",
                ImageSource="user2",
                Message="Image",
                MsgDate= new DateTime(2023,03,04)
            };
    };
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
