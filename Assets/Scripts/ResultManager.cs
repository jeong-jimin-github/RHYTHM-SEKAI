using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public Text Song;
    public Text Score;
    public Text Perfect;
    public Text Great;
    public Text Good;
    public Text Miss;

    void Start()
    {
        Song.text = PlayerPrefs.GetString("Song");
        Score.text = PlayerPrefs.GetInt("Score").ToString();
        Perfect.text = PlayerPrefs.GetInt("Perfect").ToString();
        Great.text = PlayerPrefs.GetInt("Great").ToString();
        Good.text = PlayerPrefs.GetInt("Good").ToString();
        Miss.text = PlayerPrefs.GetInt("Miss").ToString();
    }
}
