using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class modoru : MonoBehaviour
{
    public Button modaoru;
    // Start is called before the first frame update
    void Start()
    {
        modaoru.onClick.AddListener(modor);
    }

    void modor()
    {
        SceneManager.LoadScene("Select");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
