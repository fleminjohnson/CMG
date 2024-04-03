using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardMatchingGame
{
    public class GameManager : SingletonBehaviour<GameManager>
    {
        [SerializeField] private CanvasManagement canvasManagement;

        private int turnCount = 0;
        private int matchCount = 0;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

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
