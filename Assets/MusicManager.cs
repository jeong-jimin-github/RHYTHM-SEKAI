using AudUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MusicManager : MonoBehaviour
{
    public SoundData clip;
    public LocalAudioPlayer audioPlayer;
    public bool isstart = false;
    float timer;
    int a = 0;
    float start;

    void Start()
    {
        timer = 0.0f;
        start = 1f;
        audioPlayer = GetComponent<LocalAudioPlayer>();
        audioPlayer.AddSound(clip);
        audioPlayer.PlayDelayed("Music", 1.6f);
    }

    void Update()
    {

        if (a == 0)
        {
            timer += Time.deltaTime;

            if (timer > start)
            {
                isstart = true;
                a++;
            }
        }
    }
}
