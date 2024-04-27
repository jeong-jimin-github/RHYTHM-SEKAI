using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFrame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int frame = PlayerPrefs.GetInt("Frame");
        Application.targetFrameRate = frame;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
