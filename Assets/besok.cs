using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class besok : MonoBehaviour
{
    public int bsesok;
    Text besoktext;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        if(scene.name == "Select")
        {
            besoktext = GameObject.Find("besoka").GetComponent<Text>();
            bsesok = Int32.Parse(besoktext.text);
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
