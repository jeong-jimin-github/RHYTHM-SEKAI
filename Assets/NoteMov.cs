using UnityEngine;

public class NoteMove : MonoBehaviour
{
    int NoteSpeed = 15;
    void Update()
    {
            MoveNote();
    }

    void MoveNote()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * NoteSpeed);
    }
}
