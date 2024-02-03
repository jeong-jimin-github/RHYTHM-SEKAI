using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class offset : MonoBehaviour
{
    public Button aB;
    void Start()
    {
        aB.onClick.AddListener(setting);
    }

    void setting()
    {
        SceneManager.LoadScene("Setting");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
