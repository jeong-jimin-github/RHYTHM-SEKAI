using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Back : MonoBehaviour
{
    public Button bb;
    // Start is called before the first frame update
    void Start()
    {
        bb.onClick.AddListener(backS);
    }

    void backS()
    {
        SceneManager.LoadScene("Select");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
