using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ScreenUtils {
    // Start is called before the first frame update
    
    interface IFadeable{
        void FadeIn(Image scr, int percentage, float speed);
        void FadeOut(Image screen);
    }

    public class Fader : MonoBehaviour, IFadeable{

        public void FadeIn(Image scr, int percentage, float speed){          
            IEnumerator FadeIn(Image screen, int percent){
                for (float i = 0; i < percentage/100; i+=0.01f){
                    screen.color = new Color(0f, 0f, 0f, i);
                    yield return new WaitForSeconds(1/(Mathf.Abs(speed)+1));
                }
            }
            StartCoroutine(FadeIn(scr, percentage));
        }   

        public void FadeOut(Image screen){}
    }
}


