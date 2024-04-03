using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardMatchingGame
{
    public class CanvasManagement : MonoBehaviour
    {
        [SerializeField]private GameObject mainMenuCanvas;
        [SerializeField]private GameObject gameCanvas;



        public void PlayGame(int difficulty)
        {
            // Assume difficulty: 0 = Easy, 1 = Medium, 2 = Hard
            // Setup the game based on the chosen difficulty...

            mainMenuCanvas.SetActive(false);
            gameCanvas.SetActive(true);
        }

        public void ExitGame()
        {
            // Assume difficulty: 0 = Easy, 1 = Medium, 2 = Hard
            // Setup the game based on the chosen difficulty...

            mainMenuCanvas.SetActive(true);
            gameCanvas.SetActive(false);
        }

    }
}
