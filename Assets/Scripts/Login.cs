using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public Text messageText;

    public Button loginButton;

    void Start()
    {
        loginButton.onClick.AddListener(Login);
    }
    public void Login()
    {
        StartCoroutine(LoginCoroutine());
    }

    IEnumerator LoginCoroutine()
    {
        string url = "https://rhythm.iwinv.net/login.php";
        WWWForm form = new WWWForm();
        form.AddField("username", usernameInput.text);
        form.AddField("password", passwordInput.text);

        WWW www = new WWW(url, form);
        yield return www;

        if (www.error != null)
        {
            Debug.LogError("Error: " + www.error);
            yield break;
        }

        messageText.text = www.text;
        print(www.text);
    }
}

