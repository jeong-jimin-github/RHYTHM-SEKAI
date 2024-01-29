using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class offud : MonoBehaviour
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
            bes.text = (double.Parse(bes.text) + 0.1).ToString();
    }
    void down()
    {
            bes.text = (double.Parse(bes.text) - 0.1).ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}