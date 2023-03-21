
using Chapter6.Model.Page3Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chapter6.ViewModel.Page3ViewModel.ViewModelCall;

public class CallViewModel : INotifyPropertyChanged
{
    public ObservableCollection<CallModel> CallDetails { get; set; }   

    public  CallViewModel()
    {
        CallValues();
        CallDetail();
    }

    public void CallValues()
    {
        CallDetails=new ObservableCollection<CallModel>
        {
             new CallModel()
            {
                Type=Types.Group,
                CallType=CallTypes.VoiceCall,
                Direction=CallDirection.OutGoing,
                Name="Whitemans Chat",
                UserImage="user1",
                CallDate= new DateTime(2023,03,21)
            },
             new CallModel()
            {
                Type=Types.Private,
                CallType=CallTypes.VideoCall,
                Direction=CallDirection.Incoming,
                Name="Virat Kohli",
                UserImage="user3",
                CallDate= new DateTime(2023,03,20)
            },

              new CallModel()
            {
                Type=Types.Private,
                CallType=CallTypes.VideoCall,
                Direction=CallDirection.Incoming,
                Name="Smriti Mandhana",
                UserImage="user4",
                CallDate= new DateTime(2023,02,04)
            }
        };
    }

    public void CallDetail()
    {
        foreach(var item in CallDetails)
        {
            if (item.CallType == CallTypes.VoiceCall)
            {
                item.CallImage = "recivecall";
            }
            else
            {
                item.CallImage = "call";
            }
        }

        foreach(var item in CallDetails)
        {
            if (item.Direction == CallDirection.Incoming)
            {
                item.InComeOutGoingImage = "callimage1";
            }
            else
            {
                item.InComeOutGoingImage = "callimage";
            }
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
