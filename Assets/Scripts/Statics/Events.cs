using System;
using UnityEngine;

namespace Scripts.Statics
{
    public static class Events{
        public static Action StateChanged;
        public static Action TutorialFinished;
        public static Action<int> ResetDemanded;
        public static Action<int> LevelCompleted;
    }
}