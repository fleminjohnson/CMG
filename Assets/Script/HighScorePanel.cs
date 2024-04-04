using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CMG
{
    public class HighScorePanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text totalMatches;
        [SerializeField] private TMP_Text totalMismatches;

        private void OnEnable()
        {
            totalMatches.text = SaveLoadManager.LoadInt(GameConstants.TotalMatches).ToString();
            totalMismatches.text = SaveLoadManager.LoadInt(GameConstants.TotalMismatches).ToString();
        }
    }
}
