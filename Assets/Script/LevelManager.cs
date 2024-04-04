using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace CardMatchingGame
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private List<Transform> levelPrefabList;
        [SerializeField] private Transform gameplayCanvas;

        private int currentActiveLevelCount = 0;
        private GameObject currentActiveLevel = null;

        public void SaveCurrentScene()
        {
            Debug.Log("Current active level " + currentActiveLevelCount);

            if (SaveLoadManager.KeyExist(GameConstants.CurrentActiveLevel))
            {
                currentActiveLevelCount = SaveLoadManager.LoadInt(GameConstants.CurrentActiveLevel);
            }

            currentActiveLevelCount++;
            if(currentActiveLevelCount < levelPrefabList.Count)
            {
                SaveLoadManager.SaveInt(GameConstants.CurrentActiveLevel, currentActiveLevelCount);

                Scene currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currentScene.buildIndex);
            }
            else
            {
                EventServices.Instance.InvokeOnWinning();
            }
        }

        public void LoadGamePlayPrefab(int index)
        {
            currentActiveLevel = Instantiate(levelPrefabList[index], gameplayCanvas).gameObject;
        }

        public void RestartLevel(Action callback = null)
        {
            Debug.Log("Restart level");
            Destroy(currentActiveLevel);
            currentActiveLevelCount--;
            currentActiveLevel = Instantiate(levelPrefabList[currentActiveLevelCount], gameplayCanvas).gameObject;

            StartCoroutine(DelayedCallback(1, callback));
        }

        IEnumerator DelayedCallback(int delay, Action callback)
        {
            yield return new WaitForSeconds(delay);
            callback?.Invoke();
        }
    }
}
