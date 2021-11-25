using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnObject : MonoBehaviour
{

    public GameObject obstacle = null;
    private int lanenum;
    private Vector3 obstacleposition;
    public int min_distance;
    public int max_distance;


    void Start()
    {
        obstacleposition = obstacle.transform.position;

    }

    // Update is called once per frame
    void Update()
    {    
        
        if(Vector3.Distance(GameObject.Find("Player").transform.position, obstacleposition)<100)
        {
            spawn_next_obstacle();
        }

    
    
    }

    private void spawn_next_obstacle()
    {
        Vector3 playerposition = GameObject.Find("Player").transform.position;
        

        int randomlane = Random.Range(-1,2);

        int randomdistance = Random.Range(min_distance,max_distance);
        
        Vector3 next_position = new Vector3(randomlane, 1f, obstacleposition.z+randomdistance);

        spawnobstacle(next_position);
        

 
    }
    private void spawnobstacle(Vector3 position)
    {
        GameObject clone = Instantiate(obstacle, position, Quaternion.identity);
        obstacleposition = position;
        Destroy(clone, 10f);
    
        
    }




}
