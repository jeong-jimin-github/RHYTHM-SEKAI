using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class toselect : MonoBehaviour
{    
    public Button selectButton;

    void Start()
    {
        selectButton.onClick.AddListener(() => {
            SceneManager.LoadScene("DL");
        });
    }
}
