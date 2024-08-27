using System;
using UnityEngine;

namespace Scripts.Statics
{
    public static class Events{
        public static Action<GameState> StateChanged;
        public static Action TutorialFinished;
        public static Action LevelInitialized;
        public static Action<int> LevelCompleted;
        public static Action GameInput;
    }
}