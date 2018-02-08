using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem_3___Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            var playerOneDeck = Console.ReadLine().Split();
            var playerTwoDeck = Console.ReadLine().Split();
            string pattern = @"(?<number>\d+)(?<char>[A-Za-z])";
            var cardMatcher = new Regex(pattern);
            var firstPlayerCards = new Queue<Card>();
            var secondPlayerCards = new Queue<Card>();
            int turns = 0;

            FillUpDecks(playerOneDeck, playerTwoDeck, cardMatcher, firstPlayerCards, secondPlayerCards);

            while (turns < 1_000_000)
            {
                if (firstPlayerCards.Count == 0 || secondPlayerCards.Count == 0)
                {
                    break;
                }
                turns++;

                var playerOneCard = firstPlayerCards.Dequeue();
                var playerTwoCard = secondPlayerCards.Dequeue();

                if (playerOneCard.numberPower > playerTwoCard.numberPower)
                {
                    firstPlayerCards.Enqueue(playerOneCard);
                    firstPlayerCards.Enqueue(playerTwoCard);
                }
                else if (playerOneCard.numberPower < playerTwoCard.numberPower)
                {
                    secondPlayerCards.Enqueue(playerTwoCard);
                    secondPlayerCards.Enqueue(playerOneCard);
                }
                else
                {

                    List<Card> allCards = new List<Card>();
                    allCards.Add(playerOneCard);
                    allCards.Add(playerTwoCard);

                    bool someoneWon = false;

                    while (!someoneWon)
                    {
                        List<Card> firstPlayerWarCards = new List<Card>();
                        List<Card> secondPlayerWarCards = new List<Card>();
                        if (firstPlayerCards.Count < 3 && secondPlayerCards.Count >= 3)
                        {
                            Console.WriteLine(playerTwoWins(turns));
                            return;
                        }
                        else if (secondPlayerCards.Count < 3 & firstPlayerCards.Count >= 3)
                        {
                            Console.WriteLine(playerOneWins(turns));
                            return;
                        }
                        else if (firstPlayerCards.Count < 3 && secondPlayerCards.Count < 3)
                        {
                            Console.WriteLine(Draw(turns));
                            return;
                        }

                        someoneWon = War(firstPlayerCards, secondPlayerCards, allCards, someoneWon, firstPlayerWarCards, secondPlayerWarCards);
                    }
                }
            }
            DetermineWinner(firstPlayerCards, secondPlayerCards, turns);
        }

        private static bool War(Queue<Card> firstPlayerCards, Queue<Card> secondPlayerCards, List<Card> allCards, bool someoneWon, List<Card> firstPlayerWarCards, List<Card> secondPlayerWarCards)
        {
            for (int i = 0; i < 3; i++)
            {
                var plOneCurrCard = firstPlayerCards.Dequeue();
                var plTwoCurrCard = secondPlayerCards.Dequeue();
                firstPlayerWarCards.Add(plOneCurrCard);
                secondPlayerWarCards.Add(plTwoCurrCard);
                allCards.Add(plOneCurrCard);
                allCards.Add(plTwoCurrCard);
            }

            var playerOneTotalSum = firstPlayerWarCards.Select(c => c.charPower).Sum();
            var playerTwoTotalSum = secondPlayerWarCards.Select(c => c.charPower).Sum();

            if (playerOneTotalSum > playerTwoTotalSum)
            {
                foreach (var card in
                    allCards.OrderByDescending(c => c.numberPower).ThenByDescending(c => c.charPower))
                {
                    firstPlayerCards.Enqueue(card);
                }
                someoneWon = true;
            }
            else if (playerOneTotalSum < playerTwoTotalSum)
            {
                secondPlayerWarCards.AddRange(firstPlayerWarCards);
                foreach (var card in allCards.OrderByDescending(c => c.numberPower).ThenByDescending(c => c.charPower))
                {
                    secondPlayerCards.Enqueue(card);
                }
                someoneWon = true;
            }

            return someoneWon;
        }

        private static void DetermineWinner(Queue<Card> firstPlayerCards, Queue<Card> secondPlayerCards, int turns)
        {
            if (turns == 1_000_000)
            {
                if (firstPlayerCards.Count > secondPlayerCards.Count)
                {
                    Console.WriteLine(playerOneWins(turns));
                }
                else
                {
                    Console.WriteLine(playerTwoWins(turns));
                }
                return;
            }
            if (firstPlayerCards.Any() && !secondPlayerCards.Any())
            {
                Console.WriteLine(playerOneWins(turns));
            }
            else if (secondPlayerCards.Any() && !firstPlayerCards.Any())
            {
                Console.WriteLine(playerTwoWins(turns));
            }
            else
            {
                Console.WriteLine(Draw(turns));
            }
        }

        public static string playerOneWins(int turns)
        {
            return $"First player wins after {turns} turns";
        }
        public static string playerTwoWins(int turns)
        {
            return $"Second player wins after {turns} turns";
        }
        public static string Draw(int turns)
        {
            return $"Draw after {turns} turns";
        }

        private static void FillUpDecks
            (string[] playerOneDeck, string[] playerTwoDeck, 
            Regex cardMatcher, Queue<Card> firstPlayerCards,
            Queue<Card> secondPlayerCards)
        {
            for (int i = 0; i < playerOneDeck.Length; i++)
            {
                var tempCard = playerOneDeck[i];
                int cardNumber = int.Parse(tempCard.Substring(0, tempCard.Length-1));
                int cardLetterNum = tempCard[tempCard.Length - 1];

                var currentCard = new Card
                {
                    numberPower = cardNumber,
                    charPower = cardLetterNum
                };

                firstPlayerCards.Enqueue(currentCard);
            }

            for (int i = 0; i < playerTwoDeck.Length; i++)
            {
                var tempCard = playerTwoDeck[i];
                int cardNumber = int.Parse(tempCard.Substring(0, tempCard.Length - 1));
                int cardLetterNum = tempCard[tempCard.Length - 1];

                var currentCard = new Card
                {
                    numberPower = cardNumber,
                    charPower = cardLetterNum
                };

                secondPlayerCards.Enqueue(currentCard);
            }
        }
    }
}
