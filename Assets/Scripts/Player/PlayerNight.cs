using System.Collections;
using System.Collections.Generic;
using Scripts.Statics;
using UnityEngine;


namespace Scripts.Player{

    #nullable enable
    public class PlayerNight : PlayerBehaviour{

        private Vector2 direction  = Vector2.zero;
        private bool isInteracting = false;
        const float Force = 5;

        [SerializeField] LayerMask Interactable;

        private GameObject? TryGetInteractable(){
            Collider2D[] Colliders = Physics2D.OverlapCircleAll(transform.position,1,Interactable);
            if (Colliders.Length == 0)
                return null;
            
            return Colliders[0].gameObject;
        }

        private void Interact(GameObject Object){
            //Object.GetComponent<Interactable>().Interact();
        }


        public override void Act()
        {
            if(isInteracting){
                GameObject? obj = TryGetInteractable();
                if (obj != null)
                    Interact(obj);
            }

            Body.AddForce(Force * direction);
        }

        public override void PollInput()
        {
            if(Input.GetKeyDown(KeyCode.W)){
                Events.StateChanged.Invoke(GameState.Light);
                return;
            }

            float xDir = Input.GetAxis("Horizontal");
            float yDir = Input.GetAxis("Vertical");
            isInteracting = Input.GetKeyDown(KeyCode.Space);

            direction = new(xDir,yDir);
        }
    }
}
