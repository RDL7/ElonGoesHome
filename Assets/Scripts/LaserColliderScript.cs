using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserColliderScript : MonoBehaviour
{

    Rigidbody2D body;

    void Awake() {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        body.velocity = new Vector2(0, 10);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Destroyable")
        {
            Destroy(other.gameObject);
            // TODO Create a gif instance here
            Destroy(this.gameObject);
        }
    }
    void OnBecameInvisible() {
        Destroy(this.gameObject);
    }
}
