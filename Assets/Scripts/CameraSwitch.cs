using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject toZoomInto;

    public int gameStateCounter;
    public GameObject cameraOne;
    private bool cameraOneZoomingIn;
    private bool cameraOneZoomingOut;

    public GameObject[] cameras;
    private GameObject cameraTwo;
    private bool cameraTwoZoomingIn;
    private bool cameraTwoZoomingOut;

    private double minZoom = 0.25f;
    private double maxZoom = 5f;
    private GameObject activeCamera;
    void Start()
    {
        this.gameStateCounter = 0;
        this.cameraTwo = this.cameras[0];

        // Managing the camera zoom in-out
        this.cameraOne.gameObject.SetActive(true);

        foreach (GameObject item in this.cameras)
        {
            item.gameObject.SetActive(false);
        }
        // this.cameraTwo.gameObject.SetActive(false);
        this.activeCamera = this.cameraOne;
        this.cameraOneZoomingIn = false;
        this.cameraOneZoomingOut = false;
        this.cameraTwoZoomingIn = false;
        this.cameraTwoZoomingOut = false;
    }

    void toggleCamera()
    {
        if (this.activeCamera == this.cameraOne)
        {
            this.cameraOneZoomingIn = true;
        }
        else
        {
            this.cameraTwoZoomingIn = true;
        }
    }

    void secondIsAccurateCamera()
    {
        if (this.gameStateCounter > 0 && this.gameStateCounter <= 10)
        {
            this.cameraTwo = this.cameras[0];
        }
        else if (this.gameStateCounter > 10 && this.gameStateCounter <= 20)
        {
            this.cameraTwo = this.cameras[1];
        }
        else if (this.gameStateCounter > 20 && this.gameStateCounter <= 30)
        {
            this.cameraTwo = this.cameras[2];
        }
        else if (this.gameStateCounter > 30 && this.gameStateCounter <= 40)
        {
            this.cameraTwo = this.cameras[3];
        }
        else if (this.gameStateCounter > 40 && this.gameStateCounter <= 50)
        {
            this.cameraTwo = this.cameras[4];
        }
    }

    void Update()
    {
        if (this.activeCamera == this.cameraOne)
        {
            if (this.cameraOneZoomingIn)
            {
                this.updateZoom(this.minZoom, (double)(-0.25));

                this.secondIsAccurateCamera();
                Vector3 targetPosition = toZoomInto.transform.position;
                this.updatePosition(targetPosition);
                if (this.minZoom == this.activeCamera.GetComponent<Camera>().orthographicSize)
                {
                    this.cameraOneZoomingIn = false;
                    this.cameraTwoZoomingOut = true;
                    this.activeCamera = this.cameraTwo;
                    this.cameraTwo.gameObject.SetActive(true);
                    this.activeCamera.GetComponent<Camera>().orthographicSize = (float)this.minZoom;
                }
            }
            else if (this.cameraOneZoomingOut)
            {
                Vector3 targetPosition = new Vector3(0, 0, -10);
                this.updateZoom(this.maxZoom, (double)0.25);
                this.updatePosition(targetPosition);
                if (this.maxZoom == this.activeCamera.GetComponent<Camera>().orthographicSize)
                {
                    this.cameraOneZoomingOut = false;
                    this.cameraOneZoomingIn = false;
                }
            }
        }
        else
        {
            if (this.cameraTwoZoomingIn)
            {
                this.updateZoom(this.minZoom, (double)(-0.25));

                Vector3 targetPosition = toZoomInto.transform.position;
                this.updatePosition(targetPosition);
                if (this.minZoom == this.activeCamera.GetComponent<Camera>().orthographicSize)
                {
                    this.cameraTwoZoomingIn = false;
                    this.cameraOneZoomingOut = true;
                    this.activeCamera = this.cameraOne;
                    this.cameraTwo.gameObject.SetActive(false);
                }
            }
            else if (this.cameraTwoZoomingOut)
            {
                Vector3 targetPosition = new Vector3(0, 0, -10);
                this.updateZoom(this.maxZoom, (double)(+0.25));
                this.updatePosition(targetPosition);
                if (this.maxZoom == this.activeCamera.GetComponent<Camera>().orthographicSize)
                {
                    this.cameraTwoZoomingOut = false;
                    this.cameraTwoZoomingIn = false;
                }
            }
        }
        if (Input.GetKeyDown("e") && !(this.cameraTwoZoomingIn || this.cameraTwoZoomingOut || this.cameraOneZoomingIn || this.cameraOneZoomingOut))
        {
            this.toggleCamera();
        }
    }

    void updateZoom(double target, double step)
    {
        double current = this.activeCamera
            .GetComponent<Camera>()
            .orthographicSize;
        this.activeCamera
            .GetComponent<Camera>()
            .orthographicSize = (float)(current + step);
    }

    void updatePosition(Vector3 target)
    {
        Vector3 newLocation = Vector3.MoveTowards(this.activeCamera.GetComponent<Camera>().transform.position, target, (float)250 * Time.deltaTime);
        this.activeCamera.GetComponent<Camera>().transform.position = new Vector3(newLocation.x, newLocation.y, -10);
    }
}
