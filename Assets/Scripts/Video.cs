using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public VideoPlayer vid;
    int i = 0;
    public GameObject timer;
    public float offset;
    void Start()
    {

        offset = (float)30 / PlayerPrefs.GetInt("Speed");
        if (PlayerPrefs.GetInt("BGA") == 1)
        {
            StartCoroutine(TestVideoPlayer());
        }
    }

    IEnumerator TestVideoPlayer()
    {
        string path = "file://" + Application.persistentDataPath + "/" + PlayerPrefs.GetString("Song") + ".mp4";

        using (UnityWebRequest www = UnityWebRequest.Get(path))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                byte[] videoBytes = www.downloadHandler.data;

                string tempFilePath = Application.persistentDataPath + "/tempVideo.mp4";
                System.IO.File.WriteAllBytes(tempFilePath, videoBytes);

                vid.url = "file://" + tempFilePath;
                vid.Prepare();

                while (!vid.isPrepared)
                {
                    yield return null;
                }

            }
            else
            {
                Debug.LogError("UnityWebRequest failed: " + www.error);
            }
        }
    }

    IEnumerator PlayVideoAfterOffset()
    {
        yield return new WaitForSeconds(offset);

        while (!vid.isPrepared)
        {
            yield return null;
        }

        vid.Play();
    }

    private void Update()
    {
        if (timer.GetComponent<timer>().start == true)
        {
            if (i == 0)
            {
                if (PlayerPrefs.GetInt("BGA") == 1)
                {
                    StartCoroutine(PlayVideoAfterOffset());
                }
                
                i++;
            }
        }
    }
}