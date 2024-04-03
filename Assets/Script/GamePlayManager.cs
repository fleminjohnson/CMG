using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardMatchingGame
{
    public class GamePlayManager : MonoBehaviour
    {
        [SerializeField] private FlexibleGridLayout flexibleGridLayout;

        private List<Card> cardList = new List<Card>();
        private int maxCount = 2;

        private void Start()
        {
            GameManager.Instance.TotalCellCount = flexibleGridLayout.GetCellCount();
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
                if (cardList[0].CardSuit == cardList[1].CardSuit)
                {
                    Debug.Log("Found match");
                    cardList[0].SetDestroy();
                    cardList[1].SetDestroy();
                    GameManager.Instance.MatchFound();
                }
                else
                {
                    Debug.Log("Reset");
                    cardList[0].ResetCard();
                    cardList[1].ResetCard();
                }
                cardList.Clear();
                GameManager.Instance.TurnCount();
            }
        }
    }
}
