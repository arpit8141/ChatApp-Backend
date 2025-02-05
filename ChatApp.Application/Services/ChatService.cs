using ChatApp.Domain.Models;

namespace ChatApp.Application.Services;

public class ChatService
{
    private readonly List<Message> _messages = new();

    public List<Message> GetMessages() => _messages;

    public void AddMessage(Message message) => _messages.Add(message);
}
