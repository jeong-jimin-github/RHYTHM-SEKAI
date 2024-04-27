using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Back2MainScript : MonoBehaviour
{

    public Button back2MainButton;
    // Start is called before the first frame update
    void Start()
    {
        back2MainButton.onClick.AddListener(Back2Main);
    }

    public void Back2Main()
    {
        SceneManager.LoadScene("Main");
    }
}
