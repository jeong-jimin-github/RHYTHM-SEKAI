using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGA : MonoBehaviour
{
    public Button O;
    public Button X;
    // Start is called before the first frame update
    void Start()
    {
        O.onClick.AddListener(oclicked);
        X.onClick.AddListener(xclicked);
        if(PlayerPrefs.GetInt("BGA") == 1)
        {
            O.image.color = Color.green;
            X.image.color = Color.white;
        }
        else
        {
            X.image.color = Color.green;
            O.image.color = Color.white;
        }
    }

    void oclicked()
    {
        PlayerPrefs.SetInt("BGA", 1);
        O.image.color = Color.green;
        X.image.color = Color.white;
    }

    void xclicked()
    {
        PlayerPrefs.SetInt("BGA", 0);
        X.image.color = Color.green;
        O.image.color = Color.white;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
