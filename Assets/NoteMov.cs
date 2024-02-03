using UnityEngine;

public class NoteMove : MonoBehaviour
{
    int NoteSpeed;
    private void Start()
    {
       NoteSpeed = GameObject.Find("besok").GetComponent<besok>().bsesok;
    }
    void Update()
    {
            MoveNote();
    }
    void MoveNote()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * NoteSpeed);
    }
}
