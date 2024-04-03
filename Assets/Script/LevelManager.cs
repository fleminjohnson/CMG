using System.Collections.Generic;
using UnityEngine;

namespace CardMatchingGame
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private List<Transform> levelPrefabList;
        [SerializeField] private Transform gameplayCanvas;

        private int currentActiveLevelCount = 0;
        private GameObject currentActiveLevel = null;

        public void LoadNextLevel()
        {
            if (currentActiveLevelCount <= levelPrefabList.Count - 1)
            {
                if (currentActiveLevel != null)
                    Destroy(currentActiveLevel);

                currentActiveLevel = Instantiate(levelPrefabList[currentActiveLevelCount], gameplayCanvas).gameObject;
                currentActiveLevelCount++;
            }
            else
            {
                Debug.Log("Level is larger than in LevelList");
            }
        }
    }
}
