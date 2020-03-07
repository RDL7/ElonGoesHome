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
    void Update()
    {
        double target = this.zoomedIn ? this.minZoom : this.maxZoom;
        this.updateZoom(target);
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
}
