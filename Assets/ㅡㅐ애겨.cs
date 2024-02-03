using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ㅡㅐ애겨 : MonoBehaviour
{
    public Button modoru;
    // Start is called before the first frame update
    void Start()
    {
        modoru.onClick.AddListener(select);
    }

    void select()
    {
        SceneManager.LoadScene("Select");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
