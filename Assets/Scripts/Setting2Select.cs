using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting2Select : MonoBehaviour
{
    public Button backbutton;
    void Start()
    {
        backbutton.onClick.AddListener(Back2Select);
    }

    void Back2Select()
    {
        SceneManager.LoadScene("Select");
    }
}
