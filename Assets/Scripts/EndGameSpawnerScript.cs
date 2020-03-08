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

    public IEnumerator EndGame() {
        Destroy(GameObject.Find("AsteroidSpawner"));
        Instantiate(this.teslaCarPrefab, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(5);
        TweetSpawner.GetComponent<TweetSpawner>().spawn("Mars - home, sweet home...");
        yield return new WaitForSeconds(5);
        Instantiate(this.EndLogoPrefab, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(5);
        Instantiate(this.Mars, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(5);
        print("Quitting the app");
        Application.Quit();
    }

}
