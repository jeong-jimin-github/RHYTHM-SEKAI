using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fadem : MonoBehaviour

{
    public GameObject SplashObj;               //�ǳڿ�����Ʈ
    int i = 0;
    Image image;                            //�ǳ� �̹���
    public Color pancolor;

    private bool checkbool = false;     //���� ���� ���� ����



    void Start()

    {
        SplashObj.SetActive(true);
        image = SplashObj.GetComponent<Image>();    //�ǳڿ�����Ʈ�� �̹��� ����
        pancolor = image.color;

    }



    void Update()

    {


        if (!checkbool)
        {
            StartCoroutine("MainSplash");                        //�ڷ�ƾ    //�ǳ� ���� ����
        }
        if (checkbool)
        {
            if (i == 0)
            {
                SplashObj.transform.localPosition = new Vector3(0, 5000, 0);
                i++;
            }
        }

    }



    IEnumerator MainSplash()

    {

        Color color = image.color;                            //color �� �ǳ� �̹��� ����



        for (int i = 100; i >= 0; i--)                            //for�� 100�� �ݺ� 0���� ���� �� ����

        {

            color.a -= Time.deltaTime * 0.01f;               //�̹��� ���� ���� Ÿ�� ��Ÿ �� * 0.01



            image.color = color;                                //�ǳ� �̹��� �÷��� �ٲ� ���İ� ����



            if (image.color.a <= 0)                        //���� �ǳ� �̹��� ���� ���� 0���� ������

            {

                checkbool = true;                              //checkbool �� 

            }

        }

        yield return null;                                        //�ڷ�ƾ ����

    }


}