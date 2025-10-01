using HiddenLotus.ChatSystem;
using Newtonsoft.Json;
using WebSocketSharp;
using WebSocketSharp.Server;

public class ChatBehavior : WebSocketBehavior
{
	protected override void OnMessage(MessageEventArgs e)
	{

		// Broadcast tin nhắn đến tất cả client khác
		Sessions.Broadcast(e.Data);
		Console.WriteLine($"Message: {e.Data}");
	}

	protected override void OnOpen()
	{
		Console.WriteLine("Client connected");
		// Gửi thông báo chào mừng
		Send("Welcome to the chat!");
	}

	protected override void OnClose(CloseEventArgs e)
	{
		Console.WriteLine("Client disconnected");
	}
}