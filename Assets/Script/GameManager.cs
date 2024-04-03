using UnityEngine;

namespace CardMatchingGame
{
    public class GameManager : SingletonBehaviour<GameManager>
    {
        [SerializeField] private CanvasManagement canvasManagement;
        [SerializeField] private LevelManager levelManager;

        private int turnCount = 0;
        private int matchCount = 0;
        private int totalCellCount;

        public int TotalCellCount
        {
            get => totalCellCount;
            set
            {
                totalCellCount = value;
                SetTotalCellCount();
            }
        }

        private void SetTotalCellCount()
        {
            canvasManagement.SetTurnCount(turnCount, totalCellCount / 2);
        }

        public void PlayGame()
        {
            canvasManagement.PlayGame();
            levelManager.LoadNextLevel();
        }

        public void MatchFound()
        {
            matchCount++;
            canvasManagement.SetMatchCount(matchCount);

            if (matchCount == (totalCellCount / 2))
            {
                matchCount = 0;
                turnCount = 0;
                levelManager.LoadNextLevel();
            }
            canvasManagement.SetMatchCount(matchCount);
            canvasManagement.SetTurnCount(turnCount, totalCellCount / 2);
        }

        public void TurnCount()
        {
            turnCount++;
            canvasManagement.SetTurnCount(turnCount, totalCellCount / 2);

            if (turnCount == totalCellCount / 2)
            {
                Debug.Log("Level Over");
            }
        }
    }
}
