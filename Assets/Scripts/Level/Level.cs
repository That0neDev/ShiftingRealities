using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.Levels.Interactables;
using Scripts.Statics;
using UnityEngine;

namespace Scripts.Levels{
    public class Level : MonoBehaviour
    {
        [SerializeField] Rigidbody2D player;

        private void Update(){
            if (Input.GetKeyDown(KeyCode.Backspace))
                Events.ResetDemanded.Invoke(FindFirstObjectByType<EndTrigger>().LevelID);
        }

        private void Start(){
            Data.State = GameState.Light;
        }
    }
}

