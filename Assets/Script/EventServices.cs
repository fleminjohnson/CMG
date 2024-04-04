using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CardMatchingGame
{
    public class EventServices : SingletonBehaviour<EventServices>
    {
        public event Action OnWinning;
        public event Action OnLose;

        public void InvokeOnWinning()
        {
            OnWinning?.Invoke();
        }

        public void InvokeOnLose()
        {
            OnLose?.Invoke();
        }
    }
}