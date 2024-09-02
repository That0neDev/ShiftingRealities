using System.Collections;
using System.Collections.Generic;
using Scripts.Statics;
using UnityEngine;

namespace Scripts.Levels.Interactables
{
    public class EndTrigger : Interactable
    {
        [SerializeField] int LevelID;
        public override void Interact()
        {
            Events.LevelCompleted.Invoke(LevelID);
        }
    }
}
