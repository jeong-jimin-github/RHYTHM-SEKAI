using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class toGame : MonoBehaviour
{
    public Button togame;
    // Start is called before the first frame update
    void Start()
    {
        togame.onClick.AddListener(game);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void game()
    {
        SceneManager.LoadSceneAsync("Game");
    }
}
