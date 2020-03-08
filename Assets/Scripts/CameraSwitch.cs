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

    public GameObject tweetSpawnerPrefab;

    private bool tweetOne = false;
    private bool tweetTwo = false;
    private bool tweetThree = false;
    private bool tweetFour = false;
    private bool tweetFive = false;
    private bool tweetSix = false;
    private bool tweetSeven = false;
    private bool tweetEight = false;
    private bool tweetNine = false;
    private bool tweetTen = false;


    void Start()
    {
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
            GlobalClass.Pauze = true;
        }
        else
        {
            this.cameraTwoZoomingIn = true;
            GlobalClass.Pauze = false;
        }
    }

    void secondIsAccurateCamera()
    {
        float distRange = GlobalClass.DistanceToMars / 10;
        if (GlobalClass.DistanceTraveled > 0 && GlobalClass.DistanceTraveled <= 2 * distRange)
        {
            this.cameraTwo = this.cameras[0];
        }
        else if (GlobalClass.DistanceTraveled > 2 * distRange && GlobalClass.DistanceTraveled <= 4 * distRange)
        {
            this.cameraTwo = this.cameras[1];
        }
        else if (GlobalClass.DistanceTraveled > 4 * distRange && GlobalClass.DistanceTraveled <= 6 * distRange)
        {
            this.cameraTwo = this.cameras[2];
        }
        else if (GlobalClass.DistanceTraveled > 6 * distRange && GlobalClass.DistanceTraveled <= 8 * distRange)
        {
            this.cameraTwo = this.cameras[3];
        }
        else if (GlobalClass.DistanceTraveled > 8 * distRange && GlobalClass.DistanceTraveled <= 10 * distRange)
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

        float distRange = GlobalClass.DistanceToMars / 10;
        if (distRange * 1 == (int)(GlobalClass.DistanceTraveled))
        {
            if (!this.tweetOne)
            {
                this.tweetSpawnerPrefab.GetComponent<TweetSpawner>().spawn("The coronavirus panic is dumb");
                this.tweetOne = true;
            }
        }
        else if (distRange * 2 == (int)(GlobalClass.DistanceTraveled))
        {
            if (!this.tweetTwo)
            {
                this.tweetSpawnerPrefab.GetComponent<TweetSpawner>().spawn("I put the art in fart");
                this.tweetTwo = true;
            }
        }
        else if (distRange * 3 == (int)(GlobalClass.DistanceTraveled))
        {
            if (!this.tweetThree)
            {
                this.tweetSpawnerPrefab.GetComponent<TweetSpawner>().spawn("Mad respect for the makers of things");
                this.tweetThree = true;
            }
        }
        else if (distRange * 4 == (int)(GlobalClass.DistanceTraveled))
        {
            if (!this.tweetFour)
            {
                this.tweetSpawnerPrefab.GetComponent<TweetSpawner>().spawn("Bernie’s tax rate is 0.2 % too high!");
                this.tweetFour = true;
            }
        }
        else if (distRange * 5 == (int)(GlobalClass.DistanceTraveled))
        {
            if (!this.tweetFive)
            {
                this.tweetFive = true;
                this.tweetSpawnerPrefab.GetComponent<TweetSpawner>().spawn("Where’s Flextape when you need it!?");
            }
        }
        else if (distRange * 6 == (int)(GlobalClass.DistanceTraveled))
        {
            if (!this.tweetSix)
            {
                this.tweetSix = true;
                this.tweetSpawnerPrefab.GetComponent<TweetSpawner>().spawn("Meteor!!");
            }
        }
        else if (distRange * 7 == (int)(GlobalClass.DistanceTraveled))
        {
            if (!this.tweetSeven)
            {
                this.tweetSeven = true;
                this.tweetSpawnerPrefab.GetComponent<TweetSpawner>().spawn("5 mins from liftoff");
            }
        }
        else if (distRange * 8 == (int)(GlobalClass.DistanceTraveled))
        {
            if (!this.tweetEight)
            {
                this.tweetEight = true;
                this.tweetSpawnerPrefab.GetComponent<TweetSpawner>().spawn("Only the heart senses beauty");
            }
        }
        else if (distRange * 9 == (int)(GlobalClass.DistanceTraveled))
        {
            if (!this.tweetNine)
            {
                this.tweetNine = true;
                this.tweetSpawnerPrefab.GetComponent<TweetSpawner>().spawn("Buttcrackers for days");
            }
        }
        else if (distRange * 9.5 == (int)(GlobalClass.DistanceTraveled))
        {
            if (!this.tweetTen)
            {
                this.tweetTen = true;
                this.tweetSpawnerPrefab.GetComponent<TweetSpawner>().spawn("If you got this far then make us win the hackathon!");
            }
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
