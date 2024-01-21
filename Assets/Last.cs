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
        
    }

    // Update is called once per frame
    void Update()
    {
        score = sc.text;
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
