using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sㅐㅏ애 : MonoBehaviour
{
    public Text sokdo;
    public Button plus;
    public Button minus;
    // Start is called before the first frame update
    void Start()
    {
        sokdo.text = PlayerPrefs.GetInt("Speed").ToString();
        plus.onClick.AddListener(pluss);
        minus.onClick.AddListener(minuss);
    }

    void pluss()
    {
        sokdo.text = (Int32.Parse(sokdo.text) + 1).ToString();
        PlayerPrefs.SetInt("Speed", Int32.Parse(sokdo.text));
    }
    void minuss()
    {
        if (Int32.Parse(sokdo.text) - 1 < 10)
        {

        }
        else
        {
            sokdo.text = (Int32.Parse(sokdo.text) - 1).ToString();
            PlayerPrefs.SetInt("Speed", Int32.Parse(sokdo.text));
        }
    } 
    // Update is called once per frame
    void Update()
    {
        
    }
}
