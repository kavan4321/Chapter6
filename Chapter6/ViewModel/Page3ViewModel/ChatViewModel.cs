using Chapter6.Model.Page3Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chapter6.ViewModel.Page3ViewModel.ViewModelChat;

public class ChatViewModel:INotifyPropertyChanged
{

    public  ObservableCollection<ChatModel> ChatDetails { get; set; }


    public ChatViewModel()
    {
        ChatValues();
        UnSeenChange();
        DisplayDateFormate();
    }

    public void ChatValues()
    {
        
        ChatDetails = new ObservableCollection<ChatModel>
        {
            new ChatModel()
            {
                Type=Types.Group,
                Name="Whitemans Chat",
                ImageSource="user1",
                Message="Yeah, I think I know what to do next?",
                UnseenMsg=2,
                MsgDate= new DateTime(2023,03,21)
            },
             new ChatModel()
            {
                Type=Types.Private,
                Name="Virat Kohli",
                ImageSource="user3",
                Message="📷 Image",
                MsgDate= new DateTime(2023,03,20)
            },

              new ChatModel()
            {
                Type=Types.Private,
                Name="Smriti Mandhana",
                ImageSource="user4",
                Message="You: Sounds Good",
                MsgDate= new DateTime(2023,02,04)
            }
        };
    }

    public void DisplayDateFormate()
    {
        foreach(var item in ChatDetails)
        {
            if(item.MsgDate== DateTime.Today)
            {
                item.DisplayDate = "Today";
            }
            else if(item.MsgDate== DateTime.Today.AddDays(-1) )
            {
                item.DisplayDate = "Yesterday";
            }
            else if(item.MsgDate > DateTime.Today.AddDays(-6) && item.MsgDate < DateTime.Today.AddDays(-1))
            {
                item.DisplayDate = item.MsgDate.DayOfWeek.ToString();
            }
            else
            {
                item.DisplayDate= item.MsgDate.ToString("dd/M/yyyy");
            }
        }
    }

    public void UnSeenChange()
    {
       foreach(var item in ChatDetails)
        {
            if (item.UnseenMsg > 0)
            {
                item.IsUnseenMsg = true;
            }
            else
            {
                item.IsUnseenMsg = false;
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
