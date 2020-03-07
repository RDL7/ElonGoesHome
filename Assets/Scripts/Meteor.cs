using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    float PreviousGravity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalClass.Pauze)
        {
            PreviousGravity = gameObject.GetComponent<Rigidbody2D>().gravityScale;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        if (!GlobalClass.Pauze)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = PreviousGravity;
        }
    }
}
