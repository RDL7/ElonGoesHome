using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject toZoomInto;
    public GameObject cameraOne;
    public GameObject cameraTwo;
    private double minZoom = 0.25f;
    private double maxZoom = 5f;
    private bool zoomedIn = false;
    private bool currentlyZoomingIn = false;
    private GameObject activeCamera;
    void Start()
    {
        this.cameraOne.gameObject.SetActive(true);
        this.cameraTwo.gameObject.SetActive(false);
        this.activeCamera = this.cameraOne;
    }

    void toggleCamera()
    {
        if (this.cameraOne.activeSelf)
        {
            this.cameraOne.gameObject.SetActive(false);
            this.cameraTwo.gameObject.SetActive(true);
            this.activeCamera = this.cameraTwo;
        }
        else
        {
            this.cameraOne.gameObject.SetActive(true);
            this.cameraTwo.gameObject.SetActive(false);
            this.activeCamera = this.cameraOne;
        }
    }

    void Update()
    {
        double target = this.zoomedIn ? this.minZoom : this.maxZoom;
        Vector3 targetPosition = this.zoomedIn ? toZoomInto.transform.position : new Vector3(0, 0, -10);

        this.updateZoom(target);
        this.updatePosition(targetPosition);
        if (this.activeCamera.GetComponent<Camera>().orthographicSize == target)
        {
            this.currentlyZoomingIn = false;
        }

        if (Input.GetKeyDown("e"))
        {
            this.currentlyZoomingIn = true;
            this.activeCamera
                .GetComponent<Camera>()
                .orthographicSize = (float)(this.zoomedIn ? this.minZoom : this.maxZoom);
            this.zoomedIn = !this.zoomedIn;
        }
    }

    void updateZoom(double target)
    {
        double step = this.zoomedIn ? -0.25 : 0.25;
        double current = this.activeCamera
            .GetComponent<Camera>()
            .orthographicSize;
        if (this.currentlyZoomingIn)
        {
            current += step;
            this.activeCamera
                .GetComponent<Camera>()
                .orthographicSize = (float)current;
        }
    }

    void updatePosition(Vector3 target)
    {
        if (this.currentlyZoomingIn)
        {
            Vector3 newLocation = Vector3.MoveTowards(this.transform.position, target, (float)1);
            this.transform.position = new Vector3(newLocation.x, newLocation.y, -10);
        }
        else if (this.zoomedIn)
        {
            this.transform.position = new Vector3(target.x, target.y, -10);
            this.toggleCamera();
            // this.zoomedIn = false;
        }
    }
}
