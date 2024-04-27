using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Newtonsoft.Json;

public class DownloadManager : MonoBehaviour
{
    public GameObject panel;
    public Text statusText;

    [Serializable]
    public class DLListItem
    {
        public string category;
        public string filename;
        public string md5_hash;
    }

    private IEnumerator Start()
    {
        panel.SetActive(true);

        UnityWebRequest request = UnityWebRequest.Get("https://rhythm.iwinv.net/");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Failed to download DLList.json: " + request.error);
            panel.SetActive(false);
            yield break;
        }

        string jsonText = request.downloadHandler.text;
        DLListItem[] items = JsonConvert.DeserializeObject<DLListItem[]>(jsonText);

        for (int i = 0; i < items.Length; i++)
        {
            DLListItem item = items[i];
            string filePath = Path.Combine(Application.persistentDataPath, item.filename);
            print(filePath);
            // 로컬에 파일이 이미 존재하는지 확인
            if (File.Exists(filePath))
            {
                // 로컬 파일의 MD5 해시 계산
                string localMD5 = CalculateMD5(filePath);
                print("local" + localMD5 + " server" + item.md5_hash);
                // 서버에서 받은 파일의 MD5 해시와 비교
                if (localMD5 != item.md5_hash)
                {
                    // MD5 해시가 다른 경우, 파일 다운로드
                    yield return StartCoroutine(DownloadFile(item.category, item.filename, filePath));
                }
            }
            else
            {
                // 로컬에 파일이 없는 경우, 파일 다운로드
                yield return StartCoroutine(DownloadFile(item.category, item.filename, filePath));
            }

            statusText.text = $"Downloaded {i + 1}/{items.Length} files";
            yield return null; // 다음 프레임까지 대기
        }

        // 다운로드 완료 후 씬 전환
        panel.SetActive(false);
        if(PlayerPrefs.HasKey("Offset"))
        {
            SceneManager.LoadScene("Select");
        }
        else
        {
            SceneManager.LoadScene("Offset");
        }
    }

    private IEnumerator DownloadFile(string category, string filename, string filePath)
    {
        string url = "https://rhythm.iwinv.net/Files/" + category + "/" + filename;
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Failed to download file: " + request.error);
            yield break;
        }

        byte[] fileData = request.downloadHandler.data;
        File.WriteAllBytes(filePath, fileData);
    }

    private string CalculateMD5(string filePath)
    {
        using (var md5 = System.Security.Cryptography.MD5.Create())
        {
            using (var stream = File.OpenRead(filePath))
            {
                byte[] hash = md5.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}
