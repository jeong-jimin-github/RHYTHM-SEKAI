using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    public Button ³»ÀÏÀÇ¹ãÇÏ´ÃÃÊ°è¹İ;
    public Button ÇÏÃ÷³×¹ÌÄíÀÇ¼Ò½Ç;
    public Button Unwelcome_School;
    public Sprite ³»ÀÏÀÇ¹ãÇÏ´ÃÃÊ°è¹İ¾ÆÆ®;
    public Sprite ÇÏÃ÷³×¹ÌÄíÀÇ¼Ò½Ç¾ÆÆ®;
    public Sprite Unwelcome_School¾ÆÆ®;
    public Image image;
    public Text title;
    public Text auther;
    public Text bpm;
    public AudioSource audioPlayer;
    AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        ³»ÀÏÀÇ¹ãÇÏ´ÃÃÊ°è¹İ.onClick.AddListener(asu);
        ÇÏÃ÷³×¹ÌÄíÀÇ¼Ò½Ç.onClick.AddListener(shousitu);
        Unwelcome_School.onClick.AddListener(unwelcome);
        if(PlayerPrefs.GetString("Song") == "«¢«¹«Î«è«¾«éôúÌüÚì") asu();
        else if (PlayerPrefs.GetString("Song") == "ôøëå«ß«¯ªÎá¼ã÷") shousitu();
        else if (PlayerPrefs.GetString("Song") == "Unwelcome School") unwelcome();
        else asu();
    }
    void asu()
    {
        SaveSelect("«¢«¹«Î«è«¾«éôúÌüÚì");
        image.sprite = ³»ÀÏÀÇ¹ãÇÏ´ÃÃÊ°è¹İ¾ÆÆ®;
        title.text = "«¢«¹«Î«è«¾«éôúÌüÚì";
        auther.text = "Orangestar";
        bpm.text = "BPM 185";
        AudioPlay();
        
    }
    void shousitu()
    {
        SaveSelect("ôøëå«ß«¯ªÎá¼ã÷");
        image.sprite = ÇÏÃ÷³×¹ÌÄíÀÇ¼Ò½Ç¾ÆÆ®;
        title.text = "ôøëå«ß«¯ªÎá¼ã÷";
        auther.text = "cosMo@øìñËp";
        bpm.text = "BPM 240";
        AudioPlay();
    }
    void unwelcome()
    {
        SaveSelect("Unwelcome School");
        image.sprite = Unwelcome_School¾ÆÆ®;
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
                // ¿©±â¿¡¼­ AudioClipÀ» »ç¿ëÇÏ°Å³ª ÀúÀåÇÒ ¼ö ÀÖ½À´Ï´Ù.
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
