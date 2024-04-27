using UnityEngine;

public class LongNoteController : MonoBehaviour
{
    public bool isActive = true;

    private float startTime;
    private float endTime;

    public void Initialize(float startTime, float endTime)
    {
        this.startTime = startTime;
        this.endTime = endTime;
    }

    public bool CheckTouchPosition(Vector2 touchPosition)
    {
        Collider collider = GetComponent<Collider>();
        if (collider.bounds.Contains(new Vector3(touchPosition.x, touchPosition.y, collider.bounds.center.z)))
        {
            return true;
        }
        return false;
    }

    public void DeactivateLongNote()
    {
        isActive = false;
        Destroy(gameObject);
    }
}
