using CardGame.Contracts;
using CardGame.Models.Entities;
using Microsoft.AspNetCore.SignalR;

namespace CardGame.Server.Hubs;

public class CrazyEightsHub : Hub, IGameHub 
{
    public GameType gameType { get; set; }
}