using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CardMatchingGame
{
    public class CanvasManagement : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuCanvas;
        [SerializeField] private GameObject gameCanvas;
        [SerializeField] private TMP_Text turnCountText;
        [SerializeField] private TMP_Text matchCountText;

        private void Start()
        {
            SetTurnCount(0);
            SetMatchCount(0);
        }

        public void PlayGame(int difficulty)
        {
            mainMenuCanvas.SetActive(false);
            gameCanvas.SetActive(true);
        }

        public void ExitGame()
        {
            mainMenuCanvas.SetActive(true);
            gameCanvas.SetActive(false);
        }

        public void SetTurnCount(int turnCount)
        {
            turnCountText.text = turnCount.ToString();
        }

        public void SetMatchCount(int matchCount)
        {
            matchCountText.text = matchCount.ToString();
        }

    }
}
