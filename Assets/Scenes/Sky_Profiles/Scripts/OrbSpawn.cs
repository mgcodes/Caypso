using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OrbSpawn : MonoBehaviour
{

    public GameObject orb = null;
    private int lanenum;
    private Vector3 obstacleposition;

    public float spawnheight = 0;
    


    void Start()
    {
        obstacleposition = orb.transform.position;

    }

    // Update is called once per frame
    void Update()
    {    
        
        if(Vector3.Distance(GameObject.Find("Player").transform.position, obstacleposition)<20)
        {
            spawn_next_obstacle();
        }
    
    
    }

    private void spawn_next_obstacle()
    {
        Vector3 playerposition = GameObject.Find("Player").transform.position;
        

        int randomlane = Random.Range(-1,2);

        int randomdistance = Random.Range(20,30);
        
        Vector3 next_position = new Vector3(randomlane, spawnheight, obstacleposition.z+randomdistance);

        spawnobstacle(next_position);
        

 
    }
    private void spawnobstacle(Vector3 position)
    {
        Instantiate(orb, position, Quaternion.identity);
        obstacleposition = position;
        
    }

 
 
}
