using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    float time = 0;
    public bool start = false;
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 2)
        {
            print("start");
            start = true;
        }
    }
}
