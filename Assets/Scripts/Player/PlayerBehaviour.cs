using System.Collections;
using System.Collections.Generic;
using Scripts.Statics;
using UnityEngine;

namespace Scripts.Player{

    public abstract class PlayerBehaviour : MonoBehaviour{
        public Rigidbody2D Body;
        public SpriteRenderer Renderer;
        public GameState State;
        public PlayerMain playerMain;


        public abstract void Act();
        public abstract void PollInput();
        public abstract void OnActivationChange();

        public void Unlock(){
            playerMain.stateLocked = false;
        }

        private void Update(){

            if(Data.State == State)
                PollInput();
        }

        private void FixedUpdate(){
            if(Data.State == State)
                Act();
        }

        private void Awake(){
            Events.StateChanged += OnActivationChange;
        }
    }
}
