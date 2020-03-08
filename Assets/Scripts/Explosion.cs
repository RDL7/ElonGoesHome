using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.8f);
    }

    //public void ChangeLocation(Collider2D col)
    //{
    //    transform.position = new Vector3(col.gameObject.transform.position.x, col.gameObject.transform.position.y, 0);
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
