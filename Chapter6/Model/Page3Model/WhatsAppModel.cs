
namespace Chapter6.Model.Page3Model
{
   
    
    public enum Types
    {
        Group,
        Private,
    }
    public enum CallDirection
    {
        Incoming,
        OutGoing
    }
    public enum CallTypes
    {
        VoiceCall,
        VideoCall
    }
 
    public class CallModel
    {
        public Types Type { get; set; }
        public CallDirection Direction { get; set; }
        public CallTypes CallType { get; set; }
        public string Name { get; set; }
        public string UserImage { get; set; }
        public DateTime CallDate { get; set; }    
        public string CallImage { get;set; }
        public string InComeOutGoingImage { get;set; }
    }
    public class ChatModel
    {
        public Types Type { get; set; }
        public string ImageSource { get; set; }
        public string Name { get; set; }    
        public string Message { get; set; } 
        public DateTime MsgDate { get; set; }
        public string DisplayDate { get; set; }
        public int UnseenMsg { get; set; }
        public bool IsUnseenMsg { get; set; }

    }
    public class ContactModel
    {
        public string Name { get; set; }
        public string UserImage { get; set; }         
        public string Stutus { get; set; }
    }
}
