using Azure;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Text;

namespace HiddenLotus.ChatSystem
{
    public class ChatSystem
    {
        private WebSocket WebSocket;

        public ChatSystem(WebSocket webSocket)
        {
            WebSocket = webSocket;
        }

        public ChatSystem()
        {
            
        }
        public void Process(ChatMessage chatMessage)
        {
            if (chatMessage == null)
            {
                var nullMessage = "Message is null";
                var nullBuffer = UTF8Encoding.UTF8.GetBytes(nullMessage);
                WebSocket.SendAsync(new ArraySegment<byte>(nullBuffer), WebSocketMessageType.Text, true, CancellationToken.None);
                return;

            }
            Console.WriteLine($"Sender {chatMessage.sender}, Channel {chatMessage.channel}, message {chatMessage.message}");
            var dataInString = JsonConvert.SerializeObject(chatMessage);
            byte[] buffer = Encoding.UTF8.GetBytes(dataInString);

            WebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}
