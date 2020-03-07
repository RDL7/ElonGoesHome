using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweetScript : MonoBehaviour
{

    void Update()
    {
        this.gameObject.transform.position = new Vector2(transform.position.x, transform.position.y - 1 * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}