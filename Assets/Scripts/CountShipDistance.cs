using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountShipDistance : MonoBehaviour
{
    public GameObject MovingBackGroundForDistanceCounting;
    public float StartPositionOfBG;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("UpdateDistance");
    }

    // Update is called once per frame
    void Update()
    {
        GlobalClass.DistanceTraveled = Mathf.Abs(MovingBackGroundForDistanceCounting.transform.position.y) + StartPositionOfBG;
    }

    //void UpdateDistance()
    //{
    //    GlobalClass.DistanceTraveled = Mathf.Abs(MovingBackGroundForDistanceCounting.transform.position.y) - StartPositionOfBG;
    //    print(GlobalClass.DistanceTraveled);
    //}
}
