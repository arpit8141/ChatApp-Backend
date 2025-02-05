using ChatApp.Application.Services;
using ChatApp.Domain.DTOs;
using ChatApp.Domain.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Infrastructure.Hubs;

public class ChatHub : Hub
{
    private readonly ChatService _chatService;

    public ChatHub(ChatService chatService)
    {
        _chatService = chatService;
    }

    public async Task SendMessage(MessageDto messageDto)
    {
        var message = new Message
        {
            User = messageDto.User,
            Text = messageDto.Text
        };

        _chatService.AddMessage(message);
        await Clients.All.SendAsync("ReceiveMessage", message);
    }

    public List<Message> GetChatHistory()
    {
        return _chatService.GetMessages();
    }
}
