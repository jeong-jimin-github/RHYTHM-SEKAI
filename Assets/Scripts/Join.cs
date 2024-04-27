using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class JoinScript : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public Text messageText;

    public Button joinButton;

    void Start()
    {
        joinButton.onClick.AddListener(Join);
    }
    public void Join()
    {
        StartCoroutine(JoinCoroutine());
    }

    IEnumerator JoinCoroutine()
    {
        string url = "https://rhythm.iwinv.net/join.php";
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

