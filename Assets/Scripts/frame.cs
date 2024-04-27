using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class frame : MonoBehaviour
{
    public Button six0;
    public Button ten20;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Frame") == 60)
        {
            six0.image.color = Color.green;
            ten20.image.color = Color.white;
        }
        if (PlayerPrefs.GetInt("Frame") == 120)
        {
            ten20.image.color = Color.green;
            six0.image.color = Color.white;
        }
            six0.onClick.AddListener(change6);

        ten20.onClick.AddListener(change12);
    }

    void change6()
    {
        PlayerPrefs.SetInt("Frame", 60);
        six0.image.color = Color.green;
        ten20.image.color = Color.white;
    }
    void change12()
    {
        PlayerPrefs.SetInt("Frame", 120);
        ten20.image.color = Color.green;
        six0.image.color = Color.white;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
