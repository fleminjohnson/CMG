using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CardMatchingGame
{
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
        // Public variables are accessible outside of this class
        [SerializeField] private Sprite cardBack;
        [SerializeField] private Sprite cardFront;
        [SerializeField] private CardSuit cardSuit;
        [SerializeField] private float flipSpeed = 1f;

        // Private variables are only accessible within this class
        private bool _isFlipped = false;
        private Image cardImage;
        private float maxRotation = 180;
        private GamePlayManager gamePlayManager;

        public CardSuit CardSuit { get => cardSuit; set => cardSuit = value; }

        // Start is called before the first frame update
        private void Start()
        {
            cardImage = GetComponent<Image>();
            gamePlayManager = transform.parent.GetComponent<GamePlayManager>();
        }

        // Called when the card is clicked
        public void OnCardClicked()
        {
            if (!_isFlipped)
            {
                _isFlipped = true;
                FlipCard(() =>
                {
                    cardImage.sprite = cardFront;
                    gamePlayManager.AddCardToList(this);
                    FlipScale();
                });
            }
        }

        // Sets the card to be destroyed after a delay
        public void SetDestroy()
        {
            StartCoroutine(DelayedDestroy(0.5f));
        }

        // Resets the card to its original state
        public void ResetCard()
        {
            if (_isFlipped)
            {
                _isFlipped = false;
                FlipCard(() =>
                {
                    cardImage.sprite = cardBack;
                    FlipScale();
                });
            }
        }

        // Initiates the card flipping animation
        public void FlipCard(Action callback = null)
        {
            StartCoroutine(FlipRoutine(callback));
        }

        // Flips the sprite by modifying its localScale
        private void FlipScale()
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }

        // Coroutine for delaying the destruction of the object
        private IEnumerator DelayedDestroy(float delay)
        {
            yield return new WaitForSeconds(delay);
            Destroy(gameObject);
        }

        // Coroutine for animating the card flip
        private IEnumerator FlipRoutine(Action callback)
        {
            float time = 0f;
            Vector3 startRotation = transform.eulerAngles;
            Vector3 endRotation = startRotation + new Vector3(0, maxRotation, 0);
            bool isFirst = true;

            if (startRotation.y != 0)
            {
                endRotation = Vector3.zero;
            }

            while (time < 1)
            {
                time += Time.deltaTime * flipSpeed;
                transform.eulerAngles = Vector3.Lerp(startRotation, endRotation, time);
                yield return null;

                if (time >= 0.5f && isFirst)
                {
                    isFirst = false;
                    callback?.Invoke();
                }
            }

            transform.eulerAngles = endRotation; // Ensure the final rotation is correct
        }
    }
}
