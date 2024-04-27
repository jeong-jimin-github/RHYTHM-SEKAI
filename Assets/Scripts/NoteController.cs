using UnityEngine;

public class NoteController : MonoBehaviour
{
    public bool isActive = true;
    public void ActivateNote()
    {
        isActive = true;
    }

    public void DeactivateNote()
    {
        isActive = false;
    }
}
