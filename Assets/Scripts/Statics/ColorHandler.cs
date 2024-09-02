using System.Collections;
using Scripts.UI;
using UnityEngine;

namespace Scripts.Statics{
    public static class ColorHandler{         
        class CoroutineHandler : MonoBehaviour{ }

        public static Color GetPlayerColor(GameState State){
            if(State == Data.State){
                if(State == GameState.Light)
                    return Data.PlayerLightOnColor;
                else
                    return Data.PlayerDarkOnColor;
            }
            else{
                if(State == GameState.Light)
                    return Data.PlayerLightOffColor;
                else
                    return Data.PlayerDarkOffColor;
            }
        }    
        public static Color GetCameraColor(){
            if(Data.State == GameState.Light)
                return Data.CameraLightColor;
            
            return Data.CameraDarkColor;
        }
        public static void SetCameraColor(CameraColor cameraColor,Color newColor){

            IEnumerator ISetColor(){
                Color oldColor = cameraColor.Camera.backgroundColor;
                float timeToLerp = Data.StateChangeTime;
                float t = 0;

                while (t < timeToLerp){
                    cameraColor.Camera.backgroundColor = Color.Lerp(oldColor,newColor,t / timeToLerp);
                    t += Time.deltaTime;
                    yield return Time.deltaTime;
                }
            }

            cameraColor.StartCoroutine(ISetColor());
        }
        public static Color GetNewColor(GameState State){
            if(State == Data.State){
                if(State == GameState.Light)
                    return Data.LightOnColor;
                else
                    return Data.DarkOnColor;
            }
            else{
                if(State == GameState.Light)
                    return Data.LightOffColor;
                else
                    return Data.DarkOffColor;
            }
        }
        public static void SetNewColor(SpriteRenderer spriteRenderer,Color newColor){
            IEnumerator ISetColor(CoroutineHandler h){
                
                Color oldColor = spriteRenderer.color;
                float timeToLerp = Data.StateChangeTime;
                float t = 0;

                while (t < timeToLerp){
                    spriteRenderer.color = Color.Lerp(oldColor,newColor,t / timeToLerp);
                    t += Time.deltaTime;
                    yield return Time.deltaTime;
                }

                GameObject.Destroy(h);
            }
            
            CoroutineHandler h = spriteRenderer.gameObject.AddComponent<CoroutineHandler>();
            h.StartCoroutine(ISetColor(h));
        }
    }
}