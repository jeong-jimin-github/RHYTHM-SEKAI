using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iㅜㅑㅅ : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Speed")) {

        }
        else
        {
            PlayerPrefs.SetInt("Speed", 15);
        }

        if (PlayerPrefs.HasKey("Frame"))
        {

        }
        else
        {
            PlayerPrefs.SetInt("Frame", 60);
        }

        if (PlayerPrefs.HasKey("BGA"))
        {

        }
        else
        {
            PlayerPrefs.SetInt("BGA", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
