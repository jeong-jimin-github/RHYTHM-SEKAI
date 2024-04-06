using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    public Button �����ǹ��ϴ��ʰ��;
    public Button �����׹����Ǽҽ�;
    public Button Unwelcome_School;
    public Sprite �����ǹ��ϴ��ʰ�ݾ�Ʈ;
    public Sprite �����׹����ǼҽǾ�Ʈ;
    public Sprite Unwelcome_School��Ʈ;
    public Image image;
    public Text title;
    public Text auther;
    public Text bpm;
    public AudioSource audioPlayer;
    AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        �����ǹ��ϴ��ʰ��.onClick.AddListener(asu);
        �����׹����Ǽҽ�.onClick.AddListener(shousitu);
        Unwelcome_School.onClick.AddListener(unwelcome);
        if(PlayerPrefs.GetString("Song") == "�����Ϋ諾��������") asu();
        else if (PlayerPrefs.GetString("Song") == "����߫������") shousitu();
        else if (PlayerPrefs.GetString("Song") == "Unwelcome School") unwelcome();
        else asu();
    }
    void asu()
    {
        SaveSelect("�����Ϋ諾��������");
        image.sprite = �����ǹ��ϴ��ʰ�ݾ�Ʈ;
        title.text = "�����Ϋ諾��������";
        auther.text = "Orangestar";
        bpm.text = "BPM 185";
        AudioPlay();
        
    }
    void shousitu()
    {
        SaveSelect("����߫������");
        image.sprite = �����׹����ǼҽǾ�Ʈ;
        title.text = "����߫������";
        auther.text = "cosMo@����p";
        bpm.text = "BPM 240";
        AudioPlay();
    }
    void unwelcome()
    {
        SaveSelect("Unwelcome School");
        image.sprite = Unwelcome_School��Ʈ;
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
