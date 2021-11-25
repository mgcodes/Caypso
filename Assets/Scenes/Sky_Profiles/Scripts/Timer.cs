using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float startTime;
    
        public Text timertext;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        
        float t = Time.time - startTime;

        string minutes = ((int)t/60).ToString();
        string secs = (t%60).ToString("f2");

        timertext.text = minutes + ":" + secs;
        
    }
}
