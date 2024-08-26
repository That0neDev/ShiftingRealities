using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Statics
{
    public static class Data
    {
        private static GameState gameState = GameState.Idle;
        public static GameState State {get {return gameState;} set{
                gameState = value;
                Events.StateChanged.Invoke(value);
            }
        }
    }
}
