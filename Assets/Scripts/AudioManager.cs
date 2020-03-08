using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip tweet;
    public AudioClip laser;
    public AudioClip shipExploding;
    public AudioClip ambient;
    public AudioClip music;
    public AudioSource tweetSource;
    public AudioSource laserSource;
    public AudioSource shipExplodingSource;
    public AudioSource ambientSource;
    public AudioSource musicSource;

    private bool mainMusicTriggered;

    void Start() {
        this.mainMusicTriggered = false;
        this.play("ambient");
    }
    public void play(string name){
        AudioSource audio;
        print(name);
        switch (name)
        {
            case("tweet"):
                audio = this.tweetSource;
                audio.clip = this.tweet;
                break;
            case ("laser"):
                audio = this.laserSource;
                audio.clip = this.laser;
                break;
            case ("shipExploding"):
                audio = this.shipExplodingSource;
                audio.clip = this.shipExploding;
                break;
            case ("ambient"):
                audio = this.ambientSource;
                audio.clip = this.ambient;
                break;
            case ("music"):
                if (!this.mainMusicTriggered) {
                    audio = this.musicSource;
                    audio.clip = this.music;
                    this.mainMusicTriggered = true;
                } else {
                    audio = this.laserSource;
                }
                break;
            default:
                audio = this.tweetSource;
                break;
        }
        audio.Play(0);
    }
}
