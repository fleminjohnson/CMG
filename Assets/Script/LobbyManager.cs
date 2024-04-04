using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CMG
{

    public class LobbyManager : MonoBehaviour
    {
        public void PlayButton()
        {
            // Get the currently active scene
            Scene currentScene = SceneManager.GetActiveScene();

            int index = currentScene.buildIndex;
            index++;

            // Reload the current scene using its build index
            SceneManager.LoadScene(index);
        }
    }
}
