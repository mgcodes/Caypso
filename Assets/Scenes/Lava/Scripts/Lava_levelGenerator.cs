using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava_levelGenerator : MonoBehaviour
{
    public GameObject flat = null;
    private Transform startposition;
    private Vector3 endposition; 
    public GameObject player;
    
    private const float levelspawndist = 50;
    private Vector3 playerposition;


    // Start is called before the first frame update
    void Start()
    {   
       endposition = GameObject.Find("EndPosition").transform.position;
    
    }

     private void FixedUpdate()
     {
    
       if(Vector3.Distance(GameObject.Find("Player").transform.position, endposition)<levelspawndist)
        {

            spawnpart();
        
        }   
     }

    private void spawnpart()
    {

        Vector3 playerposition = GameObject.Find("Player").transform.position;
        int randomlane = Random.Range(-1,2);
        Vector3 next_position = new Vector3(randomlane, 0f, endposition.z+20);
        spawnobstacle(next_position);

        
    }

    private void spawnobstacle(Vector3 position)
    {
        Instantiate(flat, position, Quaternion.identity);
        endposition = position;
        
    }


}
