using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameSpawnerScript : MonoBehaviour
{
    public GameObject teslaCarPrefab;
    public GameObject EndLogoPrefab;
    public GameObject TweetSpawner;
    public GameObject Mars;
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(this.StartGame());
    }

    public IEnumerator StartGame()
    {
        GameObject.Find("AsteroidSpawner").GetComponent<ObjectRespawner>().innerActive = false;
        yield return new WaitForSeconds(5);
        GameObject.Find("AsteroidSpawner").GetComponent<ObjectRespawner>().innerActive = true;
    }

    public IEnumerator EndGame() {
        Destroy(GameObject.Find("AsteroidSpawner"));
        Instantiate(this.teslaCarPrefab, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(5);
        TweetSpawner.GetComponent<TweetSpawner>().spawn("Mars - home, sweet home...");
        GameObject.Find("BAckGround_1").GetComponent<BackGround>().speed = 0;
        GameObject.Find("BAckGround_2").GetComponent<BackGround>().speed = 0;
        yield return new WaitForSeconds(5);
        Instantiate(this.EndLogoPrefab, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(8);
        Instantiate(this.Mars, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3);
        print("Quitting the app");
        Application.Quit();
    }

}
