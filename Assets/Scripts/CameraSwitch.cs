using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject toZoomInto;
    private double minZoom = 0.25f;
    private double maxZoom = 5f;
    private bool zoomedIn = false;
    private bool currentlyZoomingIn = false;
    private float inititalZ;
    void Start () {
        this.inititalZ = this.transform.position.z;
    }

    void Update()
    {
        double target = this.zoomedIn ? this.minZoom : this.maxZoom;
        Vector3 targetPosition = this.zoomedIn ? toZoomInto.transform.position : new Vector3(0, 0, this.inititalZ);

        this.updateZoom(target);
        this.updatePosition(targetPosition);
        if (this.gameObject.GetComponent<Camera>().orthographicSize == target) {
            this.currentlyZoomingIn = false;
        }

        if (Input.GetKeyDown("e"))
        {
            this.currentlyZoomingIn = true;
            this.gameObject
                .GetComponent<Camera>()
                .orthographicSize = (float)(this.zoomedIn ? this.minZoom : this.maxZoom);
            this.zoomedIn = !this.zoomedIn;
        }
    }

    void updateZoom(double target) {
        double step = this.zoomedIn ? -0.25 : 0.25;
        double current = this.gameObject
            .GetComponent<Camera>()
            .orthographicSize;
        if (this.currentlyZoomingIn && current != target)
        {
            current += step;
            this.gameObject
                .GetComponent<Camera>()
                .orthographicSize = (float)current;
        }
    }

    void updatePosition(Vector3 target) {
        if (this.currentlyZoomingIn) {
            Vector3 newLocation = Vector3.MoveTowards(this.transform.position, target, (float)1);
            this.transform.position = new Vector3(newLocation.x, newLocation.y, -10);
        } else if (this.zoomedIn) {
            this.transform.position = new Vector3(target.x, target.y, -10);
        }
    }
}
