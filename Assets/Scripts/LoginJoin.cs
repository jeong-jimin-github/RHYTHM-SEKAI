using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoginJoin : MonoBehaviour
{
    public Button loginButton;
    public Button joinButton;
    // Start is called before the first frame update
    void Start()
    {
        loginButton.onClick.AddListener(() => {
            SceneManager.LoadScene("Login");
        });

        joinButton.onClick.AddListener(() => {
            SceneManager.LoadScene("Join");
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
