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
                Debug.Log(gameState);
                Events.StateChanged.Invoke();
            }
        }

        public static Color LightOnColor = new(0.85f, 0.85f, 0.85f, 1f);
        public static Color LightOffColor = new(0.1f, 0.1f, 0.1f, 0.6f);
        public static Color DarkOnColor = new(0f, 0f, 0f, 1f);
        public static Color DarkOffColor = new(0.06f, 0.06f, 0.06f, 0.04f);
        public static Color CameraLightColor = new(0.7f, 0.7f, 0.7f);
        public static Color CameraDarkColor = new(0.1f, 0.2f, 0.2f);
        public static Color PlayerLightOnColor = new(1,1,1,1);
        public static Color PlayerLightOffColor = new(1,1,1,0.2f);
        public static Color PlayerDarkOnColor = new(0,0,0,1);
        public static Color PlayerDarkOffColor = new(0,0,0,0);
        public const float StateChangeTime = 1f;
    }
}
