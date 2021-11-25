using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecam : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    float speed;

    public float smoothspeed;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = target.position + offset; 
   
    }
}
