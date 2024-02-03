using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bsud : MonoBehaviour
{
    public Button upp;
    public Button downp;
    public Text bes;
    // Start is called before the first frame update
    void Start()
    {
        upp.onClick.AddListener(up);
        downp.onClick.AddListener(down);
    }

    void up()
    {
        if (Int32.Parse(bes.text) >= 30)
        {
        }
        else
        {
            bes.text = (Int32.Parse(bes.text) + 1).ToString();
        }
    }
    void down()
    {
        if (Int32.Parse(bes.text) <= 15)
        {
        }
        else
        {
            bes.text = (Int32.Parse(bes.text) - 1).ToString();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
