using UnityEngine;

public class NoteController : MonoBehaviour
{
    // ���� ����
    public bool isActive = true;

    // ��Ʈ�� Ȱ��ȭ�Ǿ��� ���� ����
    public void ActivateNote()
    {
        isActive = true;
        // ���⿡ ��Ʈ�� Ȱ��ȭ���� ���� �߰� ������ �߰��� �� �ֽ��ϴ�.
    }

    // ��Ʈ�� ��Ȱ��ȭ�Ǿ��� ���� ����
    public void DeactivateNote()
    {
        isActive = false;
        // ���⿡ ��Ʈ�� ��Ȱ��ȭ���� ���� �߰� ������ �߰��� �� �ֽ��ϴ�.
    }
}
