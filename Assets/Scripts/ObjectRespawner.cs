using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectRespawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float respawnTime = 1.0f;
    private UnityEngine.Random random = new UnityEngine.Random();
    // Use this for initialization
    void Start()
    {
        StartCoroutine(asteroidWave());
    }
    private void spawnEnemy()
    {
        if (Convert.ToBoolean(UnityEngine.Random.Range(0, 2)))
        {
            Vector3 pos = new Vector3(UnityEngine.Random.Range(-8, 8), this.transform.position.y, this.transform.position.z);
            GameObject gm = Instantiate(this.asteroidPrefab, pos, Quaternion.identity) as GameObject;
            gm.GetComponent<Rigidbody2D>().mass = UnityEngine.Random.Range(1, 3);
            gm.GetComponent<Rigidbody2D>().gravityScale = gm.GetComponent<Rigidbody2D>().mass;
            gm.gameObject.transform.localScale = new Vector3(UnityEngine.Random.Range(1, 4), UnityEngine.Random.Range(1, 4), 0);
        }
    }
    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(0, 2));
            spawnEnemy();
        }
    }

}