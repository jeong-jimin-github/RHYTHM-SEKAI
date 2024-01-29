using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Last : MonoBehaviour
{
    public string score;
    public int bcombo = 0;

    public Text sc;
    // Start is called before the first frame update
    void Start()
    {
        if(sc==null)
        {
            sc = GameObject.Find("sc").GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        score = sc.text;
    }
    private void Awake()
    {
        // 같은 이름의 GameObject가 있는지 확인
        GameObject[] existingObjects = GameObject.FindGameObjectsWithTag("sc");

        foreach (GameObject obj in existingObjects)
        {
            // 현재 GameObject와 같은 이름의 GameObject가 이미 존재한다면
            if (obj.name == gameObject.name && obj != gameObject)
            {
                // 현재 GameObject 파괴
                Destroy(gameObject);
                return;
            }
        }

        // 같은 이름의 GameObject가 없다면 계속 유지
        DontDestroyOnLoad(gameObject);
    }

}
