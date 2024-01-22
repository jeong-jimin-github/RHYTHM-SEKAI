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



    // 속도 변화에 따른 조절 비율
    float delayRatio = 25.3f;

    void Start()
    {
        timer = 0.0f;
        start = 1f;
        audioPlayer = GetComponent<LocalAudioPlayer>();
        audioPlayer.AddSound(clip);

        // 노트의 속도를 가져와서 노래 시작 시간을 계산
        float speed = GameObject.Find("besok").GetComponent<besok>().bsesok;
        float delay = delayRatio / speed;

        audioPlayer.PlayDelayed("Music", delay);
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
