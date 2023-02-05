// See https://aka.ms/new-console-template for more information

using CardGame.Models.Models;


Deck d = new Deck();

d.CreateStandardDeck();

Console.Write(d.ToString());

Console.WriteLine(d.CardsRemaining());

Console.WriteLine("-------------------Shuffling----------------");

d.Shuffle();

Console.Write(d.ToString());

Console.WriteLine("-------------------Draw a Card----------------");
Card draw = d.DealCard();

Console.WriteLine(draw.ToString());

Console.WriteLine("-------------------Remaining Cards in Deck----------------");

Console.WriteLine(d.CardsRemaining());

Console.WriteLine(d.ToString());