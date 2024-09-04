using System;
using System.Collections.Generic;
using Scripts.Statics;
using UnityEngine;

namespace Scripts
{
    public class Game : MonoBehaviour{
        [SerializeField] List<Transform> Levels;
        [SerializeField] GameObject EndScene;

        public void Wait()  { Data.isStateChanging = false; }
        private Transform levelObject;

        private void LoadLevel(int index){
            
            if (levelObject.childCount > 0)
                Destroy(levelObject.GetChild(0).gameObject);
                    
            if(index == Levels.Count){
                EndScene.SetActive(true);
                return;
            }
                
            Transform Instance;
            Instance = Instantiate(Levels[index]).transform;
            Instance.parent = levelObject;
        }

        private void Awake(){
            Data.Game = this;
            levelObject = transform.GetChild(0);
            Events.TutorialFinished += () => {LoadLevel(0);};
            Events.LevelCompleted += (level) => {LoadLevel(level + 1);};
        }
    }
}

