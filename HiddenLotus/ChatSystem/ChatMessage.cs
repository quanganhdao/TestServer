namespace HiddenLotus.ChatSystem
{
    public class ChatMessage
    {
        public static string type = "chat";
        public string sender;
        public string channel;
        public string message;
        public ChatMessage() { }

        public ChatMessage(string sender, string channel, string message)
        {
            this.sender = sender;
            this.channel = channel;
            this.message = message;
        }
    }
}
