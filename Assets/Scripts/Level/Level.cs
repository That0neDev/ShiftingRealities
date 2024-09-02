using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.Statics;
using UnityEngine;

namespace Scripts.Levels{
    public class Level : MonoBehaviour
    {
        private Vector2 startPos;
        private const float MaxSpeed = 5;
        private bool inputAllowed = false;
        private bool InputAllowed {
            get {return inputAllowed;} 
        
            set {
                inputAllowed = value;
                if (value == true)
                    StartCoroutine(PollInputs());
            }
        }
        [SerializeField] Rigidbody2D player;

        private Action LevelLost;
        private Action LevelWon;


        private IEnumerator PollInputs(){
            while (InputAllowed){
                
                if (Input.GetKeyDown(KeyCode.Space))
                    Events.GameInput.Invoke();
                
                yield return Time.deltaTime;
            }
        }

        private IEnumerator IeLose(){
            InputAllowed = false;
            Data.State = GameState.Light;

            while (player.position != Vector2.zero){
                Vector2.MoveTowards(player.position,Vector2.zero,MaxSpeed);
                yield return Time.deltaTime;
            }

            InputAllowed = true;
        }

        private void OnLose(){
            StartCoroutine(IeLose());
        }

        private void OnWin(){

        }

        private void OnDisable(){
            LevelLost -= OnLose;
            LevelWon  -= OnWin;
        }

        private void Awake(){
            LevelLost += OnLose;
            LevelWon  += OnWin;
        }

        private void Start(){
            startPos = player.position;
            Data.State = GameState.Light;
        }
    }
}

