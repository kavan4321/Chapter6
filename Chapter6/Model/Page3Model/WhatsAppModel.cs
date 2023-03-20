
namespace Chapter6.Model.Page3Model
{
   
    public enum Types
    {
        Group,
        Private
    }
    public class WhatsAppModel
    {
        public Types Type { get; set; }
        public string ImageSource { get; set; }
        public string Name { get; set; }    
        public string Message { get; set; } 
        public DateTime MsgDate { get; set; }
        public int UnseenMsg { get; set; }

    }
}
