using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{

    public bool shake;
    private Vector3 inititalCameraLoc;
    void Start()
    {
        this.shake = false;
        this.inititalCameraLoc = GameObject.Find("Main Camera").transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        float x = inititalCameraLoc.x;
        float y = inititalCameraLoc.y;
        float z = inititalCameraLoc.z;
        if (shake)
        {
            Vector3 _newPosition = new Vector3(UnityEngine.Random.Range(x - 1, x + 1), UnityEngine.Random.Range(y - 1, y + 1), -10);
            GameObject.Find("Main Camera").transform.position = _newPosition;
        }
    }

    public void resetCamera() {
        GameObject.Find("Main Camera").transform.position = this.inititalCameraLoc;
    }
}
