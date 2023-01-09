using System.ComponentModel;

namespace CardGame.Models.Entities;

public class GameType
{
    public Guid Id { get; set; }
    public string GameName { get; set; }
    public int MaxPlayers { get; set; }
    
}