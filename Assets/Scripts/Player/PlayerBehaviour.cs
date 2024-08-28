using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player{

    public abstract class PlayerBehaviour : MonoBehaviour{
        public Rigidbody2D Body;

        public abstract void Act();
        public abstract void PollInput();

        private void Update(){
            PollInput();
        }

        private void FixedUpdate(){
            Act();
        }
    }
}
