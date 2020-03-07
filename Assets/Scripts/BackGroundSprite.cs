using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSprite : MonoBehaviour
{
    public GameObject BG_1;
    public GameObject BG_2;

    float SpriteHeight;

    // Start is called before the first frame update
    void Start()
    {
        SpriteHeight = BG_1.GetComponent<SpriteRenderer>().bounds.size.y;
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //void OnBecameInvisible()
    //{
    //    transform.position = new Vector2(transform.position.x, transform.position.y + 40);
    //    //Destroy(gameObject);
    //}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "WorldSpammer")
        {
            if (gameObject == BG_1)
            {
                BG_2.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + SpriteHeight);
            }

            if (gameObject == BG_2)
            {
                BG_1.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + SpriteHeight);
            }
        }
    }

}
