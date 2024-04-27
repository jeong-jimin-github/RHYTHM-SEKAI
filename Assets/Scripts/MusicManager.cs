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
        offset = (float) 30 / PlayerPrefs.GetInt("Speed");
        print(offset);
        StartCoroutine("TestUnityWebRequest");
    }



    IEnumerator TestUnityWebRequest()
    {
        string path = "file://" + Application.persistentDataPath + "/" + PlayerPrefs.GetString("Song") + ".mp3";

        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(path, UnityEngine.AudioType.MPEG))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                clip = DownloadHandlerAudioClip.GetContent(www);
                audioPlayer.clip = clip;
                // 여기에서 AudioClip을 사용하거나 저장할 수 있습니다.
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
                //dealyed start
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