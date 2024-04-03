using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardMatchingGame
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;

    public enum CardSuit
    {
        Ace,
        Club,
        Diamond,
        Heart,
        WeirdClavar
    }


    public class Card : MonoBehaviour
    {
        public Sprite cardBack;
        public Sprite cardFront;
        public int cardId;
        public CardSuit cardSuit;

        private bool _isFlipped = false;
        private Image cardImage;
        public float flipSpeed = 1f;

        private void Start()
        {
            cardImage = GetComponent<Image>();
        }

        public void OnCardClicked()
        {
            if (!_isFlipped)
            {
                FlipCard(()=> { cardImage.sprite = cardFront; });
            }
        }

        public void ResetCard()
        {
            _isFlipped = false;
            FlipCard(()=> { cardImage.sprite = cardBack; });
            // Add animation or sound effect for resetting here
        }

        public bool IsFlipped()
        {
            return _isFlipped;
        }

        public int GetCardId()
        {
            return cardId;
        }

        public void FlipCard(Action callback = null)
        {
            StartCoroutine(FlipRoutine(callback));
        }

        private IEnumerator FlipRoutine(Action callback)
        {
            bool isShowingFront = true;
            float time = 0f;
            Vector3 startRotation = transform.eulerAngles;
            Vector3 endRotation = startRotation + new Vector3(0, 180, 0);

            while (time < 1f)
            {
                time += Time.deltaTime * flipSpeed;
                transform.eulerAngles = Vector3.Lerp(startRotation, endRotation, time);
                if (time >= 0.5f && isShowingFront)
                {
                    // Switch the card face here if needed
                    isShowingFront = false;
                }
                yield return null;
            }

            callback?.Invoke();
            // Ensure the final rotation is correct
            transform.eulerAngles = endRotation;
        }
    }

}
