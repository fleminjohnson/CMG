using System;
using UnityEngine;

namespace CardMatchingGame
{
    public enum GameState
    {
        MainMenu,
        GamePlay
    }

    public class GameManager : SingletonBehaviour<GameManager>
    {
        [SerializeField] private CanvasManagement canvasManagement;
        [SerializeField] private LevelManager levelManager;

        private int turnCount = 0;
        private int matchCount = 0;
        private int totalCellCount;
        private bool isLost = false;

        public int TotalCellCount
        {
            get => totalCellCount;
            set
            {
                totalCellCount = value;
                SetTotalCellCount();
                Debug.Log($"TotalCellCount set to {totalCellCount}");
            }
        }

        private void Start()
        {
            EventServices.Instance.OnWinning += OnWinningCallBack;

            if (SaveLoadManager.KeyExist(GameConstants.CurrentActiveLevel))
            {
                int currentIndex = SaveLoadManager.LoadInt(GameConstants.CurrentActiveLevel);
                levelManager.LoadGamePlayPrefab(currentIndex);
            }
            else
            {
                levelManager.LoadGamePlayPrefab(0);
            }
        }

        private void OnWinningCallBack()
        {
            canvasManagement.OnWinning();
        }

        private void SetTotalCellCount()
        {
            canvasManagement.SetTurnCount(turnCount, totalCellCount / 2);
            Debug.Log("Updated turn count on UI.");
        }

        private void ResetUIValues()
        {
            matchCount = 0;
            turnCount = 0;
            canvasManagement.SetMatchCount(matchCount);
            canvasManagement.SetTurnCount(turnCount, totalCellCount / 2);
        }

        public void IncrementMatchFound()
        {
            matchCount++;
            Debug.Log($"Match found. Total matches: {matchCount}.");

            canvasManagement.SetMatchCount(matchCount);

            if (matchCount == (totalCellCount / 2) & !isLost)
            {
                Debug.Log("All matches found, loading next level.");
                ResetUIValues();
                levelManager.SaveCurrentScene();
            }
        }

        public void IncrementTurnCount()
        {
            turnCount++;
            Debug.Log($"Turn incremented. Total turns: {turnCount}.");

            canvasManagement.SetTurnCount(turnCount, totalCellCount / 2);

            if (turnCount > totalCellCount / 2)
            {
                Debug.Log("Max turns exceeded, restarting level.");
                isLost = true;
                canvasManagement.OnLose();
            }
        }

        public void RestartButton()
        {
            levelManager.RestartLevel(() => { ResetUIValues(); });
        }

        private void OnDisable()
        {
            EventServices.Instance.OnWinning -= OnWinningCallBack;
        }

       
    }
}
