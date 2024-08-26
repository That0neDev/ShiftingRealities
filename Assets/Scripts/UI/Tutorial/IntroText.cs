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
            new("Welcome to Shifting Realities! To continue, press the Enter button."),
            new("In this game, you will try to solve platforming puzzles in a constantly shifting two diffrent realities."),
            new("Your task is to reach to the end of the levels."),
            new("Your character is a cube. Holding arrow keys while pressing space will dash the cube to the direction."),
            new("If your cube touches a spot with same color, you will get hurt and the level will reset."),
            new("To prevent this, you can shift the reality and swap the colors on the map. This will create a transition and you will be safe while this transition happens"),
            new("You can shift the reality by pressing S."),
            new("There are 10 levels. Good luck!")
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
            
            bool waitingForButton = true;
            do
            {
                yield return Time.deltaTime;
                
                if(Input.GetKeyDown(KeyCode.Return))
                    waitingForButton = false;

            } while (waitingForButton);

            if (Dialogues.Count == index + 1)
                EndDialogue();
            else
                ShowText(index + 1);
        }
        private void EndDialogue(){
            //send event tutorial ended
            print("Tutorial ended");
            Destroy(gameObject);
        }


        private void Start(){
            textLabel = GetComponent<Text>();
            TextCompleted += OnTextComplete;
            StartCoroutine(ShowText(0));
        }
    }
}
