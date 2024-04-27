using UnityEngine;

public class NoteMove : MonoBehaviour
{
    GameObject timer;
    int NoteSpeed;
    LineRenderer lineRenderer;

    private void Start()
    {
        NoteSpeed = PlayerPrefs.GetInt("Speed");
        timer = GameObject.Find("timer");

        // 라인 렌더러가 있는 경우 참조
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        MoveNote();
    }

    void MoveNote()
    {
        if (timer.GetComponent<timer>().start == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * NoteSpeed, 0f);

            // 라인 렌더러가 있는 경우 라인 렌더러도 함께 이동
            if (lineRenderer != null)
            {
                Vector3[] positions = new Vector3[lineRenderer.positionCount];
                lineRenderer.GetPositions(positions);
                for (int i = 0; i < positions.Length; i++)
                {
                    positions[i] = new Vector3(positions[i].x, positions[i].y - Time.deltaTime * NoteSpeed, positions[i].z);
                }
                lineRenderer.SetPositions(positions);
            }
        }
    }
}
