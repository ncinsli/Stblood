using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

interface IFadeable{
    void FadeIn(Image scr, int percentage, float speed);
    void FadeOut(Image scr, int percentage, float speed);
}

public class Fader : MonoBehaviour, IFadeable{

    IEnumerator CFadeIn(Image screen, int percentage, float speed){
        for (float i = 0; i < percentage/100; i+=0.01f){
            screen.color = new Color(0f, 0f, 0f, i);
            yield return new WaitForSeconds(1/(Mathf.Abs(speed)+1));
        }
    }   


    private IEnumerator CFadeOut(Image screen, int percentage, float speed){
        for (float i = 1; i > percentage/100; i-=0.01f){
            screen.color = new Color(0f, 0f, 0f, i);
            yield return new WaitForSeconds(1/(Mathf.Abs(speed)+1));
        }
    }

    private IEnumerator CFadeInOut(Image screen, int percentage, float speed, int repeats){
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

    public void FadeIn(Image screen, int percentage, float speed) => 
        StartCoroutine(CFadeIn(screen, percentage, speed));
    

    public void FadeOut(Image screen, int percentage, float speed) =>
        StartCoroutine(CFadeOut(screen, percentage, speed));
    

    public void FadeInOut(Image screen, int percentage, float speed, int repeats) =>
        StartCoroutine(CFadeInOut(screen, percentage, speed, repeats));
    

}
