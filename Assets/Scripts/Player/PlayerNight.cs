using System.Collections;
using System.Collections.Generic;
using Scripts.Statics;
using UnityEngine;


namespace Scripts.Player{

    public class PlayerNight : PlayerBehaviour{

        private Vector2 direction  = Vector2.zero;
        private bool isInteracting = false;
        const float Force = 5;
        const float pullForce = 30f;

        [SerializeField] LayerMask Interactable;
        [SerializeField] Transform lightPlayer;


        private GameObject TryGetInteractable(){
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
                GameObject obj = TryGetInteractable();
                if (obj != null)
                    Interact(obj);
            }

            Vector2 dist = transform.position - lightPlayer.position;
            
            if(direction != Vector2.zero)
                Body.AddForce(Force * direction); 
        }

        public override void PollInput()
        {
            if(Input.GetKeyDown(KeyCode.Q) && playerMain.stateLocked == false){
                playerMain.stateLocked = true;
                Data.State = GameState.Light;
                Invoke(nameof(Unlock), Data.StateChangeTime);
                return;
            }

            float xDir = Input.GetAxis("Horizontal");
            float yDir = Input.GetAxis("Vertical");
            isInteracting = Input.GetKeyDown(KeyCode.Space);

            if(enabled)
                direction = new(xDir,yDir);
            else
                direction = Vector2.zero;
        }

        public override void OnActivationChange()
        {
            if(Data.State == State){
                Renderer.color = Data.PlayerDarkOnColor;
            }else{
                Renderer.color = Data.PlayerDarkOffColor;
            }
        }
    }
}
