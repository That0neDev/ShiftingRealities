using System;
using System.Collections.Generic;
using Scripts.Statics;
using UnityEngine;

namespace Scripts
{
    public class Game : MonoBehaviour{
        [SerializeField] List<Transform> Levels;

        private int currentLevel = 0;

        private Transform levelObject;

        private void LoadLevel(int index){
            currentLevel = index;

            if (levelObject.childCount > 0)
                Destroy(levelObject.GetChild(0).gameObject);

            Transform Instance = Instantiate(Levels[index]).transform;
            Instance.parent = levelObject;
        }

        private void Awake(){
            levelObject = transform.GetChild(0);
            Events.TutorialFinished += () => {LoadLevel(0);};
        }
    }
}

