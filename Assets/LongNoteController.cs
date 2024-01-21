using UnityEngine;

public class LongNoteController : MonoBehaviour
{
    public bool isActive = true; // �ճ�Ʈ�� Ȱ��ȭ ����

    private float startTime; // �ճ�Ʈ�� ���� �ð�
    private float endTime; // �ճ�Ʈ�� �� �ð�

    public void Initialize(float startTime, float endTime)
    {
        this.startTime = startTime;
        this.endTime = endTime;
    }

    // �ճ�Ʈ�� ������ �������� ���θ� Ȯ���ϴ� �޼���
    public bool CheckTouchPosition(Vector2 touchPosition)
    {
        // ���⿡ ��ġ ��ġ�� Ȯ���Ͽ� �ճ�Ʈ�� �������� ���θ� �Ǵ��ϴ� ������ �߰�
        Collider collider = GetComponent<Collider>();
        if (collider.bounds.Contains(new Vector3(touchPosition.x, touchPosition.y, collider.bounds.center.z)))
        {
            return true;
        }
        return false;
    }

    // �ճ�Ʈ�� ���¸� ��Ȱ��ȭ�� �����ϴ� �޼���
    public void DeactivateLongNote()
    {
        isActive = false;
        // �ճ�Ʈ�� ��Ȱ��ȭ�ϴ� �߰� ������ �ִٸ� ���⿡ ����
        Destroy(gameObject); // �ճ�Ʈ�� ��Ȱ��ȭ��Ű�� ���� ����
    }
}
