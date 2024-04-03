using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardMatchingGame
{
    public class GameManager : SingletonBehaviour<GameManager>
    {
        [SerializeField] private CanvasManagement canvasManagement;
        [SerializeField] private List<Transform> levelPrefabList;
        [SerializeField] private Transform gameplayCanvas;

        private int turnCount = 0;
        private int matchCount = 0;
        private int currentActiveLevelCount = 0;
        private Transform currentActiveLevel = null;

        public void PlayGame()
        {
            canvasManagement.PlayGame();
            LoadNextLevel();
        }

        public void LoadNextLevel()
        {
            if(currentActiveLevelCount <= levelPrefabList.Count)
            {
                if(currentActiveLevelCount > 0 & currentActiveLevel != null)
                    Destroy(currentActiveLevel);

                currentActiveLevel = Instantiate(levelPrefabList[currentActiveLevelCount], gameplayCanvas);
                currentActiveLevelCount++;
            }
            else
            {
                Debug.Log("Level is larger than in LevelList");
            }
        }

        public void MatchFound()
        {
            matchCount++;
            canvasManagement.SetMatchCount(matchCount);
        }

        public void TurnCount()
        {
            turnCount++;
            canvasManagement.SetTurnCount(turnCount);
        }
    }
}
