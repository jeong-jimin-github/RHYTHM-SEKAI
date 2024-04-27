using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BackSelect : MonoBehaviour
{
    public Button modoru;
    void Start()
    {
        modoru.onClick.AddListener(select);
    }

    void select()
    {
        SceneManager.LoadScene("Select");
    }
}
