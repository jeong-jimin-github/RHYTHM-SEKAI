using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFrame : MonoBehaviour
{
    void Start()
    {
        int frame = PlayerPrefs.GetInt("Frame");
        Application.targetFrameRate = frame;
    }
}
