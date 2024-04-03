using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardMatchingGame
{
    using UnityEngine;

    public class Card : MonoBehaviour
    {
        public GameObject cardBack;
        public int cardId;

        private bool _isFlipped = false;
        public float flipSpeed = 1f;

        public void OnCardClicked()
        {
            if (!_isFlipped)
            {
                FlipCard();
            }
        }

        public void SetCard(int id, Sprite cardFace)
        {
            cardId = id;
            GetComponent<SpriteRenderer>().sprite = cardFace;
        }

        public void ResetCard()
        {
            _isFlipped = false;
            cardBack.SetActive(true);
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

        public void FlipCard()
        {
            StartCoroutine(FlipRoutine());
        }

        private IEnumerator FlipRoutine()
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

            // Ensure the final rotation is correct
            transform.eulerAngles = endRotation;
        }
    }

}
