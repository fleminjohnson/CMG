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
        private int totalCellCount;
        private int currentActiveLevelCount = 0;
        private GameObject currentActiveLevel = null;

        public int TotalCellCount { get => totalCellCount; set => totalCellCount = value; }

        public void PlayGame()
        {
            canvasManagement.PlayGame();
            LoadNextLevel();
        }

        public void LoadNextLevel()
        {
            if(currentActiveLevelCount <= levelPrefabList.Count-1)
            {
                if(currentActiveLevelCount > 0 & currentActiveLevel != null)
                    Destroy(currentActiveLevel);

                turnCount = 0;
                matchCount = 0;
                canvasManagement.SetMatchCount(matchCount);
                canvasManagement.SetTurnCount(turnCount);

                currentActiveLevel = Instantiate(levelPrefabList[currentActiveLevelCount], gameplayCanvas).gameObject;
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

            if(matchCount == (totalCellCount / 2))
            {
                LoadNextLevel();
            }
        }

        public void TurnCount()
        {
            turnCount++;
            canvasManagement.SetTurnCount(turnCount);
        }
    }
}
