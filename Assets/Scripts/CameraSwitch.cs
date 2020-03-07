using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject toZoomInto;
    public GameObject cameraOne;
    private bool cameraOneZooming;
    private bool cameraOneZoomedIn;

    public GameObject cameraTwo;
    private bool cameraTwoZooming;
    private bool cameraTwoZoomedIn;
    private double minZoom = 0.25f;
    private double maxZoom = 5f;
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
            this.cameraOneZoomedIn = false;
            this.cameraOneZooming = true;
            this.cameraTwoZoomedIn = true;
            this.cameraTwoZooming = false;
        }
        else
        {
            this.cameraOne.gameObject.SetActive(true);
            this.cameraTwo.gameObject.SetActive(false);
            this.activeCamera = this.cameraOne;
            this.cameraTwoZoomedIn = false;
            this.cameraTwoZooming = true;
            this.cameraOneZoomedIn = true;
            this.cameraOneZooming = false;
        }
    }

    void Update()
    {
        bool innerZoomedIn;
        bool innerZoomingIn;
        if (this.activeCamera == this.cameraOne) {
            innerZoomedIn = this.cameraOneZoomedIn;
            innerZoomingIn = this.cameraOneZooming;
        } else {
            innerZoomedIn = this.cameraTwoZoomedIn;
            innerZoomingIn = this.cameraTwoZooming;
        }
        double target = innerZoomingIn ? this.minZoom : this.maxZoom;
        Vector3 targetPosition = innerZoomingIn ? toZoomInto.transform.position : new Vector3(0, 0, -10);

        this.updateZoom(target, innerZoomedIn, innerZoomingIn);
        this.updatePosition(targetPosition, innerZoomedIn, innerZoomingIn);

        if (Input.GetKeyDown("e"))
        {
            this.toggleCamera();
        }
    }

    void updateZoom(double target, bool zoomedIn, bool zoomingIn)
    {
        double step = zoomedIn ? -0.25 : 0.25;
        double current = this.activeCamera
            .GetComponent<Camera>()
            .orthographicSize;
        if (zoomingIn)
        {
            current += step;
            this.activeCamera
                .GetComponent<Camera>()
                .orthographicSize = (float)current;
        }
    }

    void updatePosition(Vector3 target, bool zoomedIn, bool zoomingIn)
    {
        if (zoomedIn)
        {
            Vector3 newLocation = Vector3.MoveTowards(this.transform.position, target, (float)1);
            this.transform.position = new Vector3(newLocation.x, newLocation.y, -10);
        }
        else if (zoomingIn)
        {
            this.transform.position = new Vector3(target.x, target.y, -10);
            this.toggleCamera();
        }
    }
}
