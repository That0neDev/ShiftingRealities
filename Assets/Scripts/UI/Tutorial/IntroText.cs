using System;
using System.Collections;

using UnityEngine;
using UnityEngine.UI;

using Scripts.Statics;
using System.Collections.Generic;



namespace Scripts.UI{
    public class IntroText : MonoBehaviour
    {
        private Text textLabel;
        private Action<int> TextCompleted;
        private readonly List<string> Dialogues = new(){
            new("Welcome to Shifting Realities! Press enter to continue or ESC to skip."),
            new("In this game, you'll solve platforming puzzles by shifting realities."),
            new("Your goal is to reach the end of each level."),
            new("You control a cube. Both realities has their own way of moving."),
            new("When in light realm, use arrow keys to move and space to jump."),
            new("When in night realm, use arrow keys to float with your spirit."),
            new("You can shift the reality by pressing W. There are 5 levels. Good luck!")
        };

        private IEnumerator ShowText(int index){
            int charCount = Dialogues[index].Length;
            string textValue = String.Empty;
            int framesPerChar = 2;

            var timer = new WaitForSeconds(Time.fixedDeltaTime * framesPerChar);
            while (textValue.Length != charCount)
            {
                textValue += Dialogues[index][textValue.Length];
                textLabel.text = textValue;
                yield return timer;
            }

            TextCompleted.Invoke(index);
        }
        private void OnTextComplete(int index){
            StartCoroutine(PollInput(index));
        }
        private IEnumerator PollInput(int index){

            while (true){

                if(Input.GetKeyDown(KeyCode.Return))
                    break;
                
                yield return Time.deltaTime;
            }

            if (Dialogues.Count == index + 1)
                EndDialogue();
            else
                StartCoroutine(ShowText(index + 1));
        }
        private void EndDialogue(){
            Events.TutorialFinished.Invoke();
            Destroy(gameObject);
        }


        private IEnumerator Start(){
            textLabel = GetComponent<Text>();
            TextCompleted += OnTextComplete;
            StartCoroutine(ShowText(0));

            while (true){
                if(Input.GetKeyDown(KeyCode.Escape))
                    EndDialogue();
                
                yield return Time.deltaTime;
            }
        }
    }
}
