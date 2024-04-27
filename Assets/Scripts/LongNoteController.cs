using UnityEngine;

public class LongNoteController : MonoBehaviour
{
    public bool isActive = true; // 롱노트의 활성화 여부

    private float startTime; // 롱노트의 시작 시간
    private float endTime; // 롱노트의 끝 시간

    public void Initialize(float startTime, float endTime)
    {
        this.startTime = startTime;
        this.endTime = endTime;
    }

    // 롱노트를 끝까지 눌렀는지 여부를 확인하는 메서드
    public bool CheckTouchPosition(Vector2 touchPosition)
    {
        // 여기에 터치 위치를 확인하여 롱노트를 눌렀는지 여부를 판단하는 로직을 추가
        Collider collider = GetComponent<Collider>();
        if (collider.bounds.Contains(new Vector3(touchPosition.x, touchPosition.y, collider.bounds.center.z)))
        {
            return true;
        }
        return false;
    }

    // 롱노트의 상태를 비활성화로 변경하는 메서드
    public void DeactivateLongNote()
    {
        isActive = false;
        // 롱노트를 비활성화하는 추가 로직이 있다면 여기에 구현
        Destroy(gameObject); // 롱노트를 비활성화시키고 나서 삭제
    }
}
