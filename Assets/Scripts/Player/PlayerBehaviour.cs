using System.Collections;
using System.Collections.Generic;
using Scripts.Statics;
using UnityEngine;

namespace Scripts.Player{

    public abstract class PlayerBehaviour : MonoBehaviour{
        protected Rigidbody2D Body;
        protected SpriteRenderer Renderer;
        public GameState State;

        public abstract void Act();
        public abstract void PollInput();
        public abstract void OnActivationChange();

        private void Update(){

            if(Data.State == State)
                PollInput();
        }

        private void FixedUpdate(){
            if(Data.State == State)
                Act();
        }

        private void Awake(){
            Body = GetComponent<Rigidbody2D>();
            Renderer = GetComponent<SpriteRenderer>();
            Events.StateChanged += OnActivationChange;
        }

        private void OnDisable(){
            Events.StateChanged -= OnActivationChange;
        }
    }
}
