using System.Collections;
using System.Collections.Generic;
using Scripts.Statics;
using UnityEngine;

namespace Scripts.UI
{
    public class CameraColor : MonoBehaviour
    {
        public Camera Camera;

        private void ColorEvent(){
            Color newColor = ColorHandler.GetCameraColor();
            ColorHandler.SetCameraColor(this,newColor);
        }

        private void Awake(){
            Events.StateChanged += ColorEvent;
        }

        private void OnDisable(){
            Events.StateChanged -= ColorEvent;
        }
    }
}
