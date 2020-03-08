using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkHealthBarPart : MonoBehaviour
{
    public bool Blink;
    public float BlinkRate = 0.35f; 
    SpriteRenderer HBarSpriteRenderer;

    void Start()
    {
        HBarSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void StartBlinking()
    {
        //print("Strat blinking");
        Blink = true;
        StartCoroutine("BlinkBarPart");
    }

    IEnumerator BlinkBarPart()
    {
        while (Blink)
        {
            //print("blink");
            //print("Scale: " + CurrentProgressBarScale);
            //gameObject.SetActive(false);
            HBarSpriteRenderer.enabled = false;
            yield return new WaitForSeconds(BlinkRate);
            HBarSpriteRenderer.enabled = true;
            yield return new WaitForSeconds(BlinkRate);
            //gameObject.SetActive(true);
        }
    }
}
