using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        Croupier croupier = new Croupier();
        
        Player player = new Player();
        
        Console.WriteLine("Сколько карт получить?");
        string input = Console.ReadLine();
        
        if (int.TryParse(input, out int cardCount))
        {
            croupier.DealCards(player, cardCount);
            
            player.PrintCards();
        }
        else
        {
            Console.WriteLine("Некорректный ввод. Введите число.");
        }
    }
}

public class Croupier
{
    private Deck _deck;
    
    public Croupier()
    {
        _deck = new Deck();
    }
    
    public void DealCards(Player player, int cardCount)
    {
        if (_deck.Count() < cardCount)
        {
            Console.WriteLine($"В колоде недостаточно карт. Осталось только {_deck.Count()} карт.");
            return;
        }
        
        Card[] cards = _deck.PopCards(cardCount);
        
        foreach (Card card in cards)
        {
            player.ReceiveCard(card);
        }
        
        Console.WriteLine($"Раздано {cardCount} карт игроку.");
    }
}

public class Player
{
    private List<Card> _cards;
    
    public Player()
    {
        _cards = new List<Card>();
    }
    
    public void ReceiveCard(Card card)
    {
        _cards.Add(card);
    }
    
    public void PrintCards()
    {
        if (_cards.Count == 0)
        {
            Console.WriteLine("У игрока нет карт.");
            return;
        }
        
        Console.WriteLine($"Карты игрока ({_cards.Count} шт.):");
        foreach (Card card in _cards)
        {
            Console.WriteLine($"  - {card}");
        }
    }
    
    public List<Card> GetCards()
    {
        return new List<Card>(_cards);
    }
}

public class Deck
{
    private Stack<Card> _stackCards;

    public Deck()
    {
        CreateDeck();
    }

    public Card PopCard()
    {
        return _stackCards.Pop();
    }

    public Card[] PopCards(int count)
    {
        List<Card> listcards = new List<Card>(_stackCards);

        List<Card> temporaryList = listcards.GetRange(listcards.Count - count, count);

        listcards.RemoveRange(listcards.Count - count, count);

        Card[] cardsArray = temporaryList.ToArray();
        
        _stackCards = new Stack<Card>(listcards);

        return cardsArray;
    }

    public Stack<Card> Get()
    {
        return new Stack<Card>(_stackCards);
    }

    private void Shuffle(List<Card> cards)
    {
        Random random = new Random();

        for (int shuffledElement = cards.Count - 1; shuffledElement > 0; shuffledElement--)
        {
            int randomIndex = random.Next(shuffledElement + 1);

            (cards[shuffledElement], cards[randomIndex]) =
                (cards[randomIndex], cards[shuffledElement]);
        }
    }

    private void CreateDeck()
    {
        List<Card> cards = new List<Card>();

        string[] strings = new[]
        {
            "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
        };

        string[] meaning = new[]
        {
            "Крести", "Буби", "Червы", "Пики"
        };

        foreach (var valueMeaning in meaning)
        {
            foreach (var valueSuit in strings)
            {
                cards.Add(new Card(valueSuit, valueMeaning));
            }
        }

        Shuffle(cards);

        _stackCards = new Stack<Card>(cards);
    }

    public int Count()
    {
        return _stackCards.Count;
    }
}

public class Card
{
    public Card(string suit, string rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public string Suit { get; }

    public string Rank { get; }
    
    public override string ToString()
    {
        return $"{Rank} {Suit}";
    }
}