using System;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Toucah : MonoBehaviour
{
    public Text guiTextObject;
    public Text score;
    public Animation aa;
    public Animation one;
    public Animation two;
    public Animation three;
    public Animation four;

    public Animation perfecta;
    public Animation greata;
    public Animation gooda;
    public Animation missa;
    private int comboCount = 0;
    private int maxCombo = 0;

    public GameObject sccb;
    void Update()
    {
       

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log("Hit Object: " + hit.collider.gameObject.name);

                    if (hit.collider.gameObject.tag == "Note" || hit.collider.gameObject.tag == "LongNote" || hit.collider.gameObject.tag == "TN")
                    {
                        if(hit.collider.gameObject.transform.localPosition.x == -1.5f)
                        {
                            one.Play();
                            CheckNoteInLine(1);
                           checkTNLine1();
                        }
                        if (hit.collider.gameObject.transform.localPosition.x == -0.5f)
                        {
                            two.Play();
                            CheckNoteInLine(2);
                           
                        }
                        if (hit.collider.gameObject.transform.localPosition.x == 0.5f)
                        {
                            three.Play();
                            CheckNoteInLine(3);
                          
                        }
                        if (hit.collider.gameObject.transform.localPosition.x == 1.5f)
                        {
                            four.Play();
                            CheckNoteInLine(4);
                       
                        }
                    }
                    else
                    {
                        int lineIndex = int.Parse(hit.collider.gameObject.name);
                        if (lineIndex == 1)
                        {
                            one.Play();
                            CheckNoteInLine(1);
                        
                        }
                        if (lineIndex == 2)
                        {
                            two.Play();
                            CheckNoteInLine(2);
                       
                        }
                        if (lineIndex == 3)
                        {
                            three.Play();
                            CheckNoteInLine(3);
                      
                        }
                        if (lineIndex == 4)
                        {
                            four.Play();
                            CheckNoteInLine(4);
                     
                        }
                    }
                }
                else
                {
                    Debug.Log("No object was hit.");
                }
            }
                Ray raya = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hita;

                if (Physics.Raycast(raya, out hita))
                {
                    Debug.Log("Hit Object: " + hita.collider.gameObject.name);

                    if (hita.collider.gameObject.tag == "Note" || hita.collider.gameObject.tag == "LongNote" || hita.collider.gameObject.tag == "TN")
                    {
                        if (hita.collider.gameObject.transform.localPosition.x == -1.5f)
                        {
                         
                            checkTNLine1();
                        }
                        if (hita.collider.gameObject.transform.localPosition.x == -0.5f)
                        {
                           
                            checkTNLine2();
                        }
                        if (hita.collider.gameObject.transform.localPosition.x == 0.5f)
                        {
                           
                            checkTNLine3();
                        }
                        if (hita.collider.gameObject.transform.localPosition.x == 1.5f)
                        {
                           
                            checkTNLine4();
                        }
                    }
                    else
                    {
                        int lineIndex = int.Parse(hita.collider.gameObject.name);
                        if (lineIndex == 1)
                        {
                           
                            checkTNLine1();
                        }
                        if (lineIndex == 2)
                        {
                            
                            checkTNLine2();
                        }
                        if (lineIndex == 3)
                        {
                            checkTNLine3();
                        }
                        if (lineIndex == 4)
                        {
                            checkTNLine4();
                        }
                    }
                }
                else
                {
                    Debug.Log("No object was hit.");
                }
        }

        CheckMissedNotes();
    }

    void checkTNLine1()
    {
        Vector3 bc = new Vector3(-1.5f, 0, 0f);
        Vector3 boxtn = new Vector3(0.5f, 1f, 1f);

        Collider[] tn = Physics.OverlapBox(bc, boxtn);

        foreach (Collider collider in tn)
        {
            if (collider.gameObject.tag == "TN")
            {
                NoteController noteController = collider.gameObject.GetComponent<NoteController>();

                if (noteController != null && noteController.isActive)
                {
                    noteController.DeactivateNote(); // 상태 변경
                    Debug.Log("Object in the box: " + collider.gameObject.name);
                    perfect();
                }
            }
        }
    }
    void checkTNLine2()
    {
        Vector3 bc = new Vector3(-0.5f, 0, 0f);
        Vector3 boxtn = new Vector3(0.5f, 1f, 1f);

        Collider[] tn = Physics.OverlapBox(bc, boxtn);

        foreach (Collider collider in tn)
        {
            if (collider.gameObject.tag == "TN")
            {
                NoteController noteController = collider.gameObject.GetComponent<NoteController>();

                if (noteController != null && noteController.isActive)
                {
                    noteController.DeactivateNote(); // 상태 변경
                    Debug.Log("Object in the box: " + collider.gameObject.name);
                    perfect();
                }
            }
        }
    }
    void checkTNLine3()
    {
        Vector3 bc = new Vector3(0.5f, 0, 0f);
        Vector3 boxtn = new Vector3(0.5f, 1f, 1f);

        Collider[] tn = Physics.OverlapBox(bc, boxtn);

        foreach (Collider collider in tn)
        {
            if (collider.gameObject.tag == "TN")
            {
                NoteController noteController = collider.gameObject.GetComponent<NoteController>();

                if (noteController != null && noteController.isActive)
                {
                    noteController.DeactivateNote(); // 상태 변경
                    Debug.Log("Object in the box: " + collider.gameObject.name);
                    perfect();
                }
            }
        }
    }
    void checkTNLine4()
    {
        Vector3 bc = new Vector3(1.5f, 0, 0f);
        Vector3 boxtn = new Vector3(0.5f, 1f, 1f);

        Collider[] tn = Physics.OverlapBox(bc, boxtn);

        foreach (Collider collider in tn)
        {
            if (collider.gameObject.tag == "TN")
            {
                NoteController noteController = collider.gameObject.GetComponent<NoteController>();

                if (noteController != null && noteController.isActive)
                {
                    noteController.DeactivateNote(); // 상태 변경
                    Debug.Log("Object in the box: " + collider.gameObject.name);
                    perfect();
                }
            }
        }
    }
    void CheckNoteInLine(int lineIndex)
    {
        float lineX = (lineIndex - 2.5f) * 1.0f;
        float lineY = 0f;

        Vector3 boxCenter = new Vector3(lineX, lineY, 0f);
        Vector3 boxSizePerfect = new Vector3(0.5f, 1f, 1f);
        Vector3 boxSizeGreat = new Vector3(0.5f, 1.5f, 1f);
        Vector3 boxSizeGood = new Vector3(0.5f, 3f, 1f);

        Collider[] collidersInBoxPerfect = Physics.OverlapBox(boxCenter, boxSizePerfect);
        Collider[] collidersInBoxGreat = Physics.OverlapBox(boxCenter, boxSizeGreat);
        Collider[] collidersInBoxGood = Physics.OverlapBox(boxCenter, boxSizeGood);

        if (CheckCollidersAndScore(collidersInBoxPerfect, 300))
        {
            comboCount++;
        }
        else if (CheckCollidersAndScore(collidersInBoxGreat, 200))
        {
            comboCount++;
        }
        else if (CheckCollidersAndScore(collidersInBoxGood, 100))
        {
            comboCount++;
        }
        else
        {
            // 터치하지 못했을 경우 콤보 초기화
            comboCount = 0;
        }

        UpdateMaxCombo();
    }

    bool CheckCollidersAndScore(Collider[] colliders, int scoreValue)
    {
        foreach (Collider collider in colliders)
        {
            NoteController noteController = collider.gameObject.GetComponent<NoteController>();

            if (noteController != null && noteController.isActive)
            {
                noteController.DeactivateNote(); // 상태 변경
                Debug.Log("Object in the box: " + collider.gameObject.name);

                if (scoreValue == 300)
                    perfect();
                else if (scoreValue == 200)
                    great();
                else if (scoreValue == 100)
                    good();

                return true;
            }
        }

        return false;
    }

    void UpdateMaxCombo()
    {
        if (comboCount > maxCombo)
        {
            maxCombo = comboCount;
        }
    }

    void CheckMissedNotes()
    {
        Vector3 boxCenter = new Vector3(0f, -4f, 0f);
        Vector3 boxSize = new Vector3(3.0f, 1.0f, 1f);

        Collider[] collidersInBoxMissed = Physics.OverlapBox(boxCenter, boxSize);

        foreach (Collider collider in collidersInBoxMissed)
        {
            NoteController noteController = collider.gameObject.GetComponent<NoteController>();

            if (noteController != null && noteController.isActive)
            {
                miss();
                noteController.DeactivateNote(); // 상태 변경
                comboCount = 0; // 콤보 초기화
            }
        }
    }

    void perfect()
    {
        print("perfect");
        sccb.GetComponent<Last>().bcombo = sccb.GetComponent<Last>().bcombo + 1;
        perfecta.Play();
        guiTextObject.text = (int.Parse(guiTextObject.text) + 1).ToString();
        aa.Play();
        score.text = (int.Parse(score.text) + 300).ToString();
    }

    void great()
    {
        sccb.GetComponent<Last>().bcombo = sccb.GetComponent<Last>().bcombo + 1;
        print("great");
        greata.Play();
        aa.Play();
        guiTextObject.text = (int.Parse(guiTextObject.text) + 1).ToString();
        score.text = (int.Parse(score.text) + 200).ToString();
    }

    void good()
    {
        sccb.GetComponent<Last>().bcombo = sccb.GetComponent<Last>().bcombo + 1;
        print("good");
        gooda.Play();
        aa.Play();
        guiTextObject.text = (int.Parse(guiTextObject.text) + 1).ToString();
        score.text = (int.Parse(score.text) + 100).ToString();
    }

    void miss()
    {
        missa.Play();
        guiTextObject.text = "0";
    }
}
