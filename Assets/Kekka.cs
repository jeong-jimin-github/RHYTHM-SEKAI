using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kekka : MonoBehaviour
{
    public Text combo;
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        score.text = GameObject.Find("ScCo").GetComponent<Last>().score;
        combo.text = GameObject.Find("ScCo").GetComponent<Last>().bcombo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
