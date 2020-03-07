using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweetScript : MonoBehaviour
{

    void Start(){
        Destroy(gameObject, 15);
    }
    void Update()
    {
        this.gameObject.transform.position = new Vector2(transform.position.x, transform.position.y - 1 * Time.deltaTime);
    }

    // void OnBecameInvisible()s
}