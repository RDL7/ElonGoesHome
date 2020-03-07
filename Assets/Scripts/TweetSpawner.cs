using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TweetSpawner : MonoBehaviour
{
    public GameObject TweetPrefab;

    void Start() {
        StartCoroutine(waiter());
    }

    IEnumerator waiter() {
        this.spawn("Use 'WASD' or Arrow keys to move around");
        yield return new WaitForSeconds(3f);
        this.spawn("'Space' to shoot");
        yield return new WaitForSeconds(3f);
        this.spawn("'E' to check out Elon");
    }

    public void spawn(string text) {
        GameObject a = Instantiate(this.TweetPrefab, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform) as GameObject;
        a.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>().text = text.ToString();
    }
}
