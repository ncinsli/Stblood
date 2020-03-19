using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenUtils : MonoBehaviour{

    interface IFadeable{
        void FadeIn(Image scr, int percentage, float speed);
        void FadeOut(Image scr, int percentage, float speed);
    }


    public class Fader : MonoBehaviour, IFadeable{
        
        public void FadeIn(Image screen, int percentage, float speed){          
            IEnumerator FadeIn(){
                for (float i = 0; i < percentage/100; i+=0.01f){
                    screen.color = new Color(0f, 0f, 0f, i);
                    yield return new WaitForSeconds(1/(Mathf.Abs(speed)+1));
                }
            }
            StartCoroutine(FadeIn());
        }   

        public void FadeOut(Image screen, int percentage, float speed){
            IEnumerator FadeOut(){
                for (float i = 1; i > percentage/100; i-=0.01f){
                    screen.color = new Color(0f, 0f, 0f, i);
                    yield return new WaitForSeconds(1/(Mathf.Abs(speed)+1));
                }
            }
            StartCoroutine(FadeOut());
        }

        public void FadeInOut(Image screen, int percentage, float speed, int repeats){
            IEnumerator FadeInOut(){
                for (int k = 0; k < repeats; k++){
                    for (float i = 0; i < percentage/100; i+=0.01f){
                        screen.color = new Color(0f,0f, 0f, i);
                        yield return new WaitForSeconds(1/(Mathf.Abs(speed)+1));
                    }
                    
                    for (float j = 1; j > (100-percentage)/100; j-=0.01f){
                        screen.color = new Color(0f, 0f, 0f, j);
                        yield return new WaitForSeconds(1/(Mathf.Abs(speed)+1));
                    }
                }
            }
            StartCoroutine(FadeInOut());
        }

    }
}


