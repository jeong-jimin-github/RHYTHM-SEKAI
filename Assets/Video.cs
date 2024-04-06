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
    // Start is called before the first frame update
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

                // 임시 파일로 비디오를 저장합니다.
                string tempFilePath = Application.persistentDataPath + "/tempVideo.mp4";
                System.IO.File.WriteAllBytes(tempFilePath, videoBytes);

                // 비디오 플레이어에 비디오를 할당합니다.
                vid.url = "file://" + tempFilePath;
                vid.Prepare();

                // 비디오가 준비될 때까지 대기합니다.
                while (!vid.isPrepared)
                {
                    yield return null;
                }

                // 비디오를 재생합니다.
            }
            else
            {
                Debug.LogError("UnityWebRequest failed: " + www.error);
            }
        }
    }

    IEnumerator PlayVideoAfterOffset()
    {
        // offset만큼 대기합니다.
        yield return new WaitForSeconds(offset);

        // 비디오가 준비될 때까지 대기합니다.
        while (!vid.isPrepared)
        {
            yield return null;
        }

        // 비디오를 재생합니다.
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