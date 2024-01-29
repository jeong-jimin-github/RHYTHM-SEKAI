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



    // �ӵ� ��ȭ�� ���� ���� ����
    float delayRatio = 25.8f;

    void Start()
    {
        timer = 0.0f;
        start = 1f;
        audioPlayer = GetComponent<LocalAudioPlayer>();
        audioPlayer.AddSound(clip);

        // ��Ʈ�� �ӵ��� �����ͼ� �뷡 ���� �ð��� ���
        float speed = GameObject.Find("besok").GetComponent<besok>().bsesok;
        float offset = GameObject.Find("besok").GetComponent<besok>().offset;
        float delay = delayRatio / speed;

        audioPlayer.PlayDelayed("Music", delay + offset);
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
