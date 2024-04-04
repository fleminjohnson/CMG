using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CardMatchingGame
{
    public class CanvasManagement : MonoBehaviour
    {
        [SerializeField] private TMP_Text turnCountText;
        [SerializeField] private TMP_Text matchCountText;

        public void SetTurnCount(int turnCount, int totalTurnCount)
        {
            turnCountText.text = $"{turnCount} / {totalTurnCount}";
        }

        public void SetMatchCount(int matchCount)
        {
            matchCountText.text = matchCount.ToString();
        }
    }
}
