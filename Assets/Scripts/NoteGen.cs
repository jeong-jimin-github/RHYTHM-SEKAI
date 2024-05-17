using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UIElements;

[Serializable]
public class LNote
{
    public int line;
    public int start_tick;
}

[Serializable]
public class Note
{
    public int line;
    public int start_tick;
    public int type;
    public LNote[] notes;
}

public class NoteGen : MonoBehaviour
{
    int TICK;
    int BPM;
    float OFFSET;
    int garim = 30;
    public int noteNum;
    private string songName;
    public List<int> LaneNum = new List<int>();
    public List<int> NoteType = new List<int>();
    public List<float> NotesTime = new List<float>();
    public List<GameObject> NotesObj = new List<GameObject>();
    public Material lineMaterial;

    [SerializeField] private float NotesSpeed;
    [SerializeField] GameObject noteObj;
    [SerializeField] GameObject RNotePrefab;

    void Start()
    {
        NotesSpeed = PlayerPrefs.GetInt("Speed");
        noteNum = 0;
        songName = PlayerPrefs.GetString("Song");
        Load(songName);
   
    }

    private void Load(string SongName)
    {
        string inputString = System.IO.File.ReadAllText(Application.persistentDataPath + "/" + SongName + ".fu");
        string[] notetext = inputString.Split("\n");

        
        for (int i=0; i<notetext.Length; i++)
        {
            if (notetext[i] == "")
            {

            }
            else
            {

                string header = notetext[i].Split("=")[0];
                string naiyou = notetext[i].Split("=")[1];

                if (header == "TICK")
                {
                    TICK = Int32.Parse(naiyou);
                    print("TICK :" + TICK.ToString());
                }
                else if (header == "BPM")
                {
                    BPM = Int32.Parse(naiyou);
                    print("BPM: " + BPM.ToString());
                }
                else if (header == "OFFSET")
                {
                    OFFSET = float.Parse(naiyou);
                    print(OFFSET);
                }
                else if (header == "NOTE")
                {
                    //parse json
                    Note note = JsonConvert.DeserializeObject<Note>(naiyou);
                    print(note.line);
                    print(note.start_tick);

                    float kankaku = 60f / BPM / TICK;
                    print("kankaku :" + kankaku.ToString());
                    float beatSec = kankaku * note.start_tick;
                    print("beatsec: " + beatSec.ToString());
                    float time = beatSec + OFFSET + PlayerPrefs.GetFloat("Offset");
                    print("time: " + time.ToString());

                    if (note.type == 0)
                    {
                        float z = time * NotesSpeed + garim;
                        print("Z: " + z.ToString());
                        GameObject Note = Instantiate(noteObj, new Vector3(note.line - 2.5f, z, 0), Quaternion.identity);
                    }

                    if (note.type == 1)
                    {
                        float z = time * NotesSpeed + garim;
                        print("Z: " + z.ToString());
                        GameObject LNote = Instantiate(noteObj, new Vector3(note.line - 2.5f, z, 0), Quaternion.identity);
                        LineRenderer lineRenderer = LNote.AddComponent<LineRenderer>();
                        lineRenderer.material = lineMaterial;
                        lineRenderer.startWidth = 1.5f;
                        lineRenderer.endWidth = 1.5f;

                        lineRenderer.alignment = LineAlignment.TransformZ;

                        List<Vector3> positions = new List<Vector3>();
                        positions.Add(LNote.transform.position);

                        for (int a = 0; a < note.notes.Length; a++)
                        {
                            float LNotebeatSec = kankaku * note.notes[a].start_tick;
                            float LNotetime = LNotebeatSec + OFFSET + PlayerPrefs.GetFloat("Offset");
                            float zz = LNotetime * NotesSpeed + garim;
                            GameObject rNoteChild = Instantiate(RNotePrefab, new Vector3(note.notes[a].line - 2.5f, zz, 0), Quaternion.identity);
                            NotesObj.Add(rNoteChild);

                            positions.Add(rNoteChild.transform.position);
                        }
                        lineRenderer.positionCount = positions.Count;
                        lineRenderer.SetPositions(positions.ToArray());
                    }
                }
            }

        }
    }
}


/* for (int i = 0; i < inputJson.notes.Length; i++)
 {
     float kankaku = 60 / (inputJson.BPM * (float)inputJson.notes[i].LPB);
     float beatSec = kankaku * (float)inputJson.notes[i].LPB;
     float time = (beatSec * inputJson.notes[i].num / (float)inputJson.notes[i].LPB) + offset + PlayerPrefs.GetFloat("Offset");

     if (inputJson.notes[i].type == 1)
     {
         NotesTime.Add(time);
         LaneNum.Add(inputJson.notes[i].block);
         NoteType.Add(inputJson.notes[i].type);

         float z = NotesTime[i] * NotesSpeed + garim;
         NotesObj.Add(Instantiate(noteObj, new Vector3(inputJson.notes[i].block - 1.5f, z, 0), Quaternion.identity));
     }
     else if (inputJson.notes[i].type == 2)
     {
         NotesTime.Add(time);
         LaneNum.Add(inputJson.notes[i].block);
         NoteType.Add(inputJson.notes[i].type);

         float z = NotesTime[i] * NotesSpeed + garim;
         GameObject rNote = Instantiate(noteObj, new Vector3(inputJson.notes[i].block - 1.5f, z, 0), Quaternion.identity);
         NotesObj.Add(rNote);

         LineRenderer lineRenderer = rNote.AddComponent<LineRenderer>();
         lineRenderer.material = lineMaterial;
         lineRenderer.startWidth = 0.3f;
         lineRenderer.endWidth = 0.3f;

         lineRenderer.alignment = LineAlignment.View;

         List<Vector3> positions = new List<Vector3>();
         positions.Add(rNote.transform.position);
         for (int a = 0; a < inputJson.notes[i].notes.Length; a++)
         {
             float timea = (beatSec * inputJson.notes[i].notes[a].num / (float)inputJson.notes[i].notes[a].LPB) + offset + PlayerPrefs.GetFloat("Offset");
             float zz = timea * NotesSpeed + garim;
             GameObject rNoteChild = Instantiate(RNotePrefab, new Vector3(inputJson.notes[i].notes[a].block - 1.5f, zz, 0), Quaternion.identity);
             NotesObj.Add(rNoteChild);

             positions.Add(rNoteChild.transform.position);
         }
         lineRenderer.positionCount = positions.Count;
         lineRenderer.SetPositions(positions.ToArray());
     }
 }*/
