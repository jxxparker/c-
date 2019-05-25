

using System.Collections.Generic;

namespace DeckOfCards
{
    public class Player
    {
        string name;
        public List<Card> hand;

        public Player(string person)
        {
            name = person;
            hand = new List<Card>();
        }

        public Card draw(Deck onDeck)
        {
            Card member = onDeck.deal();
            hand.Add(member);
            return member;
        }

        public Card discard(int i)
        {
            if (i < 0 || i > hand.Count)
            {

                return null;
            }
            else
            {
                //remove
                Card res = hand[i];
                hand.RemoveAt(i);
                return res;
            }
        }
    }
}