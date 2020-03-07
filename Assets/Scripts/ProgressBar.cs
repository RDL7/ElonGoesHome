using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public GameObject ProgressBarFill;
    public GameObject ProgressCarIcon;
    float MaxProgressBarScale;
    float CurrentProgressBarScale;

    void Start()
    {
        CurrentProgressBarScale = GlobalClass.DistanceTraveled * (MaxProgressBarScale / GlobalClass.DistanceToMars);

        ProgressBarFill.transform.localScale = new Vector2(ProgressBarFill.transform.localScale.x, 0);
        MaxProgressBarScale = 163;
        ProgressCarIcon.transform.localPosition = new Vector2(ProgressCarIcon.transform.localPosition.x, -4.91f);
        StartCoroutine("ProgresBarUpdateCoroutine");
    }

    //void Update()
    //{

    //}

    IEnumerator ProgresBarUpdateCoroutine()
    {
        while(CurrentProgressBarScale <= MaxProgressBarScale)
        {
            //print("Scale: " + CurrentProgressBarScale);
            UpdateProgressBar();
            yield return new WaitForSeconds(.1f);
        }

        //EndGameEvent
        GameEnd();
    }

    void UpdateProgressBar()
    {
        CurrentProgressBarScale = GlobalClass.DistanceTraveled * (MaxProgressBarScale / GlobalClass.DistanceToMars);
        ProgressBarFill.transform.localScale = new Vector2(ProgressBarFill.transform.localScale.x, CurrentProgressBarScale);

        //ProgressCarIcon
        ProgressCarIcon.transform.localPosition = new Vector2(ProgressCarIcon.transform.localPosition.x, CurrentProgressBarScale * (9.786543f / MaxProgressBarScale));
    }

    void GameEnd()
    {
        print("ELON HOME");
    }
}
