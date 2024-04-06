using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Metronome : MonoBehaviour
{
    public float bpm = 120.0f; // Beats per minute
    private float beatInterval; // Interval between beats in seconds
    private float timer;
    private float totalOffset; // Accumulated time offset from beats
    private int touchCount; // Number of touch inputs

    public Text offsetText;
    public AudioSource audioSource;
    public AudioClip beatSound;

    void Start()
    {
        // Calculate beat interval from BPM
        beatInterval = 60.0f / bpm;
        timer = beatInterval; // Start timer at first beat
        totalOffset = 0.0f;
        touchCount = 0;
    }

    void Update()
    {
        // Timer counting down
        timer -= Time.deltaTime;

        if (timer <= 0.0f)
        {
            // Do something on each beat (e.g., play sound, flash screen)
            Debug.Log("Beat!");
            audioSource.PlayOneShot(beatSound);

            // Reset timer for the next beat
            timer = beatInterval;
        }

        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                // Calculate offset from beat
                float offset = Mathf.Abs(timer);

                // Add offset to total and increment touch count
                totalOffset += offset;
                touchCount++;

                // Calculate and print average offset
                float averageOffset = totalOffset / touchCount - 0.4f;
                Debug.Log("Average offset from beat: " + averageOffset.ToString("F3") + " seconds");
                offsetText.text = averageOffset.ToString("F3");

                // If enough touches collected, save offset and load next scene
                if (touchCount >= 10)
                {
                    PlayerPrefs.SetFloat("Offset", averageOffset);
                    SceneManager.LoadScene("Select");
                }
            }
        }
    }
}
