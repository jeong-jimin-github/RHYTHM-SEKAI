using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Metronome : MonoBehaviour
{
    public float bpm = 120.0f;
    private float beatInterval;
    private float timer;
    private float totalOffset;
    private int touchCount;

    public Text offsetText;
    public AudioSource audioSource;
    public AudioClip beatSound;

    void Start()
    {
        beatInterval = 60.0f / bpm;
        timer = beatInterval;
        totalOffset = 0.0f;
        touchCount = 0;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0.0f)
        {
            Debug.Log("Beat!");
            audioSource.PlayOneShot(beatSound);
            timer = beatInterval;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                float offset = Mathf.Abs(timer);

                totalOffset += offset;
                touchCount++;

                float averageOffset = totalOffset / touchCount;
                Debug.Log("Average offset from beat: " + averageOffset.ToString("F3") + " seconds");
                offsetText.text = averageOffset.ToString("F3");

                if (touchCount >= 10)
                {
                    PlayerPrefs.SetFloat("Offset", averageOffset);
                    SceneManager.LoadScene("Select");
                }
            }
        }
    }
}
