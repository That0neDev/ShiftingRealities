using System.Collections;
using System.Collections.Generic;
using Scripts.Statics;
using UnityEngine;

namespace Scripts.Levels.Interactables
{
    public class EndTrigger : Interactable
    {
        public int LevelID;
        public override void Interact()
        {
            Events.LevelCompleted.Invoke(LevelID);
        }
        
        private void OnTriggerEnter2D(Collider2D Collision){
            Interact();
        }
    }
}
