using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CMG
{
    public class CanvasManagement : MonoBehaviour
    {
        [SerializeField] private TMP_Text turnCountText;
        [SerializeField] private TMP_Text matchCountText;
        [SerializeField] private GameObject winningScreen;
        [SerializeField] private GameObject loseScreen;

        private void Start()
        {
            winningScreen.SetActive(false);
            loseScreen.SetActive(false);
        }

        public void SetTurnCount(int turnCount, int totalTurnCount)
        {
            turnCountText.text = $"{turnCount} / {totalTurnCount}";
        }

        public void SetMatchCount(int matchCount)
        {
            matchCountText.text = matchCount.ToString();
        }

        public void OnWinning()
        {
            winningScreen.SetActive(true);
        }

        public void OnLose()
        {
            loseScreen.SetActive(true);
        }
    }
}
