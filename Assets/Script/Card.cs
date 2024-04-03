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
                    // Flip the sprite by multiplying the x component of localScale by -1
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                });
            }
        }

        public void SetDestroy()
        {
            StartCoroutine(DelayedDestroy(0.5f));
        }

        IEnumerator DelayedDestroy(float delay)
        {
            yield return new WaitForSeconds(delay);
            Destroy(gameObject);
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
            bool isFirst = true;

            if(startRotation.y != 0)
            {
                endRotation = Vector3.zero;
            }
            while (time < 1)
            { 
                time += Time.deltaTime * flipSpeed;
                transform.eulerAngles = Vector3.Lerp(startRotation, endRotation, time);
                yield return null;
                if(time >= 0.5f & isFirst)
                {
                    isFirst = false;
                    callback?.Invoke();
                }
            }
            transform.eulerAngles = endRotation; // Ensure the final rotation is correct
        }
    }

}
