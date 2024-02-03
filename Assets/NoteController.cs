using UnityEngine;

public class NoteController : MonoBehaviour
{
    // 상태 변수
    public bool isActive = true;

    // 노트가 활성화되었을 때의 동작
    public void ActivateNote()
    {
        isActive = true;
        // 여기에 노트가 활성화됐을 때의 추가 동작을 추가할 수 있습니다.
    }

    // 노트가 비활성화되었을 때의 동작
    public void DeactivateNote()
    {
        isActive = false;
        // 여기에 노트가 비활성화됐을 때의 추가 동작을 추가할 수 있습니다.
    }
}
