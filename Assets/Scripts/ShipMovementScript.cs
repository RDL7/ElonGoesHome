using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.CoreModule.Screen;

public class ShipMovementScript : MonoBehaviour
{
    // Copied from https://stuartspixelgames.com/2018/06/24/simple-2d-top-down-movement-unity-c/
    Rigidbody2D body;
    public Camera mainCamera;
    private int health;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    public GameObject spawnerPrefab;
    public float runSpeed = 20.0f;

    private float x;
    private float y;

    private Vector3 prevPos;

    void Start()
    {
        this.resetHealth();
        this.x = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        this.y = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        if (Input.GetKeyDown("space"))
        {
            Instantiate(spawnerPrefab, this.gameObject.transform.position, Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        Vector3 location = mainCamera.WorldToScreenPoint(this.gameObject.transform.position);
        bool leftEdgeReached = location.x - (this.x / 2 ) <= 0 + (this.x / 2);
        bool rightEdgeReached = location.x + (this.x / 2 ) >= Screen.width - (this.x / 2);
        bool bottomEdgeReached = location.y - (this.y / 2) <= 0 + (this.y / 2);
        bool topEdgeReached = location.y + (this.y / 2 ) >= Screen.height - (this.y / 2);
        if (rightEdgeReached) {
            horizontal = 0;
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - (this.x / 2), this.gameObject.transform.position.y, 0);
        }
        if (leftEdgeReached)
        {
            horizontal = 0;
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + (this.x / 2), this.gameObject.transform.position.y, 0);
        }
        if (topEdgeReached ) {
            vertical = 0;
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - (this.y / 2), 0);
        }

        if (bottomEdgeReached)
        {
            vertical = 0;
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + (this.y / 2), 0);
        }
        if (horizontal > 0 && vertical > 0) // Check for diagonal movement
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    public void decreaseHealth(float degradeHealthBy) {
        this.health -= (int)degradeHealthBy;
        print(degradeHealthBy);
        if (this.health < 0 ) {
            // TODO trigger an angry tweet
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Destroyable")
        {
            // TODO Create a gif instance here
            this.decreaseHealth(other.gameObject.transform.localScale.x * other.gameObject.GetComponent<Rigidbody2D>().mass);
            Destroy(other.gameObject);
        }
    }

    public void resetHealth() {
        this.health = 100;
    }

    public int getHealth() {
        return this.health;
    }
}
