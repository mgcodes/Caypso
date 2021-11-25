using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trailfolow : MonoBehaviour
{


    private TrailRenderer tr;
    private Vector3 trailposition;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player").transform.position.y>0.9f)
        {
            tr.time = 0.0f;
            tr.widthMultiplier = 0;
        } 
        else
        {
            tr.time = 1;
            tr.widthMultiplier = 1;
        }  
    }
}
