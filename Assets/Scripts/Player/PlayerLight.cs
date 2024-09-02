using System.Collections;
using System.Collections.Generic;
using Scripts.Statics;
using UnityEngine;

namespace Scripts.Player{

    public class PlayerLight : PlayerBehaviour
    {
        [SerializeField] LayerMask jumpMask;
        private bool isJumping = false;
        private float direction = 0;
        const float Force = 1;
        const float MaxSpeed = 10;
        const float jumpVelocity = 12;
        const float distToGround = 0.25f;

        public override void Act()
        {
            
            if(direction != 0)
                Body.AddForce(new(Force * direction,0),ForceMode2D.Impulse);
            else
                Body.velocity = new(Body.velocity.x * 0.8f,Body.velocity.y);
            
            RaycastHit2D hit1 = Physics2D.Raycast(transform.position + new Vector3(0.45f, 0.5f), Vector2.down, distToGround,jumpMask);
            RaycastHit2D hit2 = Physics2D.Raycast(transform.position + new Vector3(0.45f,-0.5f), Vector2.down, distToGround,jumpMask);

            if (isJumping  && (hit1.collider != null || hit2.collider != null))
                Body.velocity = new(Body.velocity.x,jumpVelocity);
        
            Body.velocity = new(Mathf.Clamp(Body.velocity.x,-MaxSpeed,MaxSpeed),Body.velocity.y);
        }

        public override void PollInput()
        {
            if(Input.GetKeyDown(KeyCode.Q) && playerMain.stateLocked == false){
                playerMain.stateLocked = true;
                Data.State = GameState.Dark;
                Invoke(nameof(Unlock), Data.StateChangeTime);
                return;
            }

            direction = Input.GetAxisRaw("Horizontal");
            isJumping = Input.GetKey(KeyCode.Space);
        }

        private void OnDrawGizmos(){
            Gizmos.DrawLine(transform.position,new(transform.position.x -0.5f,transform.position.y - distToGround - 0.5f));
            Gizmos.DrawLine(transform.position,new(transform.position.x +0.5f,transform.position.y - distToGround - 0.5f));
        }

        public override void OnActivationChange()
        {
            if(Data.State == State){
                Renderer.color = Data.PlayerLightOnColor;
            }else{
                Renderer.color = Data.PlayerLightOffColor;
            }
        }
    }
}
