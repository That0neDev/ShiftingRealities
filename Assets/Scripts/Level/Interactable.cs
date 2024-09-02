using Scripts.Statics;
using UnityEngine;

namespace Scripts.Levels.Interactables
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]

    public class Interactable : MonoBehaviour
    {
        private SpriteRenderer Renderer;
        private BoxCollider2D Collider2D;
        [SerializeField] GameState State;

        public virtual void Interact(){
            if (State == Data.State)
                print("Interacted.");
        }

        private void OnTriggerEnter2D(Collider2D Collision){
            Interact();
        }

        private void SetColor(){
            Color newColor = ColorHandler.GetNewColor(State);
            ColorHandler.SetNewColor(Renderer,newColor);
        }

        private void Awake(){
            Renderer = GetComponent<SpriteRenderer>();
            Collider2D = GetComponent<BoxCollider2D>();

            Events.StateChanged += SetColor;
        }

        private void OnDisable(){
            Events.StateChanged -= SetColor;
        }
    }
}

