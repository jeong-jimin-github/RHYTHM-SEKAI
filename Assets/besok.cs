using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class besok : MonoBehaviour
{
    public int bsesok;
    public float offset;
    Text besoktext;
    Text offt;
    
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        if(scene.name == "Select")
        {
            besoktext = GameObject.Find("besoka").GetComponent<Text>();
            bsesok = Int32.Parse(besoktext.text);
        }
        if(scene.name == "Setting")
        {
            offt = GameObject.Find("off").GetComponent<Text>();
            offset = float.Parse(offt.text);
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
