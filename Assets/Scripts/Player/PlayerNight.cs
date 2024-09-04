using System.Collections;
using System.Collections.Generic;
using Scripts.Levels.Interactables;
using Scripts.Statics;
using UnityEngine;


namespace Scripts.Player{

    public class PlayerNight : PlayerBehaviour{

        private Vector2 direction  = Vector2.zero;
        const float Force = 5;
        const float maxDistance = 8;
        [SerializeField] Transform lightPlayer;

        public override void Act()
        {
            Vector2 dist = transform.position - lightPlayer.position;
            
            if(dist.magnitude < maxDistance)
                Body.velocity = Force * direction;
            else {
                Body.position = lightPlayer.position;
                Body.velocity = Vector2.zero;
            }
        }

        public override void PollInput()
        {
            if(Input.GetKeyDown(KeyCode.Q)){
                Data.State = GameState.Light;
                return;
            }

            float xDir = Input.GetAxis("Horizontal");
            float yDir = Input.GetAxis("Vertical");

            if(enabled)
                direction = new(xDir,yDir);
            else
                direction = Vector2.zero;
        }

        public override void OnActivationChange()
        {
            if(Data.State == State){
                Renderer.color = Data.PlayerDarkOnColor;
                transform.position = lightPlayer.transform.position;
            }else{
                Renderer.color = Data.PlayerDarkOffColor;
            }
        }
    }
}
