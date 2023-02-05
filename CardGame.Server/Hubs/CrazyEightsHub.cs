using CardGame.Contracts;
using CardGame.Models.Entities;
using CardGame.Models.Models;
using CardGame.Server.Models;
using Microsoft.AspNetCore.SignalR;

namespace CardGame.Server.Hubs;

public class CrazyEightsHub : Hub, IGameHub
{
    public GameType gameType { get; set; }

    public List<ConnectedPlayer> Players { get; set; }
    public async Task AddPlayer()
    {
        await Clients.Caller.SendAsync("displayConnectionId", Context.ConnectionId);
    }

    public async Task PlayCard(Card card)
    {
        await Clients.Caller.SendAsync("cardPlayed", card);
    }

    public async Task DealCards()
    {
        //build a new deck 
        Deck d = new Deck(true);
        d.Shuffle();
        List<Card> myCards = new();
        List<Card> opponentCards = new();
        for (int i = 0; i < 7; i++)
        {
            myCards.Add(d.DealCard());
            opponentCards.Add(d.DealCard());
        }

        await Clients.All.SendAsync("deal", myCards);
    }
}