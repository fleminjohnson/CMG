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
        public CardSuit cardSuit;

        private bool _isFlipped = false;
        private Image cardImage;
        private float maxRotation = 180;
        public float flipSpeed = 1f;


        private void Start()
        {
            cardImage = GetComponent<Image>();
        }

        public void OnCardClicked()
        {
            if (!_isFlipped)
            {
                _isFlipped = true;
                FlipCard(() =>
                {
                    cardImage.sprite = cardFront;
                    GameManager.Instance.AddCardToList(this);
                });
            }
        }

        public void ResetCard()
        {
            Debug.Log("Reset card");
            if (_isFlipped) // Only reset if the card is flipped
            {
                _isFlipped = false;
                FlipCard(() =>
                {
                    Debug.Log("Callback done");
                    cardImage.sprite = cardBack;
                });
            }
        }

        public void FlipCard(Action callback = null)
        {
            Debug.Log("Flip card");
            StartCoroutine(FlipRoutine(callback));
        }

        private IEnumerator FlipRoutine(Action callback)
        {
            float time = 0f;
            Vector3 startRotation = transform.eulerAngles;
            Vector3 endRotation = startRotation + new Vector3(0, maxRotation, 0);
            if(startRotation.y != 0)
            {
                endRotation = Vector3.zero;
            }
            while (time < 1)
            { 
                time += Time.deltaTime * flipSpeed;
                transform.eulerAngles = Vector3.Lerp(startRotation, endRotation, time);
                yield return null;
            }
            callback?.Invoke();
            transform.eulerAngles = endRotation; // Ensure the final rotation is correct
        }
    }

}
