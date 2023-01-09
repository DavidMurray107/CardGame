using CardGame.Models.Entities;

namespace CardGame.Contracts;

public interface IGameHub
{
   public GameType gameType { get; set; }
}