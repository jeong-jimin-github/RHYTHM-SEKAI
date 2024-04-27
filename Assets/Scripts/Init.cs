using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
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
}
