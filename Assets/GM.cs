using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    private float time;
    public bool start = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
    
        if (time > 2)
        {
            start = true;
        }
        else
        {
            time += Time.deltaTime;
        }
    }
}
