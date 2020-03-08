using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserColliderScript : MonoBehaviour
{
    GameObject Explosion;

    public GameObject AsteroidDestroyAnimation;
    Rigidbody2D body;
    GameObject ExlopsionNew;


    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        Explosion = GameObject.Find("GameManager").GetComponent<Manager>().Explosion;
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(0, 10);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Destroyable")
        {
 			CreateExplosion(other);
            Destroy(other.gameObject);

            GameObject.Find("GameManager").GetComponent<AudioManager>().play("shipExploding");
            // TODO Create a gif instance here
            Destroy(this.gameObject);
        }
    }

    void CreateExplosion(Collider2D other)
    {
        ExlopsionNew = Instantiate(Explosion);
        //ExlopsionNew.GetComponent<Explosion>().ChangeLocation(other);
        ExlopsionNew.transform.localPosition = other.gameObject.transform.position;
        //print("Explosion.transform.position: " + Explosion.transform.position);
        //print("other.gameObject.transform.position: " + other.gameObject.transform.position);
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

}
