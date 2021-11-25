using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroylvel : MonoBehaviour
{

    private GameObject obstacle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        obstacle = GameObject.Find("Water Obstacke(Clone)");
        
         destroyobstacles();

}

    private void destroyobstacles()
    {
        var cameraPosition = Camera.main.transform.position;
        if(obstacle.transform.position.z<cameraPosition.z)
        {
            Destroy(obstacle);
        }
    }
    }
