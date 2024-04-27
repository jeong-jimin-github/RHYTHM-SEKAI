using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
public class Pause : MonoBehaviour
{
    public Button pause;
    public Button restartb;
    public Button select;
    public Button quit;
    public GameObject PauseUI;
    public GameObject auadio;
    public VideoPlayer video;
    bool IsPause;

    void Start()
    {
        pause.onClick.AddListener(pauseclicked);
        restartb.onClick.AddListener(restart);
        select.onClick.AddListener(kselect);
        quit.onClick.AddListener(quitpause);
        PauseUI.SetActive(false);
        IsPause = false;
    }

    void pauseclicked()
    {
        if (IsPause == false)
        {
            Time.timeScale = 0;
         auadio.GetComponent<MusicManager>().audioPlayer.Pause();
           video.Pause();
            PauseUI.SetActive(true);
            IsPause = true;
            return;
        }
    }

    void quitpause()
    {
        if (IsPause == true)
        {
            Time.timeScale = 1;
          auadio.GetComponent<MusicManager>().audioPlayer.UnPause();
            video.Play();
            PauseUI.SetActive(false);
            IsPause = false;
            return;
        }
    }
    void restart()
    {
        if (IsPause == true)
        {
         auadio.GetComponent<MusicManager>().audioPlayer.Stop();
            video.Pause();
            Time.timeScale = 1;
            IsPause = false;
            SceneManager.LoadScene("Game");
        }
    }

    void kselect()
    {
        if (IsPause == true)
        {
         auadio.GetComponent<MusicManager>().audioPlayer.Stop();
            video.Pause();
            Time.timeScale = 1;
            IsPause = false;
            SceneManager.LoadScene("Select");
        }
    }
}
