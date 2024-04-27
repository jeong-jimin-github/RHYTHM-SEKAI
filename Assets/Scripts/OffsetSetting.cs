using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class offset1 : MonoBehaviour
{
    public Button offsetwizardbutton;
    public Text text;
    public Button plus;
    public Button minus;
    void Start()
    {
        if (!PlayerPrefs.HasKey("Offset"))
        {
            PlayerPrefs.SetFloat("Offset", 0);
        }
        text.text = PlayerPrefs.GetFloat("Offset").ToString();
        plus.onClick.AddListener(plusOffset);
        minus.onClick.AddListener(minusOffset);
        offsetwizardbutton.onClick.AddListener(() => SceneManager.LoadScene("Offset"));
    }

    void plusOffset()
    {
        text.text = (double.Parse(text.text) + 0.01).ToString();
        PlayerPrefs.SetFloat("Offset", float.Parse(text.text));
    }

    void minusOffset()
    {
        text.text = (double.Parse(text.text) - 0.01).ToString();
        PlayerPrefs.SetFloat("Offset", float.Parse(text.text));
    }
}
