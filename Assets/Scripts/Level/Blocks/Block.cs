using System.Collections;
using System.Collections.Generic;
using Scripts.Statics;
using UnityEngine;

namespace Scripts.Levels.Blocks
{
    public class Block : MonoBehaviour
    {
        [SerializeField] SpriteRenderer Renderer;
        [SerializeField] BoxCollider2D Collider2D;
        [SerializeField] GameState State;

        private void OnNewState(){
            Color newColor = ColorHandler.GetNewColor(State);
            ColorHandler.SetNewColor(Renderer,newColor);
        }

        private void Awake(){
            Events.StateChanged += OnNewState;
        }

        private void OnDisable(){
            Events.StateChanged -= OnNewState;
        }
    }
}

