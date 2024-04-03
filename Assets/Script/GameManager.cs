using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardMatchingGame
{
    public class GameManager : SingletonBehaviour<GameManager>
    {
        private List<Card> cardList = new List<Card>();
        private int maxCount = 2;

        // Start is called before the first frame update
        void Start()
        {

        }

        public void AddCardToList(Card card)
        {
            cardList.Add(card);
            if (cardList.Count == maxCount)
            {
                CheckCards();
            }
        }

        public Card RemoveCardFromList()
        {
            if (cardList.Count > 0)
            {
                Card cardToRemove = cardList[0];
                cardList.RemoveAt(0);
                return cardToRemove;
            }
            return null; // or handle this case as needed
        }

        private void CheckCards()
        {
            if (cardList.Count >= maxCount)
            {
                if (cardList[0].cardSuit == cardList[1].cardSuit)
                {
                    Debug.Log("Found match");
                }
                else
                {
                    Debug.Log("Reset");
                    cardList[0].ResetCard();
                    cardList[1].ResetCard();
                }
                cardList.Clear();
            }
        }
    }
}
