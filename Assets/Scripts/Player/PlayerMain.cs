using System.Collections;
using System.Collections.Generic;
using Scripts.Statics;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerMain : MonoBehaviour
    {
        [SerializeField] PlayerBehaviour LightPlayer;
        [SerializeField] PlayerBehaviour NightPlayer;
        public bool stateLocked = false;

        
        private void OnModeChange(){
            if (Data.State == GameState.Dark)
                NightPlayer.transform.position = LightPlayer.transform.position;
        }
        
        private void Awake(){
            Events.StateChanged += OnModeChange;
        }
    }
}

