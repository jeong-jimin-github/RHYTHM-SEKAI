using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class MusicManager : MonoBehaviour
{
    int i = 0;
    public GameObject timer;
    public AudioClip clip;
    public AudioSource audioPlayer;
    float offset;
    void Start()
    {
        offset = (float)30 / PlayerPrefs.GetInt("Speed");
        print(offset);
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
            }
            else
            {
                Debug.LogError("UnityWebRequest failed: " + www.error);
            }
        }
    }


    private void Update()
    {

        if (timer.GetComponent<timer>().start == true)
        {
            if (i == 0)
            {
                audioPlayer.PlayDelayed(offset);
                i++;
            }
        }
        if(audioPlayer.time >= audioPlayer.clip.length - 1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
        }
    }
}