namespace IO_API.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderID { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime SentTime { get; set; }
    }
}
