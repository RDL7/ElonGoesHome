using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TweetSpawner : MonoBehaviour
{
    public GameObject TweetPrefab;
    private float thelastSpawnedTweetTime;
    private int toRightCount;
    void Start() {
        this.thelastSpawnedTweetTime = Time.time;
        this.toRightCount = 0;
        StartCoroutine(waiter());
    }

    IEnumerator waiter() {
        yield return new WaitForSeconds(3f);
        this.spawn("Use 'WASD' or Arrow keys to move around");
        yield return new WaitForSeconds(3f);
        this.spawn("'Space' to shoot");
        yield return new WaitForSeconds(3f);
        this.spawn("'E' to check out Elon");
    }

    public void spawn(string text) {
        float tmp = Time.time;
        GameObject a;
        if (tmp - this.thelastSpawnedTweetTime  >= 2.5f) {
            a = Instantiate(this.TweetPrefab, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform) as GameObject;
            this.toRightCount = 0;
        } else {
            this.toRightCount += 1;
            a = Instantiate(this.TweetPrefab, this.gameObject.transform.position + new Vector3(toRightCount * 9, 0, 0), Quaternion.identity, this.gameObject.transform) as GameObject;
        }
        a.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>().text = text.ToString();
        this.thelastSpawnedTweetTime = Time.time;
    }
}
