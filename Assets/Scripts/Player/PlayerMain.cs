using System.Collections;
using System.Collections.Generic;
using Scripts.Statics;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerMain : MonoBehaviour
    {
        [SerializeField] GameObject LightPlayer;
        [SerializeField] GameObject NightPlayer;

        private void LightInit(){
            NightPlayer.SetActive(false);
            LightPlayer.SetActive(true);
        }

        private void NightInit(){
            LightPlayer.SetActive(false);
            
            NightPlayer.transform.position = LightPlayer.transform.position;
            NightPlayer.SetActive(true);
        }

        private void OnModeChange(GameState newState){

            switch (newState)
            {
                case GameState.Light:
                    LightInit();
                    break;
                case GameState.Dark:
                    NightInit();
                    break;
                default:
                    //Handle game end event here
                    break;
            }
        }
        
        private void Start(){
            Events.StateChanged += OnModeChange;
        }
    }
}

