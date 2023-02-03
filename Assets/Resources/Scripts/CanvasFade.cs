using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFade : MonoBehaviour
{
    public CanvasGroup canvasGroup;
 
    public bool fadeOut = false;
    public float speed = 2;

    private void Update()
    {
        if (canvasGroup.alpha > 0)
        {
            canvasGroup.gameObject.SetActive(true);
            var speedFade = speed * Time.deltaTime;
            canvasGroup.alpha -= speedFade;

            if (canvasGroup.alpha <= 0)
            {
                fadeOut = false;
                canvasGroup.gameObject.SetActive(false);
            }
        }
    }
    
public void FadeOut()
{
    fadeOut = true;
}
}
