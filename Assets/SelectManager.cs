using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    public Button AsunoYozoraShoukaihan;
    public Button HatsuneMikunoShoushitsu;
    public Button Unwelcome_School;
    public Sprite AsunoYozoraShoukaihanArt;
    public Sprite HatsuneMikunoShoushitsuArt;
    public Sprite Unwelcome_SchoolArt;
    public Image image;
    public Text title;
    public Text auther;
    public Text bpm;
    public AudioSource audioPlayer;
    AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
    	AsunoYozoraShoukaihan.onClick.AddListener(asu);
        HatsuneMikunoShoushitsu.onClick.AddListener(shousitu);
        Unwelcome_School.onClick.AddListener(unwelcome);
        if(PlayerPrefs.GetString("Song") == "�����Ϋ諾��������") asu();
        else if (PlayerPrefs.GetString("Song") == "����߫������") shousitu();
        else if (PlayerPrefs.GetString("Song") == "Unwelcome School") unwelcome();
        else asu();
    }
    void asu()
    {
        SaveSelect("�����Ϋ諾��������");
        image.sprite = AsunoYozoraShoukaihanArt;
        title.text = "�����Ϋ諾��������";
        auther.text = "Orangestar";
        bpm.text = "BPM 185";
        AudioPlay();
        
    }
    void shousitu()
    {
        SaveSelect("����߫������");
        image.sprite = HatsuneMikunoShoushitsuArt;
        title.text = "����߫������";
        auther.text = "cosMo@����p";
        bpm.text = "BPM 240";
        AudioPlay();
    }
    void unwelcome()
    {
        SaveSelect("Unwelcome School");
        image.sprite = Unwelcome_SchoolArt;
        title.text = "Unwelcome School";
        auther.text = "Blue Archive OST";
        bpm.text = "BPM 180";
        AudioPlay();
    }   
    void SaveSelect(string name)
    {
        PlayerPrefs.SetString("Song", name);
    
PlayerPrefs.Save();
    }

    void AudioPlay()
    {
        StartCoroutine("TestUnityWebRequest");
    }

    IEnumerator TestUnityWebRequest()
    {
        string path = "file://" + Application.persistentDataPath + "/" + PlayerPrefs.GetString("Song") + ".wav";

        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(path, UnityEngine.AudioType.WAV))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                clip = DownloadHandlerAudioClip.GetContent(www);
                audioPlayer.clip = clip;
                audioPlayer.Play();
                // ���⿡�� AudioClip�� ����ϰų� ������ �� �ֽ��ϴ�.
            }
            else
            {
                Debug.LogError("UnityWebRequest failed: " + www.error);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
