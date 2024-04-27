using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedSetting : MonoBehaviour
{
    public Text speed;
    public Button plus;
    public Button minus;
    void Start()
    {
        speed.text = PlayerPrefs.GetInt("Speed").ToString();
        plus.onClick.AddListener(increase);
        minus.onClick.AddListener(decrease);
    }

    void increase()
    {
        speed.text = (Int32.Parse(speed.text) + 1).ToString();
        PlayerPrefs.SetInt("Speed", Int32.Parse(speed.text));
    }
    void decrease()
    {
        if (Int32.Parse(speed.text) - 1 < 10)
        {

        }
        else
        {
            speed.text = (Int32.Parse(speed.text) - 1).ToString();
            PlayerPrefs.SetInt("Speed", Int32.Parse(speed.text));
        }
    } 
    // Update is called once per frame
    void Update()
    {
        
    }
}
