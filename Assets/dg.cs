using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class dg : MonoBehaviour
{
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void gotogame()
    {
        {
            StartCoroutine("Fadegyaku");
        }
    }
    IEnumerator Fadegyaku()

    {

        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            image.color = new Color(0, 0, 0, i);
            print(i);
            if (i >= 0.9)                        //���� �ǳ� �̹��� ���� ���� 0���� ������

            {

                SceneManager.LoadScene("Last");
            }


            yield return null;                                        //�ڷ�ƾ ����

        }
    }
}
