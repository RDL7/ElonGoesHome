﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserColliderScript : MonoBehaviour
{

    Rigidbody2D body;

    void Start()
    {
        print("Laser Start");
    }

    void Awake() {
        print("Laser Awake");
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
        }
    }
    void OnBecameInvisible() {
        Destroy(this.gameObject);
    }
}
