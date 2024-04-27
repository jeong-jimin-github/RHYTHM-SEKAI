using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Select2Game : MonoBehaviour
{
    public Button togame;
    void Start()
    {
        togame.onClick.AddListener(game);
    }
    void game()
    {
        SceneManager.LoadSceneAsync("Game");
    }
}
