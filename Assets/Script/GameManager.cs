using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardMatchingGame
{
    public class GameManager : MonoBehaviour
    {
        private List<Card> cardList = new List<Card>();

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // Example usage
            if (cardList.Count == 2)
            {
                CheckCards();
            }
        }

        public void AddCardToList(Card card)
        {
            cardList.Add(card);
            if (cardList.Count == 2)
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
            if (cardList.Count >= 2)
            {
                if (cardList[0].cardSuit == cardList[1].cardSuit)
                {
                    Debug.Log("Found match");
                    cardList.Clear();
                }
                else
                {
                    Debug.Log("Reset");
                }
            }
        }
    }
}
