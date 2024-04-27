using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Back : MonoBehaviour
{
    public Button Result2SelectButton;
    // Start is called before the first frame update
    void Start()
    {
        Result2SelectButton.onClick.AddListener(Back2Select);
    }
    void Back2Select()
    {
        SceneManager.LoadScene("Select");
    }
}
