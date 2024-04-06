using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class Data
{
    public string name;
    public int maxBlock;
    public int BPM;
    public int offset;
    public Note[] notes;
}

[Serializable]
public class Note
{
    public int type;
    public int num;
    public int block;
    public int LPB;
    public Note[] notes;
}

public class NoteGen : MonoBehaviour
{
    int BPM;
    float offset;
    public GameObject timer;
    int garim = 30;
    public int noteNum;
    private string songName;
    public GameObject MetronomePrefab;
     public AudioSource clip;
    int i = 0;
    public List<int> LaneNum = new List<int>();
    public List<int> NoteType = new List<int>();
    public List<float> NotesTime = new List<float>();
    public List<GameObject> NotesObj = new List<GameObject>();
    public Material lineMaterial; // Line Renderer에 사용할 머티리얼 추가

    [SerializeField] private float NotesSpeed;
    [SerializeField] GameObject noteObj;
    [SerializeField] GameObject RNotePrefab; // RNote 프리팹 추가

    void Start()
    {
        NotesSpeed = PlayerPrefs.GetInt("Speed");
        noteNum = 0;
        songName = PlayerPrefs.GetString("Song");
        Load(songName);
   
    }

    private void Load(string SongName)
    {
        //web에서 json 가져와서 읽기
        string inputString = System.IO.File.ReadAllText(Application.persistentDataPath + "/" + SongName + ".json");
        Data inputJson = JsonUtility.FromJson<Data>(inputString);
        
        BPM = inputJson.BPM;
        offset = inputJson.offset / 10000;
        noteNum = inputJson.notes.Length;
        for (int i = 0; i < inputJson.notes.Length; i++)
        {
            float kankaku = 60 / (inputJson.BPM * (float)inputJson.notes[i].LPB);
            float beatSec = kankaku * (float)inputJson.notes[i].LPB;
            float time = (beatSec * inputJson.notes[i].num / (float)inputJson.notes[i].LPB) + inputJson.offset / 10000 + PlayerPrefs.GetFloat("Offset");

            if (inputJson.notes[i].type == 1) // 일반 노트 생성
            {
                NotesTime.Add(time);
                LaneNum.Add(inputJson.notes[i].block);
                NoteType.Add(inputJson.notes[i].type);

                float z = NotesTime[i] * NotesSpeed + garim;
                NotesObj.Add(Instantiate(noteObj, new Vector3(inputJson.notes[i].block - 1.5f, z, 0), Quaternion.identity));
            }
            else if (inputJson.notes[i].type == 2) // 롱노트 생성
            {
                NotesTime.Add(time);
                LaneNum.Add(inputJson.notes[i].block);
                NoteType.Add(inputJson.notes[i].type);

                float z = NotesTime[i] * NotesSpeed + garim;
                GameObject rNote = Instantiate(noteObj, new Vector3(inputJson.notes[i].block - 1.5f, z, 0), Quaternion.identity);
                NotesObj.Add(rNote);

                LineRenderer lineRenderer = rNote.AddComponent<LineRenderer>();
                lineRenderer.material = lineMaterial; // 머티리얼 할당
                lineRenderer.startWidth = 0.3f; // 가로 두께 조절
                lineRenderer.endWidth = 0.3f; // 가로 두께 조절

                // rNote 아래에 표시되도록 설정
                lineRenderer.alignment = LineAlignment.View;

                List<Vector3> positions = new List<Vector3>();
                positions.Add(rNote.transform.position);
                for (int a = 0; a < inputJson.notes[i].notes.Length; a++)
                {
                    float timea = (beatSec * inputJson.notes[i].notes[a].num / (float)inputJson.notes[i].notes[a].LPB) + inputJson.offset / 10000 + PlayerPrefs.GetFloat("Offset");
                    float zz = timea * NotesSpeed + garim;
                    GameObject rNoteChild = Instantiate(RNotePrefab, new Vector3(inputJson.notes[i].notes[a].block - 1.5f, zz, 0), Quaternion.identity);
                    NotesObj.Add(rNoteChild);

                    positions.Add(rNoteChild.transform.position);
                }
                lineRenderer.positionCount = positions.Count;
                lineRenderer.SetPositions(positions.ToArray());
            }
        }

    }
}
