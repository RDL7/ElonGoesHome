using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObjectCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Destroyable")
        {
            Destroy(other.gameObject);
        }
    }
}
